using Lexn.Common.Interfaces;

namespace Lexn.Common
{
    public class CommonFactory
    {
        public static IKeyWordsProvider CreateKeyWordsProvider()
        {
            return new KeyWordsProvider();
        }

    }
}
