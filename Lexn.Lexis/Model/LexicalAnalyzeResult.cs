using System;
using System.Collections.Generic;
using System.Linq;
using Lexn.Common.Analyze;
using Lexn.Common.Model;

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

        public Identifier[] Identifiers
        {
            get { return _identifiers.ToArray(); }
        }

        public Constant[] Constants
        {
            get { return _constants.ToArray(); }
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
                var foundIdentifiers = _identifiers.Where(item => item.Type == null);
                foreach (var foundIdentifier in foundIdentifiers)
                {
                    foundIdentifier.Type = name;
                    foundIdentifier.Value = GetIdentifierDefaultValue(name);
                }
            }
            Constant constant = null;
            if (processedType == LexemType.Const)
            {
                var foundConstant = _constants.FirstOrDefault(item => item.Value == name);
                if (foundConstant != null)
                {
                    constant = foundConstant;
                }
                else
                {
                    constant = new Constant
                    {
                        ConstantID = Guid.NewGuid(),
                        Value = name
                    };
                    _constants.Add(constant);
                }
            }
            _lexems.Add(new Lexem
            {
                LexemID = Guid.NewGuid(),
                Line = line,
                Name = name,
                Priority = GetPriority(name),
                Type = processedType,
                Identifier = identifier,
                Constant = constant
            });
        }

        private int GetPriority(string name)
        {
            switch (name)
            {
                case "(":
                case "\r":
                case "if":
                case "then":
                case "writeln":
                    return 0;
                case ")":
                case "else":
                case "end":
                    return 1;
                case ":=":
                    return 2;
                case "=":
                    return 3;
                case "+":
                case "-":
                    return 4;
                case "*":
                case "/":
                    return 5;
                default:
                    return 6;
            }
        }

        private string GetIdentifierDefaultValue(string type)
        {
            switch (type)
            {
                case "decimal":
                    return "0";
                default:
                    return String.Empty;
            }
        }
    }
}
