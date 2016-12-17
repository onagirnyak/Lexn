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
            var isIf = nextLexem.Name == "if";
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
            else if (isIf)
            {
                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Type != LexemType.Identifier && nextLexem.Type != LexemType.Const)
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedIdentifier, nextLexem.Line, "Missed identifier or constant.");
                    return;
                }

                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Name != "=")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedEqual, nextLexem.Line, "Missed equal.");
                    return;
                }

                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Type != LexemType.Identifier && nextLexem.Type != LexemType.Const)
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedIdentifier, nextLexem.Line, "Missed identifier or constant.");
                    return;
                }

                nextLexem = analyzeResult.Lexems.Dequeue();
                if (nextLexem.Name != "then")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedThen, nextLexem.Line, "Missed then.");
                    return;
                }

                Parse(analyzeResult);

                nextLexem = analyzeResult.Lexems.Dequeue(true);
                if (nextLexem.Name != "else")
                {
                    analyzeResult.AddError(AnalyzeErrorCode.MissedElse, nextLexem.Line, "Missed else.");
                    return;
                }
                Parse(analyzeResult);

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
                Parse(analyzeResult);
            }
            else if (nextLexem.Name == "end")
            {
                return;
            }
            else
            {
                analyzeResult.AddError(AnalyzeErrorCode.UnknownOperation, nextLexem.Line, "Unknown operation");
                return;
            }
        }
    }
}
