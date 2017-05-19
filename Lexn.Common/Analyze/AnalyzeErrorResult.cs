namespace Lexn.Common.Analyze
{
    public class AnalyzeErrorResult
    {
        public AnalyzeErrorCode Code { get; set; }

        public int Line { get; set; }

        public string Message { get; set; }
    }
}
