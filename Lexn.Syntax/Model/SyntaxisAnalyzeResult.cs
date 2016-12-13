using System.Collections.Generic;
using Lexn.Common;
using Lexn.Lexis.Model;

namespace Lexn.Syntax.Model
{
    public class SyntaxisAnalyzeResult : AnalyzeResult
    {
        public SyntaxisAnalyzeResult(Queue<Lexem> lexems)
        {
            Lexems = lexems;
        }

        public Queue<Lexem> Lexems { get; set; }
    }
}
