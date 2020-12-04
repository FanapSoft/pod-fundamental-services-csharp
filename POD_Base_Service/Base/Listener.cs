using POD_Base_Service.Exception;
using POD_Base_Service.Result;
using RestSharp;

namespace POD_Base_Service.Base
{
    public static class Listener
    {
        public static void GetResult<T>(IRestResponse<ResultSrv<T>> restResponse, out ResultSrv<T> output)
        {
            output = new ResultSrv<T>();
            if (restResponse.IsSuccessful)
            {
                var resultSrv = restResponse.Data;
                if (resultSrv.HasError)
                {
                    throw PodException.BuildException(new DeveloperException(resultSrv.ErrorCode, resultSrv.Message,resultSrv));
                }

                output = resultSrv;
            }
            else
            {
                OnFailure(restResponse);
            }
        }

        public static void GetResult<T>(IRestResponse<ResultSrv<ServiceCallResultSrv<T>>> restResponse, out ResultSrv<ServiceCallResultSrv<T>> output)
        {
            output = new ResultSrv<ServiceCallResultSrv<T>>();
            if (restResponse.IsSuccessful)
            {
                var resultSrv = restResponse.Data;
                if (resultSrv.HasError)
                {
                    throw PodException.BuildException(new DeveloperException(resultSrv.ErrorCode, resultSrv.Message, resultSrv));
                }

                if (resultSrv.Result.StatusCode == 500)
                {
                    var properties = resultSrv.Result.Result.GetParentProperty();
                    var code=500;
                    var message=string.Empty;
                    if (properties != null)
                    {
                        foreach (var property in properties)
                        {
                            if (property.Name.Contains("Message"))
                            {
                                message = property.GetValue(resultSrv.Result.Result).ToString();
                                continue;
                            }

                            if (property.Name.Contains("Code"))
                            {
                                code = int.Parse(property.GetValue(resultSrv.Result.Result).ToString());
                            }
                        }
                    }

                    throw PodException.BuildException(new DeveloperException(code, message));
                }

                output = resultSrv;
            }
            else
            {
                OnFailure(restResponse);
            }
        }

        public static void GetResult<T>(IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<T>>>> restResponse, out ResultSrv<ServiceCallResultSrv<BankingSrv<T>>> output)
        {
            output = new ResultSrv<ServiceCallResultSrv<BankingSrv<T>>>();
            if (restResponse.IsSuccessful)
            {
                var resultSrv = restResponse.Data;
                if (resultSrv.HasError)
                {
                    throw PodException.BuildException(new DeveloperException(resultSrv.ErrorCode, resultSrv.Message, resultSrv));
                }

                var bankingResult = resultSrv.Result.Result as BankingSrv<T>;
                if (!bankingResult.IsSuccess)
                {
                    throw PodException.BuildException(new DeveloperException(int.Parse(bankingResult.MessageCode), bankingResult.Message, resultSrv));
                }

                output = resultSrv;
            }
            else
            {
                OnFailure(restResponse);
            }
        }

        public static void GetResult(IRestResponse<ResultSrv<ServiceCallResultSrv<PrivateCallSrv>>> restResponse, out ResultSrv<ServiceCallResultSrv<PrivateCallSrv>> output)
        {
            output = new ResultSrv<ServiceCallResultSrv<PrivateCallSrv>>();
            if (restResponse.IsSuccessful)
            {
                var responseSrv = restResponse.Data;
                if (responseSrv.HasError)
                {
                    throw PodException.BuildException(new DeveloperException(responseSrv.ErrorCode, responseSrv.Message, responseSrv));
                }

                if (responseSrv.Result.Result is PrivateCallSrv privateCallSrv && privateCallSrv.HasError)
                {
                    var resultSrv = new ResultSrv<string>()
                    {
                        HasError = privateCallSrv.HasError,
                        Message = privateCallSrv.ErrorMessage,
                        ErrorCode = privateCallSrv.ErrorCode,
                        Result = privateCallSrv.Result,
                        Count = privateCallSrv.Count,
                        Ott = responseSrv.Ott,
                        ReferenceNumber = responseSrv.ReferenceNumber
                    };
                    throw PodException.BuildException(new DeveloperException(privateCallSrv.ErrorCode, privateCallSrv.ErrorMessage, resultSrv));
                }
                output = responseSrv;
            }
            else
            {
                OnFailure(restResponse);
            }
        }

        public static void GetResult<T>(IRestResponse<ResponseSrv<T>> restResponse, out ResultSrv<T> output)
        {
            output = new ResultSrv<T>();
            if (restResponse.IsSuccessful)
            {
                var responseSrv = restResponse.Data;
                var resultSrv = new ResultSrv<T>()
                {
                    HasError = responseSrv.HasError,
                    Message = responseSrv.ErrorDescription,
                    ErrorCode = responseSrv.ErrorCode,
                    Result = responseSrv.Content,
                    Count = responseSrv.TotalCount,
                    LastUpdated = responseSrv.LastUpdated
                };

                if (resultSrv.HasError)
                {
                    throw PodException.BuildException(new DeveloperException(resultSrv.ErrorCode, resultSrv.Message, resultSrv));
                }

                output = resultSrv;
            }
            else
            {
                OnFailure(restResponse);
            }
        }

        public static void GetResult<T>(IRestResponse<T> restResponse, out T output)
        {
            if (restResponse.IsSuccessful) output = restResponse.Data;
            else
            {
                if (restResponse.ErrorException != null)
                {
                    OnFailure(restResponse);
                }

                throw PodException.BuildException(new DeveloperException((int)restResponse.StatusCode, restResponse.Content));
            }
        }

        public static void GetResult(IRestResponse restResponse, out string output)
        {
            if (restResponse.IsSuccessful) output = $"-- {(int)restResponse.StatusCode}-The operation was successful";
            else
            {
                if (restResponse.ErrorException != null)
                {
                    OnFailure(restResponse);
                }

                throw PodException.BuildException(new DeveloperException((int)restResponse.StatusCode, restResponse.Content));
            }
        }

        private static void OnFailure(IRestResponse restResponse)
        {
            if (restResponse.ResponseStatus == ResponseStatus.TimedOut || restResponse.ResponseStatus == ResponseStatus.Error)
            {
                throw PodException.BuildException(new ConnectionErrorException());
            }

            throw PodException.BuildException(new UnexpectedException());
        }
    }
}
