using System;
using System.Collections.Generic;
using System.Linq;
using Lexn.Common;

namespace Lexn.Lexis.Model
{
    public class LexicalAnalyzeResult : AnalyzeResult
    {
        private readonly ClassTable _classTable;

        private readonly List<Lexem> _lexems;

        private readonly List<Identifier> _identifiers;

        private readonly List<Constant> _constants;

        public Lexem[] Lexems
        {
            get { return _lexems.ToArray(); }
        }

        public LexicalAnalyzeResult(ClassTable classTable)
        {
            _classTable = classTable;
            _lexems = new List<Lexem>();
            _identifiers = new List<Identifier>();
            _constants = new List<Constant>();
        }

        public void AddLexem(int line, string name, LexemType type)
        {
            var processedType = type;
            if (_classTable.KeyWords.Contains(name))
            {
                processedType = LexemType.Keyword;
            }
            if (_classTable.SystemDataTypes.Contains(name))
            {
                processedType = LexemType.SystemDataType;
            }
            Identifier identifier = null;
            if (processedType == LexemType.Identifier)
            {
                var foundIdentifier = _identifiers.FirstOrDefault(item => item.Name == name);
                if (foundIdentifier != null)
                {
                    identifier = foundIdentifier;
                }
                else
                {
                    identifier = new Identifier
                    {
                        IdentifierID = Guid.NewGuid(),
                        Name = name
                    };
                    _identifiers.Add(identifier);
                }
            }
            if (processedType == LexemType.SystemDataType)
            {
                var foundIdentifier = _identifiers.LastOrDefault();
                if (foundIdentifier != null)
                {
                    foundIdentifier.Type = name;
                }
            }
            _lexems.Add(new Lexem
            {
                LexemID = Guid.NewGuid(),
                Line = line,
                Name = name,
                Type = processedType,
                Identifier = identifier
            });
        }
    }
}
