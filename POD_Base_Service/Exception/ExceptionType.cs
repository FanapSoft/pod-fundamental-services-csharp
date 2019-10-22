using System;
using System.Collections.Generic;
using POD_Base_Service.Result;

namespace POD_Base_Service.Exception
{
    public struct InvalidParameter : IExceptionType
    {
        public int Code => PodExceptionConsts.InvalidParameterCode;
        public string Message { get; }
        public IResultSrv OriginalResult => null;
        public InvalidParameter(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            Message = $"{PodExceptionConsts.InvalidParameterMessage} :{Environment.NewLine} "+ " {"+ string.Join($" {Environment.NewLine} ", parameters)+ " }";
        }
        public InvalidParameter(KeyValuePair<string, string> parameters)
        {
            Message = $"{PodExceptionConsts.InvalidParameterMessage} :{Environment.NewLine} " + " {" + string.Join($" {Environment.NewLine} ", parameters) + " }";
        }
    }
    public struct UnexpectedException : IExceptionType
    {
        public int Code => PodExceptionConsts.UnexpectedErrorCode;
        public string Message => PodExceptionConsts.UnexpectedErrorMessage;
        public IResultSrv OriginalResult => null;
    }
    public struct ConnectionErrorException : IExceptionType
    {
        public int Code => PodExceptionConsts.ConnectionErrorCode;
        public string Message => PodExceptionConsts.ConnectionErrorMessage;
        public IResultSrv OriginalResult => null;
    }
    public struct DeveloperException : IExceptionType
    {
        public int Code { get; }
        public string Message { get; }
        public IResultSrv OriginalResult { get; }
        public DeveloperException(int code, string message)
        {
            Code = code;
            Message = message;
            OriginalResult = null;
        }
        public DeveloperException(int code, string message,IResultSrv resultSrv)
        {
            Code = code;
            Message = message;
            OriginalResult = resultSrv;
        }
    }
}
