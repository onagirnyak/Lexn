﻿using System.Linq;
using Lexn.Common;
using Lexn.Lexis.Model;
using Lexn.Syntax.Model;

namespace Lexn.Syntax.Grammar
{
    internal class IdentifierListGrammarItem : IGrammarItem
    {
        private readonly IGrammarItem _identifierGrammarItem;

        public IdentifierListGrammarItem(IGrammarItem identifierGrammarItem)
        {
            _identifierGrammarItem = identifierGrammarItem;
        }

        public void Parse(SyntaxisAnalyzeResult analyzeResult)
        {
            _identifierGrammarItem.Parse(analyzeResult);
            if (!analyzeResult.IsValid)
            {
                return;
            }
            while (analyzeResult.Lexems.Dequeue().Name == ",")
            {
                _identifierGrammarItem.Parse(analyzeResult);
                if (!analyzeResult.IsValid)
                {
                    return;
                }
            }
        }
    }
}
