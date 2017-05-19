using System;
using Lexn.Common;
using Lexn.Common.Analyze;
using Lexn.Common.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    public class IdentifierGrammarItem : IGrammarItem
    {
        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            var firstLexem = analyzeResult.Lexems.Dequeue();
            if (firstLexem.Type != LexemType.Identifier)
            {
                analyzeResult.AddError(AnalyzeErrorCode.MissedIdentifier, firstLexem.Line, String.Format("Invalid token {0}", firstLexem.Name));
                return;
            }
        }
    }
}
