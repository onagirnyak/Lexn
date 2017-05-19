using System;
using System.Collections.Generic;
using System.Linq;
using Lexn.CodeExecutor.Interfaces;
using Lexn.Common.Model;

namespace Lexn.CodeExecutor
{
    internal class PostfixNotationExecutor : IPostfixNotationExecutor
    {
        public List<string> Execute(List<Lexem> lexems, Func<string, string> input)
        {
            var stack = new Stack<Lexem>();
            var queue = new Queue<Lexem>(lexems);
            var lexem = queue.Dequeue();
            var output = new List<string>();

            while (queue.Count >= 0)
            {
                if (lexem.Type != LexemType.Operator 
                    && lexem.Type != LexemType.Assigment
                    && lexem.Type != LexemType.Keyword)
                {
                    stack.Push(lexem);
                    lexem = queue.Dequeue();
                }
                else
                {
                    
                    Lexem result = null;

                    switch (lexem.Name)
                    {
                        case "+":
                        {
                            var left = GetValue(stack.Pop());
                            var right = GetValue(stack.Pop());
                            result = ConvertResult(left + right);
                            break;
                        }
                        case "-":
                        {
                            var left = GetValue(stack.Pop());
                            var right = GetValue(stack.Pop());
                            result = ConvertResult(right - left);
                            break;
                        }
                        case "*":
                        {
                            var left = GetValue(stack.Pop());
                            var right = GetValue(stack.Pop());
                            result = ConvertResult(right * left);
                            break;
                        }
                        case "/":
                        {
                            var left = GetValue(stack.Pop());
                            var right = GetValue(stack.Pop());
                            result = ConvertResult(left / right);
                            break;
                        }
                        case ":=":
                        {
                            var left = GetValue(stack.Pop());
                            var right = stack.Pop();
                            right.Identifier.Value = left.ToString();
                            result = right;
                            break;
                        }
                        case "=":
                        {
                            var left = GetValue(stack.Pop());
                            var right = GetValue(stack.Pop());
                            var isEqual = left == right;
                            result = ConvertResult(isEqual ? 1 : 0);
                            break;
                        }
                        case "if":
                        {
                            var left = GetValue(stack.Pop());
                            var isEqual = left != 0;
                            if (isEqual)
                            {
                                var list = queue.ToList();
                                var from = list.FindIndex(item => item.Name == "else");
                                var to = list.FindLastIndex(item => item.Name == "end");
                                list.RemoveRange(from, to - from);
                                queue = new Queue<Lexem>(list);
                            }
                            else
                            {
                                var list = queue.ToList();
                                var from = list.FindIndex(item => item.Name == "then");
                                var to = list.FindLastIndex(item => item.Name == "else");
                                list.RemoveRange(from, to - from);
                                queue = new Queue<Lexem>(list);
                            }
                            break;
                        }
                        case "writeln":
                        {
                            var left = GetValue(stack.Pop());
                            output.Add(left.ToString());
                            break;
                        }
                        case "readln":
                        {
                            var left = stack.Pop();
                            if (left.Identifier != null)
                            {
                                left.Identifier.Value = input(left.Name);
                            }
                            break;
                        }
                    }
                    if (result != null)
                    {
                        stack.Push(result);
                    }
                    if (queue.Count > 0)
                    {
                        lexem = queue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return output;
        }

        private decimal GetValue(Lexem lexem)
        {
            if (lexem.Type == LexemType.Const)
            {
                return Decimal.Parse(lexem.Name);
            }
            else if(lexem.Type == LexemType.Identifier)
            {
                return Decimal.Parse(lexem.Identifier.Value);
            }

            return 0;
        }

        private Lexem ConvertResult(decimal result)
        {
            return new Lexem
            {
                LexemID = Guid.NewGuid(),
                Constant = new Constant
                {
                    ConstantID = Guid.NewGuid(),
                    Value = result.ToString()
                },
                Name = result.ToString(),
                Type = LexemType.Const
            };
        }
    }
}
