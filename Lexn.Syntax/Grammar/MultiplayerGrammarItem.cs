using System.Linq;
using Lexn.Common;
using Lexn.Common.Analyze;
using Lexn.Common.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    public class MultiplayerGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _identifierGrammarItem;
        private readonly IGrammarItem _constantGrammarItem;

        public MultiplayerGrammarItem(IGrammarItem identifierGrammarItem,
            IGrammarItem constantGrammarItem)
        {
            _identifierGrammarItem = identifierGrammarItem;
            _constantGrammarItem = constantGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            var nextLexem = analyzeResult.Lexems.Peek();
            if (nextLexem.Type == LexemType.Identifier)
            {
                _identifierGrammarItem.Parse(analyzeResult);
            }
            else if (nextLexem.Type == LexemType.Const)
            {
                _constantGrammarItem.Parse(analyzeResult);
            }
            else if (nextLexem.Name == "(")
            {
                nextLexem = analyzeResult.Lexems.Dequeue();
                var statement = new StatementGrammarItem(new AdditionalGrammarItem(this));
                statement.Parse(analyzeResult);
                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Name != ")")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedBraces, nextLexem.Line, "Missed ')'.");
                }
            }
            else
            {
                analyzeResult.AddError(AnalyzeErrorCode.UnknownOperation, nextLexem.Line, "Unknown operation.");
                return;
            }
        }
    }
}
