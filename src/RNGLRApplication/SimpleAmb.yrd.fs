
# 2 "SimpleAmb.yrd.fs"
module RNGLR.SimpleAmb
#nowarn "64";; // From fsyacc: turn off warnings that type variables used in production annotations are instantiated to concrete type
open Yard.Generators.RNGLR.Parser
open Yard.Generators.RNGLR
open Yard.Generators.Common.AST
open Yard.Generators.Common.AstNode
type Token =
    | DIV of (int)
    | LBRACE of (int)
    | MINUS of (int)
    | MULT of (int)
    | NUMBER of (int)
    | PLUS of (int)
    | POW of (int)
    | RBRACE of (int)
    | RNGLR_EOF of (int)
    | SEMI of (int)

let genLiteral (str : string) (data : int) =
    match str.ToLower() with
    | x -> None
let tokenData = function
    | DIV x -> box x
    | LBRACE x -> box x
    | MINUS x -> box x
    | MULT x -> box x
    | NUMBER x -> box x
    | PLUS x -> box x
    | POW x -> box x
    | RBRACE x -> box x
    | RNGLR_EOF x -> box x
    | SEMI x -> box x

let numToString = function
    | 0 -> "error"
    | 1 -> "expr"
    | 2 -> "factor"
    | 3 -> "factorOp"
    | 4 -> "powExpr"
    | 5 -> "powOp"
    | 6 -> "term"
    | 7 -> "termOp"
    | 8 -> "yard_rule_binExpr_1"
    | 9 -> "yard_rule_binExpr_3"
    | 10 -> "yard_rule_binExpr_5"
    | 11 -> "yard_rule_yard_many_1_2"
    | 12 -> "yard_rule_yard_many_1_4"
    | 13 -> "yard_rule_yard_many_1_6"
    | 14 -> "yard_some_1"
    | 15 -> "yard_start_rule"
    | 16 -> "DIV"
    | 17 -> "LBRACE"
    | 18 -> "MINUS"
    | 19 -> "MULT"
    | 20 -> "NUMBER"
    | 21 -> "PLUS"
    | 22 -> "POW"
    | 23 -> "RBRACE"
    | 24 -> "RNGLR_EOF"
    | 25 -> "SEMI"
    | _ -> ""

let tokenToNumber = function
    | DIV _ -> 16
    | LBRACE _ -> 17
    | MINUS _ -> 18
    | MULT _ -> 19
    | NUMBER _ -> 20
    | PLUS _ -> 21
    | POW _ -> 22
    | RBRACE _ -> 23
    | RNGLR_EOF _ -> 24
    | SEMI _ -> 25

let isLiteral = function
    | DIV _ -> false
    | LBRACE _ -> false
    | MINUS _ -> false
    | MULT _ -> false
    | NUMBER _ -> false
    | PLUS _ -> false
    | POW _ -> false
    | RBRACE _ -> false
    | RNGLR_EOF _ -> false
    | SEMI _ -> false

let getLiteralNames = []
let mutable private cur = 0
let leftSide = [|1; 1; 15; 8; 11; 11; 14; 14; 7; 7; 6; 9; 12; 12; 3; 3; 2; 10; 13; 13; 5; 4; 4|]
let private rules = [|14; 8; 1; 6; 11; 7; 6; 11; 8; 25; 8; 25; 14; 21; 18; 9; 2; 12; 3; 2; 12; 19; 16; 10; 4; 13; 5; 4; 13; 22; 20; 17; 1; 23|]
let private rulesStart = [|0; 1; 2; 3; 5; 5; 8; 10; 13; 14; 15; 16; 18; 18; 21; 22; 23; 24; 26; 26; 29; 30; 31; 34|]
let startRule = 2

let acceptEmptyInput = false

let defaultAstToDot =
    (fun (tree : Yard.Generators.Common.AST.Tree<Token>) -> tree.AstToDot numToString tokenToNumber None leftSide)

