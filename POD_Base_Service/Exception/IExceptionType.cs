using POD_Base_Service.Base;

namespace POD_Base_Service.Exception
{
    public interface IExceptionType
    {
        int Code { get; }
        string Message { get; }
        IResultSrv OriginalResult { get; }
    }
}
