//this file was generated by RACC
//source grammar:../../../../Tests/RACC/test_summator_1\test_summator_1.yrd
//date:11/20/2010 9:55:55 PM

module RACC.Actions

open Yard.Generators._RACCGenerator

let value x =
    ((x:Lexeme<string>).value)

let s0 expr = 
    match expr with
    | RESeq([x0])-> 
        let (res) =
            let yardElemAction expr = 
                match expr with
                | RELeaf e -> e :?> 'a

            yardElemAction(x0)
        box (res)

let e1 expr = 
    match expr with
    | REAlt(Some(x), None) -> 
        let yardLAltAction expr = 
            match expr with
            | RESeq([x0])-> 
                let (n) =
                    let yardElemAction expr = 
                        match expr with
                        | RELeaf NUMBER -> NUMBER :?> 'a

                    yardElemAction(x0)
                box (value n |> float)

        yardLAltAction x 
    | REAlt(None, Some(x)) -> 
        let yardRAltAction expr = 
            match expr with
            | RESeq([x0; _; x1])-> 
                let (n) =
                    let yardElemAction expr = 
                        match expr with
                        | RELeaf NUMBER -> NUMBER :?> 'a

                    yardElemAction(x0)

                let (e) =
                    let yardElemAction expr = 
                        match expr with
                        | RELeaf e -> e :?> 'a

                    yardElemAction(x1)
                box (value n |> float |> ((+) e))

        yardRAltAction x 


let ruleToAction = dict [|("e",e1); ("s",s0)|]