let private lists_gotos = [|1; 2; 8; 69; 75; 73; 67; 79; 13; 65; 3; 68; 6; 7; 4; 5; 9; 66; 12; 10; 11; 14; 16; 20; 27; 37; 33; 34; 50; 24; 35; 15; 17; 64; 18; 19; 21; 63; 22; 23; 25; 26; 28; 36; 31; 32; 29; 30; 38; 39; 43; 55; 61; 59; 53; 62; 47; 51; 40; 54; 41; 42; 44; 52; 45; 46; 48; 49; 56; 60; 57; 58; 70; 74; 71; 72; 76; 77; 78|]
let private small_gotos =
        [|10; 65536; 131073; 262146; 393219; 524292; 589829; 655366; 917511; 1114120; 1310729; 131076; 196618; 786443; 1048588; 1245197; 196613; 131086; 262146; 655366; 1114120; 1310729; 262148; 196618; 786447; 1048588; 1245197; 524291; 327696; 851985; 1441810; 589827; 262163; 1114120; 1310729; 655363; 327696; 851988; 1441810; 851978; 65557; 131094; 262167; 393240; 524313; 589850; 655387; 917532; 1114141; 1310750; 917505; 1507359; 1048580; 196640; 786465; 1048588; 1245197; 1114117; 131106; 262167; 655387; 1114141; 1310750; 1179652; 196640; 786467; 1048588; 1245197; 1310723; 327716; 852005; 1441810; 1376259; 262182; 1114141; 1310750; 1441795; 327716; 852007; 1441810; 1572874; 65576; 131094; 262167; 393240; 524313; 589850; 655387; 917532; 1114141; 1310750; 1638401; 1507369; 1769476; 458794; 720939; 1179692; 1376301; 1835015; 131094; 262167; 393262; 589850; 655387; 1114141; 1310750; 1900548; 458794; 720943; 1179692; 1376301; 2424833; 1638448; 2490377; 131121; 262194; 393267; 524340; 589877; 655414; 917559; 1114168; 1310777; 2555908; 196666; 786491; 1048588; 1245197; 2621445; 131132; 262194; 655414; 1114168; 1310777; 2686980; 196666; 786493; 1048588; 1245197; 2818051; 327742; 852031; 1441810; 2883587; 262208; 1114168; 1310777; 2949123; 327742; 852033; 1441810; 3080202; 65602; 131094; 262167; 393240; 524313; 589850; 655387; 917532; 1114141; 1310750; 3145729; 1507395; 3604484; 458820; 720965; 1179692; 1376301; 3670023; 131121; 262194; 393286; 589877; 655414; 1114168; 1310777; 3735556; 458820; 720967; 1179692; 1376301; 3997697; 1638448; 4521988; 458824; 720969; 1179692; 1376301; 4587527; 131073; 262146; 393290; 589829; 655366; 1114120; 1310729; 4653060; 458824; 720971; 1179692; 1376301; 4915201; 1638476; 4980745; 131121; 262194; 393267; 524365; 589877; 655414; 917582; 1114168; 1310777; 5046273; 1638476|]
let gotos = Array.zeroCreate 80
for i = 0 to 79 do
        gotos.[i] <- Array.zeroCreate 26
cur <- 0
while cur < small_gotos.Length do
    let i = small_gotos.[cur] >>> 16
    let length = small_gotos.[cur] &&& 65535
    cur <- cur + 1
    for k = 0 to length-1 do
        let j = small_gotos.[cur + k] >>> 16
        let x = small_gotos.[cur + k] &&& 65535
        gotos.[i].[j] <- lists_gotos.[x]
    cur <- cur + length
let private lists_reduces = [|[|11,1|]; [|13,2|]; [|13,3|]; [|15,1|]; [|14,1|]; [|17,1|]; [|19,2|]; [|19,3|]; [|20,1|]; [|22,3|]; [|3,1|]; [|5,2|]; [|5,3|]; [|9,1|]; [|8,1|]; [|10,1|]; [|16,1|]; [|21,1|]; [|3,2|]; [|1,1|]; [|6,2|]; [|0,1|]; [|17,2|]; [|11,2|]; [|7,3|]|]
let private small_reduces =
        [|131076; 1179648; 1376256; 1572864; 1638400; 262148; 1179649; 1376257; 1572865; 1638401; 327684; 1179650; 1376258; 1572866; 1638402; 393218; 1114115; 1310723; 458754; 1114116; 1310724; 524294; 1048581; 1179653; 1245189; 1376261; 1572869; 1638405; 655366; 1048582; 1179654; 1245190; 1376262; 1572870; 1638406; 720902; 1048583; 1179655; 1245191; 1376263; 1572871; 1638407; 786434; 1114120; 1310728; 983047; 1048585; 1179657; 1245193; 1376265; 1441801; 1572873; 1638409; 1048580; 1179648; 1376256; 1507328; 1638400; 1179652; 1179649; 1376257; 1507329; 1638401; 1245188; 1179650; 1376258; 1507330; 1638402; 1310726; 1048581; 1179653; 1245189; 1376261; 1507333; 1638405; 1441798; 1048582; 1179654; 1245190; 1376262; 1507334; 1638406; 1507334; 1048583; 1179655; 1245191; 1376263; 1507335; 1638407; 1703943; 1048585; 1179657; 1245193; 1376265; 1441801; 1507337; 1638409; 1769474; 1507338; 1638410; 1900546; 1507339; 1638411; 1966082; 1507340; 1638412; 2031618; 1114125; 1310733; 2097154; 1114126; 1310734; 2162692; 1179663; 1376271; 1507343; 1638415; 2228230; 1048592; 1179664; 1245200; 1376272; 1507344; 1638416; 2293767; 1048593; 1179665; 1245201; 1376273; 1441809; 1507345; 1638417; 2359298; 1507346; 1638418; 2424833; 1507347; 2490369; 1507348; 2555907; 1179648; 1376256; 1638400; 2686979; 1179649; 1376257; 1638401; 2752515; 1179650; 1376258; 1638402; 2818053; 1048581; 1179653; 1245189; 1376261; 1638405; 2949125; 1048582; 1179654; 1245190; 1376262; 1638406; 3014661; 1048583; 1179655; 1245191; 1376263; 1638407; 3211270; 1048585; 1179657; 1245193; 1376265; 1441801; 1638409; 3276801; 1507349; 3342342; 1048593; 1179665; 1245201; 1376273; 1441809; 1638417; 3407877; 1048598; 1179670; 1245206; 1376278; 1638422; 3473413; 1048592; 1179664; 1245200; 1376272; 1638416; 3538947; 1179671; 1376279; 1638423; 3604481; 1638410; 3735553; 1638411; 3801089; 1638412; 3866627; 1179663; 1376271; 1638415; 3932161; 1638418; 4063233; 1507352; 4128774; 1048598; 1179670; 1245206; 1376278; 1507350; 1638422; 4194308; 1179671; 1376279; 1507351; 1638423; 4259847; 1048593; 1179665; 1245201; 1376273; 1441809; 1572881; 1638417; 4325382; 1048598; 1179670; 1245206; 1376278; 1572886; 1638422; 4390918; 1048592; 1179664; 1245200; 1376272; 1572880; 1638416; 4456452; 1179671; 1376279; 1572887; 1638423; 4521986; 1572874; 1638410; 4653058; 1572875; 1638411; 4718594; 1572876; 1638412; 4784132; 1179663; 1376271; 1572879; 1638415; 4849666; 1572882; 1638418; 4915201; 1572883; 4980737; 1572884; 5111809; 1572888; 5177345; 1572885|]
