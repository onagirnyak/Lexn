using System.Linq;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    public class MultiplayerGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _identifierGrammarItem;
        private readonly IGrammarItem _constantGrammarItem;
        private readonly IGrammarItem _statementGrammarItem;

        public MultiplayerGrammarItem(IGrammarItem identifierGrammarItem,
            IGrammarItem constantGrammarItem,
            IGrammarItem statementGrammarItem)
        {
            _identifierGrammarItem = identifierGrammarItem;
            _constantGrammarItem = constantGrammarItem;
            _statementGrammarItem = statementGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            _identifierGrammarItem.Parse(analyzeResult);
            var isIdentifierValid = analyzeResult.IsValid;
            _constantGrammarItem.Parse(analyzeResult);
            var isConstantValid  = analyzeResult.IsValid;
            _statementGrammarItem.Parse(analyzeResult);
            var isStatementValid = analyzeResult.IsValid;

            if (isIdentifierValid && isConstantValid && isStatementValid)
            {
                analyzeResult.Lexems.Dequeue();
                analyzeResult.ClearErrors();
            }
        }
    }
}
