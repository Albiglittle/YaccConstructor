//this file was generated by GNESCC
//source grammar:../../../Tests/GNESCC/sql1/yards/a1.yrd
//date:06.12.2011 21:59:38

module GNESCC.Regexp_a1

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

let sql_expr childsLst = 
    let str = buildStr childsLst
    let idxValMap = buildIndexMap childsLst
    let re = new Regex("(((;5;))|(((;6;)(;1;)(;7;))|(((;8;))|(((;1;)(;9;)(;1;))|(((;10;)(;1;)(;11;)(;1;))|((;12;)))))))")
    let elts =
        let res = re.Match(str)
        if Seq.fold (&&) true [for g in res.Groups -> g.Success]
        then res.Groups
        else (new Regex("(((;5;))|(((;6;)(;1;)(;7;))|(((;8;))|(((;1;)(;9;)(;1;))|(((;10;)(;1;)(;11;)(;1;))|((;12;)))))))",RegexOptions.RightToLeft)).Match(str).Groups
    if elts.[3].Value = ""
    then
        let e2 =
            if elts.[8].Value = ""
            then
                let e2 =
                    if elts.[11].Value = ""
                    then
                        let e2 =
                            if elts.[16].Value = ""
                            then
                                let e2 =
                                    if elts.[22].Value = ""
                                    then
                                        let e2 =
                                            let e0 =
                                                idxValMap.[elts.[24].Captures.[0].Index] |> RELeaf
                                            RESeq [e0]
                                        None, Some (e2)
                                    else
                                        let e1 =
                                            let e3 =
                                                idxValMap.[elts.[22].Captures.[0].Index] |> RELeaf
                                            let e2 =
                                                idxValMap.[elts.[21].Captures.[0].Index] |> RELeaf
                                            let e1 =
                                                idxValMap.[elts.[20].Captures.[0].Index] |> RELeaf
                                            let e0 =
                                                idxValMap.[elts.[19].Captures.[0].Index] |> RELeaf
                                            RESeq [e0; e1; e2; e3]
                                        Some (e1),None
                                    |> REAlt

                                None, Some (e2)
                            else
                                let e1 =
                                    let e2 =
                                        idxValMap.[elts.[16].Captures.[0].Index] |> RELeaf
                                    let e1 =
                                        idxValMap.[elts.[15].Captures.[0].Index] |> RELeaf
                                    let e0 =
                                        idxValMap.[elts.[14].Captures.[0].Index] |> RELeaf
                                    RESeq [e0; e1; e2]
                                Some (e1),None
                            |> REAlt

                        None, Some (e2)
                    else
                        let e1 =
                            let e0 =
                                idxValMap.[elts.[11].Captures.[0].Index] |> RELeaf
                            RESeq [e0]
                        Some (e1),None
                    |> REAlt

                None, Some (e2)
            else
                let e1 =
                    let e2 =
                        idxValMap.[elts.[8].Captures.[0].Index] |> RELeaf
                    let e1 =
                        idxValMap.[elts.[7].Captures.[0].Index] |> RELeaf
                    let e0 =
                        idxValMap.[elts.[6].Captures.[0].Index] |> RELeaf
                    RESeq [e0; e1; e2]
                Some (e1),None
            |> REAlt

        None, Some (e2)
    else
        let e1 =
            let e0 =
                idxValMap.[elts.[3].Captures.[0].Index] |> RELeaf
            RESeq [e0]
        Some (e1),None
    |> REAlt


let ruleToRegex = dict [|(1,sql_expr)|]

