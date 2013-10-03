﻿//   Copyright 2013 YaccConstructor Software Foundation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

module Yard.Core.Layouts

open Microsoft.FSharp.Text.StructuredFormat
open Microsoft.FSharp.Text.StructuredFormat.LayoutOps

let LayoutTable table layoutItem =
    table
    |> Seq.map
        (Seq.map 
            (layoutItem >> wordL)
            >> Seq.toList 
            >> semiListL
            >> fun l -> [ wordL "[|"; l; wordL "|];"] |> spaceListL )
    |> Seq.toList
    |> aboveListL
    |> fun l -> [ wordL "[|"; l; wordL "|]"] 
    |> spaceListL

let LayoutArray layoutItem = 
    Seq.map
            layoutItem
            >> Seq.toList 
            >> semiListL
            >> fun l -> [ wordL "[|"; l; wordL "|];"] |> spaceListL