let reduces = Array.zeroCreate 80
for i = 0 to 79 do
        reduces.[i] <- Array.zeroCreate 26
cur <- 0
while cur < small_reduces.Length do
    let i = small_reduces.[cur] >>> 16
    let length = small_reduces.[cur] &&& 65535
    cur <- cur + 1
    for k = 0 to length-1 do
        let j = small_reduces.[cur + k] >>> 16
        let x = small_reduces.[cur + k] &&& 65535
        reduces.[i].[j] <- lists_reduces.[x]
    cur <- cur + length
let private lists_zeroReduces = [|[|12|]; [|18|]; [|4|]|]
let private small_zeroReduces =
        [|131076; 1179648; 1376256; 1572864; 1638400; 262148; 1179648; 1376256; 1572864; 1638400; 524294; 1048577; 1179649; 1245185; 1376257; 1572865; 1638401; 655366; 1048577; 1179649; 1245185; 1376257; 1572865; 1638401; 1048580; 1179648; 1376256; 1507328; 1638400; 1179652; 1179648; 1376256; 1507328; 1638400; 1310726; 1048577; 1179649; 1245185; 1376257; 1507329; 1638401; 1441798; 1048577; 1179649; 1245185; 1376257; 1507329; 1638401; 1769474; 1507330; 1638402; 1900546; 1507330; 1638402; 2555907; 1179648; 1376256; 1638400; 2686979; 1179648; 1376256; 1638400; 2818053; 1048577; 1179649; 1245185; 1376257; 1638401; 2949125; 1048577; 1179649; 1245185; 1376257; 1638401; 3604481; 1638402; 3735553; 1638402; 4521986; 1572866; 1638402; 4653058; 1572866; 1638402|]
let zeroReduces = Array.zeroCreate 80
for i = 0 to 79 do
        zeroReduces.[i] <- Array.zeroCreate 26
cur <- 0
while cur < small_zeroReduces.Length do
    let i = small_zeroReduces.[cur] >>> 16
    let length = small_zeroReduces.[cur] &&& 65535
    cur <- cur + 1
    for k = 0 to length-1 do
        let j = small_zeroReduces.[cur + k] >>> 16
        let x = small_zeroReduces.[cur + k] &&& 65535
        zeroReduces.[i].[j] <- lists_zeroReduces.[x]
    cur <- cur + length
let private small_acc = [1]
let private accStates = Array.zeroCreate 80
for i = 0 to 79 do
        accStates.[i] <- List.exists ((=) i) small_acc
let eofIndex = 24
let errorIndex = 0
let errorRulesExists = false
let private parserSource = new ParserSource<Token> (gotos, reduces, zeroReduces, accStates, rules, rulesStart, leftSide, startRule, eofIndex, tokenToNumber, acceptEmptyInput, numToString, errorIndex, errorRulesExists)
let buildAst : (seq<Token> -> ParseResult<Token>) =
    buildAst<Token> parserSource

