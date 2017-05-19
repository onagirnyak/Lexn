using Lexn.Common.Analyze;

namespace Lexn.Common.Interfaces
{
    public interface IAnalyzer
    {
        AnalyzeResult Analyze(object obj);
    }
}