using System;

namespace Lexn.Lexis.Model
{
    public class Operator
    {
        public Guid OperatorID { get; set; }

        public string Value { get; set; }

        public int Priority { get; set; }
    }
}
