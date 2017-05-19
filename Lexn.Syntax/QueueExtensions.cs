using System;
using System.Collections.Generic;
using Lexn.Common.Model;

namespace Lexn.Syntax
{ 
    public static class QueueExtensions
    {
        public static Lexem Dequeue(this Queue<Lexem> lexems, bool igonoreSeparators)
        {
            if (igonoreSeparators)
            {
                while (lexems.Peek().Type == LexemType.OperationSeparator)
                {
                    lexems.Dequeue();
                }
            }
            return lexems.Dequeue();
        }
    }
}
