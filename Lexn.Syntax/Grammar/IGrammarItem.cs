using Lexn.Syntax.Model;

namespace Lexn.Syntax
{
    public interface IGrammarItem
    {
        void Parse(SyntaxisAnalyzeResult analyzeResult);
    }
}