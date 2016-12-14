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
            while (analyzeResult.Lexems.Peek(true).Name != "end")
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
