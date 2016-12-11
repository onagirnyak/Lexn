using Lexn.Common;
using Lexn.Lexis.Model;

namespace Lexn.Lexis
{
    public class LexisFactory
    {
        public static IAnalyzer CreateLexicalAnalyzer()
        {
            var keyWordProvider = CommonFactory.CreateKeyWordsProvider();
            var classTable = new ClassTable(keyWordProvider);
            return new LexicalAnalyzer(classTable);
        }
    }
}
