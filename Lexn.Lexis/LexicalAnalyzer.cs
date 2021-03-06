﻿using System;
using System.Linq;
using Lexn.Common;
using Lexn.Common.Analyze;
using Lexn.Common.Interfaces;
using Lexn.Common.Model;
using Lexn.Lexis.Model;

namespace Lexn.Lexis
{
    internal class LexicalAnalyzer : IAnalyzer
    {
        private readonly ClassTable _classTable;

        public LexicalAnalyzer(ClassTable classTable)
        {
            _classTable = classTable;
        }

        public AnalyzeResult Analyze(object obj)
        {
            var text = obj as string;
            var analyzeResult = new LexicalAnalyzeResult(_classTable);

            if (text != null)
            {
                var lines = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < lines.Length; i++)
                {
                    var line = i + 1;
                    AnalyzeLine(lines[i], line, analyzeResult);
                }
                
            }
            return analyzeResult;
        }

        private void AnalyzeLine(string text, int line, LexicalAnalyzeResult analyzeResult)
        {
            var lexemName = String.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                var state = 1;
                var code = default(AnalyzeCode);
                while (code == default(AnalyzeCode) && i < text.Length)
                {                    
                    var character = text[i];
                    lexemName += character;
                    switch (state)
                    {
                        case 1:
                            if (_classTable.Letters.Contains(character))
                                state = 2;
                            else if (_classTable.Digits.Contains(character))
                                state = 3;
                            else if (_classTable.Minus == character)
                                state = 5;
                            else if (_classTable.Dot == character)
                                state = 6;
                            else if (_classTable.Colon == character)
                                state = 7;
                            else if (_classTable.OperationSeparator == character)
                            {
                                analyzeResult.AddLexem(line, lexemName, LexemType.OperationSeparator);
                            }
                            else if (_classTable.Operators.Contains(character))
                            {
                                analyzeResult.AddLexem(line, lexemName, LexemType.Operator);
                                code = AnalyzeCode.Accept;
                            }
                            else
                            {
                                if (character == _classTable.WhiteSpace || character == _classTable.OperationSeparator)
                                {
                                    code = AnalyzeCode.End;
                                }
                                else
                                {
                                    analyzeResult.AddError(AnalyzeErrorCode.UnknownOperator, line, 
                                        String.Format("Character {0} is not valid.", lexemName));
                                    code = AnalyzeCode.Error;
                                }
                            }
                            break;
                        case 2:
                            if (_classTable.Digits.Contains(character) || _classTable.Letters.Contains(character))
                                state = 2;
                            else
                            {
                                i--;
                                analyzeResult.AddLexem(line, lexemName.Substring(0, lexemName.Length - 1), LexemType.Identifier);
                                code = AnalyzeCode.Accept;
                            }
                            break;
                        case 3:
                            if (_classTable.Digits.Contains(character))
                                state = 3;
                            else if (_classTable.Dot == character)
                                state = 4;
                            else if (character == 'e')
                                state = 8;
                            else
                            {
                                i--;
                                analyzeResult.AddLexem(line, lexemName.Substring(0, lexemName.Length - 1), LexemType.Const);
                                code = AnalyzeCode.Accept;
                            }
                            break;
                        case 4:
                            if (_classTable.Digits.Contains(character))
                            {
                                state = 4;
                            }
                            else if (character == 'e')
                            {
                                state = 8;
                            }
                            else
                            {
                                i--;
                                analyzeResult.AddLexem(line, lexemName.Substring(0, lexemName.Length - 1), LexemType.Const);
                                code = AnalyzeCode.Accept;
                            }
                            break;
                        case 5:
                            if (_classTable.Digits.Contains(character))
                            {
                                state = 3;
                            }
                            else
                            {
                                i--;
                                analyzeResult.AddLexem(line, lexemName.Substring(0, lexemName.Length - 1), LexemType.Minus);
                                code = AnalyzeCode.Accept;
                            }
                            break;
                        case 6:
                            if (_classTable.Digits.Contains(character))
                            {
                                state = 4;
                            }
                            else
                            {
                                analyzeResult.AddError(AnalyzeErrorCode.MissedDigit, line, 
                                    String.Format("After dot need digit."));
                                code = AnalyzeCode.Error;
                            }
                            break;
                        case 7:
                            if (_classTable.Equal == character)
                            {
                                analyzeResult.AddLexem(line, lexemName, LexemType.Assigment);
                                code = AnalyzeCode.Accept;
                            }
                            else
                            {
                                i--;
                                analyzeResult.AddLexem(line, lexemName.Substring(0, lexemName.Length - 1), LexemType.Colon);
                                code = AnalyzeCode.Accept;
                            }
                            break;
                        case 8:
                            if (_classTable.Digits.Contains(character))
                            {
                                state = 3;
                            }
                            else if (_classTable.Minus == character)
                            {
                                state = 9;
                            }
                            else
                            {
                                code = AnalyzeCode.Error;
                            }
                            break;
                        case 9:
                            if (_classTable.Digits.Contains(character))
                            {
                                state = 4;
                            }
                            else
                            {
                                analyzeResult.AddError(AnalyzeErrorCode.MissedDigit, line,
                                   String.Format("After minus need digit."));
                                code = AnalyzeCode.Error;
                            }
                            break;
                    }
                    i++;
                }
                i--;
                lexemName = String.Empty;
            }
        }
    }
}
