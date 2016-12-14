using System;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    public class ProgramGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _identifierGrammarItem;
        private readonly IGrammarItem _identifierListGrammarItem;
        private readonly IGrammarItem _operatorListGrammarItem;

        public ProgramGrammarItem(IGrammarItem identifierGrammarItem,
            IGrammarItem identifierListGrammarItem,
            IGrammarItem operatorListGrammarItem)
        {
            _identifierGrammarItem = identifierGrammarItem;
            _identifierListGrammarItem = identifierListGrammarItem;
            _operatorListGrammarItem = operatorListGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            var nextLexem = analyzeResult.Lexems.Dequeue(true);

            if (nextLexem.Name != "program")
            {
                analyzeResult.AddError(AnalyzeErrorCode.MissedProgram, nextLexem.Line, "Keyword 'program' is required.");
                return;
            }

            _identifierGrammarItem.Parse(analyzeResult);
            if (!analyzeResult.IsValid)
            {
                return;
            }

            nextLexem = analyzeResult.Lexems.Dequeue(true);
            if (nextLexem.Name != "var")
            {
                analyzeResult.AddError(AnalyzeErrorCode.MissedVar, nextLexem.Line, "Keyword 'var' is required.");
                return;
            }

            _identifierListGrammarItem.Parse(analyzeResult);
            if (!analyzeResult.IsValid)
            {
                return;
            }

            nextLexem = analyzeResult.Lexems.Dequeue(true);
            if (nextLexem.Type != LexemType.Colon)
            {
                analyzeResult.AddError(AnalyzeErrorCode.MissedColon, nextLexem.Line, String.Format("Colon is missed."));
                return;
            }

            nextLexem = analyzeResult.Lexems.Dequeue();
            if (nextLexem.Type != LexemType.SystemDataType)
            {
                analyzeResult.AddError(AnalyzeErrorCode.UndefinedDataType, nextLexem.Line, String.Format("Invalid data type: {0}.", nextLexem.Name));
                return;
            }

            nextLexem = analyzeResult.Lexems.Dequeue(true);
            if (nextLexem.Name != "begin")
            {
                analyzeResult.AddError(AnalyzeErrorCode.MissedBegin, nextLexem.Line, "Miss 'begin'.");
                return;
            }

            _operatorListGrammarItem.Parse(analyzeResult);
            if (!analyzeResult.IsValid)
            {
                return;
            }
            
            nextLexem = analyzeResult.Lexems.Dequeue(true);
            if (nextLexem.Name != "end")
            {
                analyzeResult.AddError(AnalyzeErrorCode.MissedEnd, nextLexem.Line, "Miss 'end'.");
                return;
            }
        }
    }
}
