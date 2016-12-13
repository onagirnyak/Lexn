namespace Lexn.Common
{
    internal class InMemoryKeyWordsProvider : IKeyWordsProvider
    {
        public string[] GetKeyWords()
        {
            return new string[]
            {
                "program", "var", "decimal", "string", "begin", "for", "to", "do", "begin", "end", "writeln", "readln", "if",
                "then", "else"
            };
        }

        public string[] GetSystemDataTypes()
        {
            return new string[]
            {
                "decimal", "string"
            };
        }
    }
}
