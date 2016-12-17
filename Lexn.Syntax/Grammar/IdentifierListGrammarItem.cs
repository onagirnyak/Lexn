using System.Linq;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    internal class IdentifierListGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _identifierGrammarItem;

        public IdentifierListGrammarItem(IGrammarItem identifierGrammarItem)
        {
            _identifierGrammarItem = identifierGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            while (analyzeResult.Lexems.Any())
            {
                _identifierGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
                var nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Name != ",")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedComa, nextLexem.Line, "Coma between operators is missed.");
                    return;
                }
            }
        }
    }
}
