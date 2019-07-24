using System;
using POD_Base_Service.Base;
using POD_UserOperation.Base;
using POD_UserOperation.Model.ServiceOutput;
using POD_UserOperation.Model.ValueObject;
using RestSharp;

namespace POD_UserOperation
{
    public static class UserOperationService
    {
        public static void GetUserProfile(UserProfileVo userProfileVo, Action<IRestResponse<ResultSrv<CustomerProfileSrv>>> callback)
        {
            var url= $"{BaseUrl.PlatformAddress}/nzh/getUserProfile";
            PrepareRestClient(url,userProfileVo, out var client, out var request,Method.GET);
            callback(client.Execute<ResultSrv<CustomerProfileSrv>>(request));
        }

        /// <summary>
        /// در صورتی که هر یک از فیلدهای کلاس ورودی که اسکوپ خواندن آن را داشته اید ارسال نشود و یا خالی ارسال شود، مقدار آن در پروفایل کاربر خالی می شود
        /// </summary>      
        public static void EditProfileWithConfirmation(EditProfileWithConfirmationVo editProfileWithConfirmationVo, Action<IRestResponse<ResultSrv<CustomerProfileSrv>>> callback)
        {
            var url= $"{BaseUrl.PlatformAddress}/nzh/editProfileWithConfirmation";
            PrepareRestClient(url,editProfileWithConfirmationVo, out var client, out var request,Method.POST);
            callback(client.Execute<ResultSrv<CustomerProfileSrv>>(request));
        }

        private static void PrepareRestClient<T>(string url, T objectVo, out RestClient client, out RestRequest request,Method method)
        {
            client = new RestClient(url);
            request = new RestRequest(method);          
            request.AddHeader(nameof(Config.TokenIssuer).GetPodName(), Config.TokenIssuer.ToString());
            PrepareParameters(objectVo, request);
        }

        private static void PrepareParameters<T>(T objectVo, IRestRequest request)
        {
            var parameters = objectVo.FilterNotNull(PodParameterName.ParametersName);
            if (parameters == null) return;
            foreach (var parameter in parameters)
            {
                if (parameter.Key.Equals("_token_"))
                {
                    request.AddHeader(parameter.Key, parameter.Value);
                }
                else request.AddParameter(parameter.Key, parameter.Value);
            }
        }
    }
}
