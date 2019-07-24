using System;
using System.Collections.Generic;
using System.Linq;
using POD_Base_Service.Base;
using POD_Dealing.Base;
using POD_Dealing.Model.ServiceOutput;
using POD_Dealing.Model.ValueObject;
using RestSharp;

namespace POD_Dealing
{
    public class DealingService
    {
        public void AddUserAndBusiness(AddUserAndBusinessVo addUserAndBusinessVo, Action<IRestResponse<ResultSrv<BusinessSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/addUserAndBusiness";
            PrepareRestClient(url, addUserAndBusinessVo, out var client, out var request);
            callback(client.Execute<ResultSrv<BusinessSrv>>(request));
        }
        public void GuildList(GuildListVo guildListVo, Action<IRestResponse<ResultSrv<List<GuildSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/guildList";
            PrepareRestClient(url, guildListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<GuildSrv>>>(request));
        }
        public void ListUserCreatedBusiness(ListUserCreatedBusinessVo listUserCreatedBusinessVo, Action<IRestResponse<ResultSrv<List<BusinessSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/listUserCreatedBusiness";
            PrepareRestClient(url, listUserCreatedBusinessVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<BusinessSrv>>>(request));
        }

        /// <summary>
        /// توجه داشته باشید، بجز مقداردهی پارامترهای اجباری کلاس ورودی ,که عدم ثبت آنها منجر به خطا خواهد شد، عدم مقداردهی سایر موارد منجر به پاک شدن مقدار قبلی می گردد
        /// </summary>
        public void UpdateBusiness(UpdateBusinessVo updateBusinessVo, Action<IRestResponse<ResultSrv<BusinessSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/updateBusiness";
            PrepareRestClient(url, updateBusinessVo, out var client, out var request);
            callback(client.Execute<ResultSrv<BusinessSrv>>(request));
        }
        public void GetApiTokenForCreatedBusiness(GetApiTokenForCreatedBusinessVo getApiTokenForCreatedBusinessVo, Action<IRestResponse<ResultSrv<BusinessApiTokenSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/getApiTokenForCreatedBusiness";
            PrepareRestClient(url, getApiTokenForCreatedBusinessVo, out var client, out var request);
            callback(client.Execute<ResultSrv<BusinessApiTokenSrv>>(request));
        }
        public void RateBusiness(RateBusinessVo rateBusinessVo, Action<IRestResponse<ResultSrv<RateSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/rateBusiness";
            PrepareRestClient(url, rateBusinessVo, out var client, out var request);
            callback(client.Execute<ResultSrv<RateSrv>>(request));
        }
        public void CommentBusiness(CommentBusinessVo commentBusinessVo, Action<IRestResponse<ResultSrv<long>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/commentBusiness";
            PrepareRestClient(url, commentBusinessVo, out var client, out var request);
            callback(client.Execute<ResultSrv<long>>(request));
        }
        public void BusinessFavorite(BusinessFavoriteVo businessFavoriteVo, Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/businessFavorite";
            PrepareRestClient(url, businessFavoriteVo, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }
        public void UserBusinessInfos(UserBusinessInfosVo userBusinessInfosVo, Action<IRestResponse<ResultSrv<List<UserBusinessInfoSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/userBusinessInfos";
            PrepareRestClient(url, userBusinessInfosVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<UserBusinessInfoSrv>>>(request));
        }
        public void CommentBusinessList(CommentBusinessListVo commentBusinessListVo, Action<IRestResponse<ResultSrv<List<CommentSrv>>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/commentBusinessList";
            PrepareRestClient(url, commentBusinessListVo, out var client, out var request);
            callback(client.Execute<ResultSrv<List<CommentSrv>>>(request));
        }
        public void ConfirmComment(ConfirmCommentVo confirmCommentVo, Action<IRestResponse<ResultSrv<CommentSrv>>> callback)
        {
            var url = $"{BaseUrl.PlatformAddress}/nzh/biz/confirmComment";
            PrepareRestClient(url, confirmCommentVo, out var client, out var request);
            callback(client.Execute<ResultSrv<CommentSrv>>(request));
        }
        private void PrepareRestClient<T>(string url, T objectVo, out RestClient client, out RestRequest request)
        {
            client = new RestClient(url);
            request = new RestRequest(Method.GET);         
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
