using POD_Base_Service.Exception;
using RestSharp;

namespace POD_Base_Service.Base
{
    public static class Listener
    {
        public static void GetResult<T>(IRestResponse<ResultSrv<T>> restResponse, out ResultSrv<T> output)
        {
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
                if (restResponse.ResponseStatus == ResponseStatus.TimedOut || restResponse.ResponseStatus == ResponseStatus.Error)
                {
                    throw PodException.BuildException(new ConnectionErrorException());
                }

                throw PodException.BuildException(new UnexpectedException());
            }
        }
        public static void GetResult<T>(IRestResponse<T> restResponse, out T output)
        {
            if (restResponse.IsSuccessful) output = restResponse.Data;
            else
            {
                if (restResponse.ErrorException != null)
                {
                    throw PodException.BuildException(new UnexpectedException());
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
                    throw PodException.BuildException(new UnexpectedException());
                }

                throw PodException.BuildException(new DeveloperException((int)restResponse.StatusCode, restResponse.Content));
            }
        }
    }
}
