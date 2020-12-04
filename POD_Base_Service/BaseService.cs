using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using RestSharp;

namespace POD_Base_Service
{
    public static class BaseService
    {
        public static void GetGuildList(GuildListVo guildListVo,
            Action<IRestResponse<ResultSrv<List<GuildSrv>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetGuildList, guildListVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<GuildSrv>>>(request));
        }

        public static void GetCurrencyList(InternalServiceCallVo tokenVo,
            Action<IRestResponse<ResultSrv<List<GuildSrv>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetCurrencyList, tokenVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<GuildSrv>>>(request));
        }

        public static void GetOtt(InternalServiceCallVo tokenVo, Action<IRestResponse<ResultSrv<string>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetOtt, tokenVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }

        public static void AddTagTreeCategory(AddTagTreeCategoryVo addTagTreeCategoryVo,
            Action<IRestResponse<ResultSrv<TagTreeCategorySrv>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.AddTagTreeCategory, addTagTreeCategoryVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<TagTreeCategorySrv>>(request));
        }

        public static void GetTagTreeCategoryList(GetTagTreeCategoryListVo getTagTreeCategoryListVo,
            Action<IRestResponse<ResultSrv<List<TagTreeCategorySrv>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetTagTreeCategoryList, getTagTreeCategoryListVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<TagTreeCategorySrv>>>(request));
        }

        public static void UpdateTagTreeCategory(UpdateTagTreeCategoryVo updateTagTreeCategoryVo,
            Action<IRestResponse<ResultSrv<TagTreeCategorySrv>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.UpdateTagTreeCategory, updateTagTreeCategoryVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<TagTreeCategorySrv>>(request));
        }

        public static void AddTagTree(AddTagTreeVo addTagTreeVo, Action<IRestResponse<ResultSrv<TagTreeSrv>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.AddTagTree, addTagTreeVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<TagTreeSrv>>(request));
        }

        public static void GetTagTreeList(GetTagTreeListVo getTagTreeListVo,
            Action<IRestResponse<ResultSrv<List<TagTreeSrv>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetTagTreeList, getTagTreeListVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<TagTreeSrv>>>(request));
        }

        public static void UpdateTagTree(UpdateTagTreeVo updateTagTreeVo,
            Action<IRestResponse<ResultSrv<TagTreeSrv>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.UpdateTagTree, updateTagTreeVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<TagTreeSrv>>(request));
        }

        public static void PrepareRestClient<T>(long entityId, T objectVo, Dictionary<string, string> podParameterName,
            out RestClient client, out RestRequest request,bool ignoreNullValue=true)
        {
            client = new RestClient(BaseUrl.ServiceCallAddress);
            request = new RestRequest(Method.GET);
            request.AddHeader(nameof(Config.TokenIssuer).GetPodName(), Config.TokenIssuer.ToString())
                   .AddParameter("scProductId", entityId);
            PrepareParameters(objectVo, request, podParameterName,ignoreNullValue);
        }

        private static void PrepareParameters<T>(T objectVo, IRestRequest request,
            Dictionary<string, string> podParameterName,bool ignoreNullValue=true)
        {
            var parameters = objectVo.FilterNotNull(podParameterName,ignoreNullValue);
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
