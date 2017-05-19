using System.Linq;
using Lexn.Common;
using Lexn.Common.Model;
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
            _operatorGrammarItem.Parse(analyzeResult);
            if (!analyzeResult.IsValid)
            {
                return;
            }
            while (analyzeResult.Lexems.Peek().Type == LexemType.OperationSeparator)
            {
                analyzeResult.Lexems.Dequeue();
                _operatorGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
            }
        }
    }
}
