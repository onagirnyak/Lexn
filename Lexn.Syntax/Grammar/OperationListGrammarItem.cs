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
            _operatorGrammarItem.Parse(analyzeResult);
            if (!analyzeResult.IsValid)
            {
                return;
            }
            while (analyzeResult.Lexems.Dequeue().Type == LexemType.OperationSeparator)
            {
                _operatorGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
            }
        }
    }
}
