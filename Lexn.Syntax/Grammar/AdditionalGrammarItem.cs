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
            while (true)
            {
                _multipliyerGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
                var nextLexem = analyzeResult.Lexems.Peek();
                if (nextLexem.Name != "*")
                {
                    return;
                }
                nextLexem = analyzeResult.Lexems.Dequeue();
            }            
        }
    }
}
