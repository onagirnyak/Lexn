using System;
using System.Linq;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    internal class ConstantGrammarItem : IGrammarItem
    {
        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            var firstLexem = analyzeResult.Lexems.Dequeue();

            if (firstLexem.Type != LexemType.Const)
                analyzeResult.AddError(AnalyzeErrorCode.BrokenConstant,
                    firstLexem.Line, String.Format("Invalid token {0}", firstLexem.Name));
        }
    }
}
