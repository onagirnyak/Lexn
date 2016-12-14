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
            while (true)
            {
                _additionalGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
                var nextLexem = analyzeResult.Lexems.Peek();
                if (nextLexem.Name != "+" && nextLexem.Name != "<")
                {
                    return;
                }
                nextLexem = analyzeResult.Lexems.Dequeue();
            }
        }
    }
}
