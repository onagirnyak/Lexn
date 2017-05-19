using System;
using System.Linq;
using Lexn.Common;
using Lexn.Common.Analyze;
using Lexn.Common.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    internal class ConstantGrammarItem : IGrammarItem
    {
        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            var firstLexem = analyzeResult.Lexems.Dequeue();

            if (firstLexem.Type != LexemType.Const)
                analyzeResult.AddError(AnalyzeErrorCode.MissedConstant,
                    firstLexem.Line, String.Format("Invalid token {0}", firstLexem.Name));
        }
    }
}
