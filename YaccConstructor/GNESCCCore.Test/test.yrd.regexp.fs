//this file was generated by GNESCC
//source grammar:../../../Tests/GNESCC/test.yrd
//date:10/24/2011 11:49:19

module GNESCC.Regexp_test

open Yard.Generators.GNESCCGenerator
open System.Text.RegularExpressions

let buildIndexMap kvLst =
    let ks = List.map (fun (x:string,y) -> x.Length + 2,y) kvLst
    List.fold (fun (bl,blst) (l,v) -> bl+l,((bl,v)::blst)) (0,[]) ks
    |> snd
    |> dict

let buildStr kvLst =
    let sep = ";;"
    List.map fst kvLst 
    |> String.concat sep
    |> fun s -> ";" + s + ";"

let s childsLst = 
    let str = buildStr childsLst
    let idxValMap = buildIndexMap childsLst
    let re = new Regex("((;2;)((;3;))|((;4;)))")
    let elts =
        let res = re.Match(str)
        if Seq.fold (&&) true [for g in res.Groups -> g.Success]
        then res.Groups
        else (new Regex("((;2;)((;3;))|((;4;)))",RegexOptions.RightToLeft)).Match(str).Groups
    let e1 =
        if elts.[4].Value = ""
        then
            let e2 =
                let e0 =
                    idxValMap.[elts.[6].Captures.[0].Index] |> RELeaf
                RESeq [e0]
            None, Some (e2)
        else
            let e1 =
                let e0 =
                    idxValMap.[elts.[4].Captures.[0].Index] |> RELeaf
                RESeq [e0]
            Some (e1),None
        |> REAlt

    let e0 =
        idxValMap.[elts.[2].Captures.[0].Index] |> RELeaf
    RESeq [e0; e1]
let e childsLst = 
    let str = buildStr childsLst
    let idxValMap = buildIndexMap childsLst
    let re = new Regex("((;8;))")
    let elts =
        let res = re.Match(str)
        if Seq.fold (&&) true [for g in res.Groups -> g.Success]
        then res.Groups
        else (new Regex("((;8;))",RegexOptions.RightToLeft)).Match(str).Groups
    let e0 =
        idxValMap.[elts.[2].Captures.[0].Index] |> RELeaf
    RESeq [e0]
let a childsLst = 
    let str = buildStr childsLst
    let idxValMap = buildIndexMap childsLst
    let re = new Regex("((;9;))")
    let elts =
        let res = re.Match(str)
        if Seq.fold (&&) true [for g in res.Groups -> g.Success]
        then res.Groups
        else (new Regex("((;9;))",RegexOptions.RightToLeft)).Match(str).Groups
    let e0 =
        idxValMap.[elts.[2].Captures.[0].Index] |> RELeaf
    RESeq [e0]
let b childsLst = 
    let str = buildStr childsLst
    let idxValMap = buildIndexMap childsLst
    let re = new Regex("((;10;))")
    let elts =
        let res = re.Match(str)
        if Seq.fold (&&) true [for g in res.Groups -> g.Success]
        then res.Groups
        else (new Regex("((;10;))",RegexOptions.RightToLeft)).Match(str).Groups
    let e0 =
        idxValMap.[elts.[2].Captures.[0].Index] |> RELeaf
    RESeq [e0]

let ruleToRegex = dict [|(4,b); (3,a); (2,e); (1,s)|]

