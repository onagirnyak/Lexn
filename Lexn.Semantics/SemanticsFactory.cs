using Lexn.Common;
using Lexn.Lexis;

namespace Lexn.Semantics
{
    public class SemanticsFactory
    {
        public static IAnalyzer CreateSemanticsAnalyzer()
        {
            var keyWordsProvider = CommonFactory.CreateKeyWordsProvider();
            return new SemanticalAnalyzer(keyWordsProvider);
        }
    }
}
