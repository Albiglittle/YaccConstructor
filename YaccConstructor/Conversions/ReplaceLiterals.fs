﻿//  Module ReplaceLiterals contains:
//  - function, which replaces all literals in grammar by tokens and
//  writes a comment to header about them.
//
//  Copyright 2009, 2011 Konstantin Ulitin
//
//  This file is part of YaccConctructor.
//
//  YaccConstructor is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

module Yard.Core.Conversions.ReplaceLiterals

open Yard.Core
open Yard.Core.IL
open Yard.Core.IL.Production

open System.Collections.Generic

let tokenName literal token_format =
    let upper = 
        String.collect 
            (function
            | '>' -> "GREATER"
            | '=' -> "EQUAL"
            | '<' -> "LESS"
            | ';' -> "SEMICOLON"
            | ':' -> "COLON"
            | '_' | ' ' -> "_"
            | c when System.Char.IsLetterOrDigit c -> string (System.Char.ToUpper c) 
            | _ -> ""
            )
            literal
    if upper.Length=0
    then "EMPTY" 
    else 
        let format = Printf.StringFormat<string->string>(token_format)
        sprintf format upper

let rec eachProduction f productionList =
    List.iter 
        (function    
        | PSeq(elements, actionCode, l) -> 
            PSeq(elements, actionCode, l) |> f
            List.map (fun elem -> elem.rule) elements |> eachProduction f
        | PAlt(left, right) -> 
            PAlt(left, right) |> f
            eachProduction f [left; right]
        | PConjuct(left, right) ->
            f <| PConjuct(left, right)
            eachProduction f [left; right]
        | PNegat x ->
            f <| PNegat x
            eachProduction f [x]
        | PMany x ->
            PMany x |> f
            eachProduction f [x]
        | PSome x ->
            PSome x |> f
            eachProduction f [x]
        | POpt x  ->
            POpt x |> f
            eachProduction f [x]
        | x -> f x
        )
        productionList 

let replaceLiteralsInProduction production (replacedLiterals:Dictionary<_,_>) (grammarTokens:HashSet<_>) token_format= 
    let rec _replaceLiterals = function
        | PSeq(elements, actionCode, l) -> 
            (
                elements 
                |> List.map (fun elem -> { elem with rule = _replaceLiterals elem.rule })
                ,actionCode, l
            )
            |> PSeq
        | PAlt(left, right) -> PAlt(_replaceLiterals left, _replaceLiterals right)
        | PMany x -> PMany(_replaceLiterals x)
        | PSome x -> PSome(_replaceLiterals x)
        | POpt x  -> POpt(_replaceLiterals x)
        | PLiteral src -> 
            let str = src.text
            if replacedLiterals.ContainsKey str
            then PToken <| new Source.t(replacedLiterals.[str], src)
            else
                let token = ref(tokenName str token_format)
                while grammarTokens.Contains !token do
                    eprintfn 
                        "WARNING. ReplaceLiterals. Token with name %s is already exists. Seems, that you use token %s and literal %s. Please, resolve this ambiguity."
                        !token !token str
                    token := "YARD_" + !token
                replacedLiterals.Add(str, !token) 
                PToken <| new Source.t(!token, src) 
        | x -> x
    _replaceLiterals production

let replaceLiterals (ruleList: Rule.t<Source.t, Source.t> list) token_format = 
    
    let grammarTokens = new HashSet<_>()
    eachProduction
        (function
        | PToken name -> grammarTokens.Add name.text |> ignore
        | _ -> ()
        )
        (ruleList |> List.map (fun rule -> rule.body) )
    let replacedLiterals = new Dictionary<string, string>() // <literal text, token>
    ruleList |> List.map (fun rule -> {rule with body=replaceLiteralsInProduction rule.body replacedLiterals grammarTokens token_format} )  

type ReplaceLiterals() = 
    inherit Conversion()
        override this.Name = "ReplaceLiterals"
        override this.ConvertGrammar grammar = this.ConvertGrammar(grammar, [|"%s"|])
        override this.ConvertGrammar (grammar, token_format) = mapGrammar (fun rules -> replaceLiterals rules token_format.[0]) grammar
