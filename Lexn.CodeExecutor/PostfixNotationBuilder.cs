using System.Collections.Generic;
using Lexn.CodeExecutor.Interfaces;
using Lexn.Common.Model;

namespace Lexn.CodeExecutor
{
    internal class PostfixNotationBuilder : IPostfixNotationBuilder
    {
        public List<Lexem> Build(List<Lexem> lexems)
        {
            var outputSeparated = new List<Lexem>();
            var stack = new Stack<Lexem>();
            foreach (var lexem in lexems)
            {
                if (lexem.Type == LexemType.Operator 
                    || lexem.Type == LexemType.Assigment 
                    || lexem.Type == LexemType.OperationSeparator
                    || lexem.Type == LexemType.Keyword)
                {
                    if (stack.Count > 0 && !lexem.Name.Equals("("))
                    {
                        if (lexem.Name.Equals(")"))
                        {
                            var stackLexem = stack.Pop();
                            while (stackLexem.Name != "(")
                            {
                                outputSeparated.Add(stackLexem);
                                stackLexem = stack.Pop();
                            }
                        }
                        else if (lexem.Priority > stack.Peek().Priority)
                        {
                            stack.Push(lexem);
                        }
                        else
                        {
                            while (stack.Count > 0 && lexem.Priority <= stack.Peek().Priority)
                            {
                                var stackLexem = stack.Pop();
                                if (stackLexem.Type != LexemType.OperationSeparator)
                                {
                                    outputSeparated.Add(stackLexem);
                                }
                            }

                            if (lexem.Type != LexemType.OperationSeparator)
                            {
                                stack.Push(lexem);
                            }
                        }
                    }
                    else
                    {
                        stack.Push(lexem);
                    }
                }
                else
                {
                    outputSeparated.Add(lexem);
                }
            }
            if (stack.Count > 0)
            {
                foreach (var stackLexem in stack)
                {
                    outputSeparated.Add(stackLexem);
                }
            }
            return outputSeparated;
        }
    }
}
