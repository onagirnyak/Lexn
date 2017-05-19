using Lexn.Common.Interfaces;

namespace Lexn.Common
{
    internal class KeyWordsProvider : IKeyWordsProvider
    {
        public string[] GetKeyWords()
        {
            return new string[]
            {
                "program", "var", "decimal", "begin", "for", "to", "do", "begin", "end", "writeln", "readln", "if",
                "then", "else"
            };
        }

        public string[] GetSystemDataTypes()
        {
            return new string[]
            {
                "decimal"
            };
        }
    }
}
