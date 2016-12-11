using Lexn.Common;
using Lexn.Lexis.Model;

namespace Lexn.Lexis
{
    public class LexisFactory
    {
        public static IKeyWordsProvider CreateKeyWordsProvider()
        {
            return new InMemoryKeyWordsProvider();
        }

        public static IAnalyzer CreateLexicalAnalyzer()
        {
            var keyWordProvider = CreateKeyWordsProvider();
            var classTable = new ClassTable(keyWordProvider);
            return new LexicalAnalyzer(classTable);
        }
    }
}
