using System;

namespace Lexn.Lexis.Model
{
    public class Lexem
    {
        public Guid LexemID { get; set; }

        public int Line { get; set; }

        public string Name { get; set; }

        public LexemType Type { get; set; }

        public Identifier Identifier { get; set; }

        public Constant Constant { get; set; }

    }
}
