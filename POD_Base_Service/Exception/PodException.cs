using POD_Base_Service.Base;

namespace POD_Base_Service.Exception
{
    public class PodException : System.Exception
    {
        public int Code { get; }
        public IResultSrv OriginalResult { get; }
        public PodException() : base() { }
        public PodException(string message) : base(message) { }
        public PodException(string message, System.Exception inner) : base(message, inner) { }

        private PodException(IExceptionType exception) : base(exception.Message)
        {
            Code = exception.Code;
            OriginalResult = exception.OriginalResult;
        }

        public static PodException BuildException(IExceptionType exception)
        {
            return new PodException(exception);
        }   
    }
  

}

