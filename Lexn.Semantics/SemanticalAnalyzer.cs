using System;
using System.Collections.Generic;
using System.Linq;
using Lexn.Common;
using Lexn.Lexis;
using Lexn.Lexis.Model;

namespace Lexn.Semantics
{
    public class SemanticalAnalyzer : IAnalyzer
    {
        private readonly IKeyWordsProvider _keyWordsProvider;

        public SemanticalAnalyzer(IKeyWordsProvider keyWordsProvider)
        {
            _keyWordsProvider = keyWordsProvider;
        }

        public AnalyzeResult Analyze(object obj)
        {
            var lexicalResult = obj as LexicalAnalyzeResult;
            var semanticsResult = new SemanticalAnalyzeResult();
            if (lexicalResult != null)
            {
                var dataTypes = _keyWordsProvider.GetSystemDataTypes();
                for (int i = 0; i < lexicalResult.Lexems.Length; i++)
                {
                    var lexem = lexicalResult.Lexems[i];
                    if (lexem.Type == LexemType.Colon)
                    {
                        var prevLexem = lexicalResult.Lexems[i - 1];
                        var nextLexem = lexicalResult.Lexems[i + 1];
                        if (prevLexem.Type != LexemType.Identifier)
                        {
                            semanticsResult.AddError(AnalyzeErrorCode.IdentifierIsNotDefined, prevLexem.Line,
                                String.Format("You can define identifier only. Not operators or keywords."));
                        }
                        if (!dataTypes.Contains(nextLexem.Name))
                        {
                            semanticsResult.AddError(AnalyzeErrorCode.IdentifierIsNotDefined, nextLexem.Line,
                                String.Format("Invalid data type: {0}", nextLexem.Name));
                        }
                    }

                    if (lexem.Type == LexemType.Identifier)
                    {
                        var nextLexem = lexicalResult.Lexems[i + 1];
                        if (nextLexem.Type != LexemType.Colon)
                        {
                            if (lexem.Identifier == null || !dataTypes.Contains(lexem.Identifier.Type))
                            {
                                semanticsResult.AddError(AnalyzeErrorCode.UseBeforeDeclaration, lexem.Line,
                                    String.Format("Unpossible use {0} identifier before declaration.", lexem.Name));
                            }
                        }
                    }
                }
            }
           
            return semanticsResult;
        }
    }
}
