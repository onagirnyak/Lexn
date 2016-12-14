using System;
using Lexn.Common;
using Lexn.Syntax.Grammar;

namespace Lexn.Syntax
{
    public static class SyntaxFactory
    {
        public static IGrammarItem CreateGrammarItem(GrammarItemType type)
        {
            var identifier = new IdentifierGrammarItem();
            var constant = new ConstantGrammarItem();
            var multiplayer = new MultiplayerGrammarItem(identifier, constant);
            var additional = new AdditionalGrammarItem(multiplayer);
            var statement = new StatementGrammarItem(additional);
            var identifierList= new IdentifierListGrammarItem(identifier);
            var operation = new OperationGrammarItem(identifierList, identifierList, statement);
            var operatorList = new OperationListGrammarItem(operation);
            
            switch (type)
            {
                case GrammarItemType.Root:
                    return new ProgramGrammarItem(identifier, identifierList, operatorList);
                case GrammarItemType.IdentifierList:
                    return identifierList;
                case GrammarItemType.OperatorList:
                    return operatorList;
                case GrammarItemType.Multiplayer:
                    return multiplayer;
                case GrammarItemType.Statement:
                    return statement;
                case GrammarItemType.Constant:
                    return constant;
                case GrammarItemType.Identifier:
                    return identifier;
                default:
                    throw new NotImplementedException("Provided grammar item is not implemented yet.");
            }
        }

        public static IAnalyzer CreateSyntaxAnalyzer()
        {
            var rootGrammarItem = CreateGrammarItem(GrammarItemType.Root);
            return new SyntaxisAnalyzer(rootGrammarItem);
        }
    }
}
