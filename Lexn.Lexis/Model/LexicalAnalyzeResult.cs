using System;
using System.Collections.Generic;
using System.Linq;
using Lexn.Common;

namespace Lexn.Lexis.Model
{
    public class LexicalAnalyzeResult : AnalyzeResult
    {
        private readonly ClassTable _classTable;

        public LexicalAnalyzeResult(ClassTable classTable)
        {
            _classTable = classTable;
            _lexems = new List<Lexem>();
            _identifiers = new List<Identifier>();
            _constants = new List<Constant>();
        }

        private List<Lexem> _lexems;

        private List<Identifier> _identifiers;

        private List<Constant> _constants;

        public Lexem[] Lexems
        {
            get { return _lexems.ToArray(); }
            set { _lexems = value.ToList(); }
        }

        public void AddLexem(int line, string name, LexemType type)
        {
            var processedType = type;
            if (_classTable.KeyWords.Contains(name))
            {
                processedType = LexemType.Keyword;
            }
            _lexems.Add(new Lexem
            {
                LexemID = Guid.NewGuid(),
                Line = line,
                Name = name,
                Type = processedType
            });
        }
    }
}
