//this file was generated by GNESCC
//source grammar:../../../Tests/GNESCC/regexp/complex/seq_nonterms/seq_nonterms.yrd
//date:10/24/2011 11:49:21

module GNESCC.Actions_seq_nonterms

open Yard.Generators.GNESCCGenerator

let getUnmatched x expectedType =
    "Unexpected type of node\nType " + x.ToString() + " is not expected in this position\n" + expectedType + " was expected." |> failwith

let value x = (x:>Lexer_seq_nonterms.MyLexeme).MValue

let s0 expr = 
    let inner  = 
        match expr with
        | RESeq [x0; gnescc_x1; x2] -> 
            let (l) =
                let yardElemAction expr = 
                    match expr with
                    | RELeaf n -> (n :?> _ ) 
                    | x -> getUnmatched x "RELeaf"

                yardElemAction(x0)
            let (gnescc_x1) =
                let yardElemAction expr = 
                    match expr with
                    | RELeaf tPLUS -> tPLUS :?> 'a
                    | x -> getUnmatched x "RELeaf"

                yardElemAction(gnescc_x1)
            let (r) =
                let yardElemAction expr = 
                    match expr with
                    | RELeaf n -> (n :?> _ ) 
                    | x -> getUnmatched x "RELeaf"

                yardElemAction(x2)
            (r+l)
        | x -> getUnmatched x "RESeq"
    box (inner)
let n1 expr = 
    let inner  = 
        match expr with
        | RESeq [x0] -> 
            let (x) =
                let yardElemAction expr = 
                    match expr with
                    | RELeaf tNUMBER -> tNUMBER :?> 'a
                    | x -> getUnmatched x "RELeaf"

                yardElemAction(x0)
            ((value x |> float))
        | x -> getUnmatched x "RESeq"
    box (inner)

let ruleToAction = dict [|(2,n1); (1,s0)|]


//test footer

