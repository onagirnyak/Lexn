using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    internal class AdditionalGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _multipliyerGrammarItem;

        public AdditionalGrammarItem(IGrammarItem multipliyerGrammarItem)
        {
            _multipliyerGrammarItem = multipliyerGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            _multipliyerGrammarItem.Parse(analyzeResult);
            if (!analyzeResult.IsValid)
            {
                return;
            }
            while (analyzeResult.Lexems.Peek().Name == "*" || analyzeResult.Lexems.Peek().Name == "/")
            {
                analyzeResult.Lexems.Dequeue();
                _multipliyerGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
            }            
        }
    }
}
