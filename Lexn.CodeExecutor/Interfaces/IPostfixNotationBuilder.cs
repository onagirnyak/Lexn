using System.Collections.Generic;
using Lexn.Common.Model;

namespace Lexn.CodeExecutor.Interfaces
{
    public interface IPostfixNotationBuilder
    {
        List<Lexem> Build(List<Lexem> lexems);
    }
}
