using System.Collections.Generic;
using System.Linq;

namespace Lexn.Common
{
    public abstract class AnalyzeResult
    {
       
        private readonly List<AnalyzeErrorResult> _errors;

        protected AnalyzeResult()
        {
            _errors = new List<AnalyzeErrorResult>();
        }

        public bool IsValid
        {
            get { return !Errors.Any(); }
        }

        public IReadOnlyCollection<AnalyzeErrorResult> Errors
        {
            get { return _errors; }
        }

        public void AddError(AnalyzeErrorCode code, int line, string message)
        {
            _errors.Add(new AnalyzeErrorResult
            {
                Code = code,
                Line = line, 
                Message = message
            });
        }
    }
}
