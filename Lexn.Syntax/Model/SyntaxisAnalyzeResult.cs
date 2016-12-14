using System.Collections.Generic;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Grammar;

namespace Lexn.Syntax.Model
{
    public class SyntaxisAnalyzeResult : AnalyzeResult
    {
        public SyntaxisAnalyzeResult(Queue<Lexem> lexems)
        {
            Lexems = lexems;
        }

        public GrammarItemType Type { get; set; }

        public Queue<Lexem> Lexems { get; set; }
    }
}
