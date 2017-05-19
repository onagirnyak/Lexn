using Lexn.Common;
using Lexn.Common.Interfaces;

namespace Lexn.Lexis.Model
{
    public class ClassTable
    {
        public char[] Digits { get; private set; }
        public char[] Letters { get; private set; }
        public char[] Operators { get; private set; }

        public char Dot { get; private set; }
        public char Minus { get; private set; }
        public char Equal { get; private set; }
        public char Colon { get; private set; }
        public char WhiteSpace { get; private set; }
        public char OperationSeparator { get; private set; }

        public string[] KeyWords;
        public string[] SystemDataTypes;

        public ClassTable(IKeyWordsProvider keyWordsProvider)
        {
            KeyWords = keyWordsProvider.GetKeyWords();
            SystemDataTypes = keyWordsProvider.GetSystemDataTypes();
            Digits = "0123456789".ToCharArray();
            Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Operators = ",+*/()=".ToCharArray();
            Dot = '.';
            Minus = '-';
            Equal = '=';
            Colon = ':';
            WhiteSpace = ' ';
            OperationSeparator = '\r';
        }
    }

}
