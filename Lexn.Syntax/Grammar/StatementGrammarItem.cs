using System.Linq;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    internal class StatementGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _additionalGrammarItem;

        public StatementGrammarItem(IGrammarItem additionalGrammarItem)
        {
            _additionalGrammarItem = additionalGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            _additionalGrammarItem.Parse(analyzeResult);
            if (!analyzeResult.IsValid)
            {
                return;
            }
            while (analyzeResult.Lexems.Peek().Name == "+" || analyzeResult.Lexems.Peek().Name == "-")
            {
                analyzeResult.Lexems.Dequeue();
                _additionalGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
            }
        }
    }
}
