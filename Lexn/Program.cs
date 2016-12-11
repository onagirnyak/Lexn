using System;
using Lexn.Lexis;

namespace Lexn
{
    class Program
    {
        static void Main(string[] args)
        {

            var program =
                @"
                program MyProgram
                begin
                var a := a -3;
                if a = 3>5 then 
                begin
                    a := 5
                end
                for var     i :=3 to i <5 do
                begin
                i := i+1
                end
                end
                ";

            var lexicalAnalyzer = LexisFactory.CreateLexicalAnalyzer();
            var lexicalResult = lexicalAnalyzer.Analyze(program);

            Console.ReadKey();
        }
    }
}
