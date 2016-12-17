using System.Linq;
using Lexn.Common;
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
            while (analyzeResult.Lexems.Any())
            {
                _multipliyerGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
                var nextLexem = analyzeResult.Lexems.Peek();
                if (nextLexem.Name != "*" && nextLexem.Name != "/")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedMultiplier, nextLexem.Line, "Missed multiplayer or divisor.");
                    return;
                }
            }            
        }
    }
}
