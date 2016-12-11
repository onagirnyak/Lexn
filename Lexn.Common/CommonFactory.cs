namespace Lexn.Common
{
    public class CommonFactory
    {
        public static IKeyWordsProvider CreateKeyWordsProvider()
        {
            return new InMemoryKeyWordsProvider();
        }

    }
}
