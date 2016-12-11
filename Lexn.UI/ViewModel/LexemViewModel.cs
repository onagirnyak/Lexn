using System;
using Lexn.Lexis.Model;

namespace Lexn.UI
{
    public class LexemViewModel
    {
        public LexemViewModel()
        {
        }

        public Guid LexemID { get; set; }

        public int Line { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
