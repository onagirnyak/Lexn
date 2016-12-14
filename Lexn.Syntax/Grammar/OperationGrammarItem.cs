using System;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    internal class OperationGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _identifierListGrammarItem;
        private readonly IGrammarItem _identifierGrammarItem;
        private readonly IGrammarItem _statementGrammarItem;

        public OperationGrammarItem(IGrammarItem identifierListGrammarItem,
            IGrammarItem identifierGrammarItem,
            IGrammarItem statementGrammarItem)
        {
            _identifierListGrammarItem = identifierListGrammarItem;
            _identifierGrammarItem = identifierGrammarItem;
            _statementGrammarItem = statementGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            var nextLexem = analyzeResult.Lexems.Dequeue(true);
            var isRead = nextLexem.Name == "readln";
            var isWrite = nextLexem.Name == "writeln";
            var isIdentifier = nextLexem.Type == LexemType.Identifier;
            var isFor = nextLexem.Name == "for";
            if (isRead || isWrite)
            {
                _identifierListGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                } 
            }
            else if (isIdentifier)
            {
                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Type != LexemType.Assigment)
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedAssignment, nextLexem.Line, "Missed assigment.");
                    return;
                }
                _statementGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
            }
            else if (isFor)
            {
                _identifierGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Type != LexemType.Assigment)
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedAssignment, nextLexem.Line, "Missed assigment.");
                    return;
                }
                _statementGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Name != "to")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedTo, nextLexem.Line, "Missed 'to' key word.");
                    return;
                }
                _statementGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Name != "do")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedDo, nextLexem.Line, "Missed 'do' key word.");
                    return;
                }
                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Name != "begin")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedBegin, nextLexem.Line, "Missed 'begin' key word.");
                    return;
                }
                Parse(analyzeResult);
                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Name != "end")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedEnd, nextLexem.Line, "Missed 'end' key word.");
                    return;
                }
            }
            else
            {
                analyzeResult.AddError(AnalyzeErrorCode.UnknownOperation, nextLexem.Line, "Unknown operation");
                return;
            }
        }
    }
}
