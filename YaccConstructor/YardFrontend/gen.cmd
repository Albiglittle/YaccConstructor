@echo off

..\..\bin\Release\v40\YaccConstructor_min_base.exe  -f FsYaccFrontend -i Parser.fsy ^
    -g "RNGLRGenerator -o Parser.fs -module Yard.Frontends.YardFrontend.GrammarParser -pos Source.Position -token Source.t" > log.txt