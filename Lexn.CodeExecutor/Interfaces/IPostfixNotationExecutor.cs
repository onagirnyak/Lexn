using System;
using System.Collections.Generic;
using Lexn.Common.Model;

namespace Lexn.CodeExecutor.Interfaces
{
    public interface IPostfixNotationExecutor
    {
        List<string> Execute(List<Lexem> lexems, Func<string, string> input);
    }
}
