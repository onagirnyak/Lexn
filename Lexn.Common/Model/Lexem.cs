using System;

namespace Lexn.Common.Model
{
    public class Lexem
    {
        public Guid LexemID { get; set; }

        public int Line { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public LexemType Type { get; set; }

        public Identifier Identifier { get; set; }

        public Constant Constant { get; set; }

    }
}
