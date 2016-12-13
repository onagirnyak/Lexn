using System.Collections.Generic;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax
{
    internal class SyntaxisAnalyzer : IAnalyzer
    {
        private readonly IGrammarItem _rootGrammarItem;

        public SyntaxisAnalyzer(IGrammarItem rootGrammarItem)
        {
            _rootGrammarItem = rootGrammarItem;
        }

        public AnalyzeResult Analyze(object obj)
        {
            var lexems = obj as Lexem[];
            var syntaxResult = new SyntaxisAnalyzeResult(new Queue<Lexem>(lexems));
            _rootGrammarItem.Parse(syntaxResult);
            return syntaxResult;
        }
    }
}
