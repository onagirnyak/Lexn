using System.Linq;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    public class OperationListGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _operatorGrammarItem;

        public OperationListGrammarItem(IGrammarItem operatorGrammarItem)
        {
            _operatorGrammarItem = operatorGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            while (analyzeResult.Lexems.Any())
            {
                _operatorGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
                var nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Type != LexemType.OperationSeparator)
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedDelimiter, nextLexem.Line, "Missed operation delimiter.");
                    return;
                }
            }
        }
    }
}
