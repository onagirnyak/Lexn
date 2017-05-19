using Lexn.CodeExecutor.Interfaces;

namespace Lexn.CodeExecutor
{
    public class CodeExecutorFactory
    {
        public static IPostfixNotationBuilder CreatePostfixNotationBuilder()
        {
            return new PostfixNotationBuilder();
        }

        public static IPostfixNotationExecutor CreateIPostfixNotationExecutor()
        {
            return new PostfixNotationExecutor();
        }
    }
}
