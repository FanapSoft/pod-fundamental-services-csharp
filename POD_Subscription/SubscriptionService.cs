using System;
using System.Collections.Generic;
using POD_Base_Service;
using POD_Base_Service.Result;
using POD_Subscription.Base;
using POD_Subscription.Model.ServiceOutput;
using POD_Subscription.Model.ValueObject;
using RestSharp;

namespace POD_Subscription
{
    public static class SubscriptionService
    {
        public static void AddSubscriptionPlan(AddSubscriptionPlanVo addSubscriptionPlanVo,
            Action<IRestResponse<ResultSrv<SubscriptionPlanSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.AddSubscriptionPlan, addSubscriptionPlanVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<SubscriptionPlanSrv>>(request));
        }

        public static void SubscriptionPlanList(SubscriptionPlanListVo subscriptionPlanListVo,
            Action<IRestResponse<ResultSrv<List<SubscriptionPlanSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.SubscriptionPlanList, subscriptionPlanListVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<SubscriptionPlanSrv>>>(request));
        }

        public static void UpdateSubscriptionPlan(UpdateSubscriptionPlanVo updateSubscriptionPlanVo,
            Action<IRestResponse<ResultSrv<SubscriptionPlanSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.UpdateSubscriptionPlan, updateSubscriptionPlanVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<SubscriptionPlanSrv>>(request));
        }

        public static void RequestSubscription(RequestSubscriptionVo requestSubscriptionVo,
            Action<IRestResponse<ResultSrv<SubscriptionSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.RequestSubscription, requestSubscriptionVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<SubscriptionSrv>>(request));
        }

        public static void ConfirmSubscription(ConfirmSubscriptionVo confirmSubscriptionVo,
            Action<IRestResponse<ResultSrv<SubscriptionSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ConfirmSubscription, confirmSubscriptionVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<SubscriptionSrv>>(request));
        }

        public static void SubscriptionList(SubscriptionListVo subscriptionListVo,
            Action<IRestResponse<ResultSrv<List<SubscriptionFullSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.SubscriptionList, subscriptionListVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<SubscriptionFullSrv>>>(request));
        }

        public static void ConsumeSubscription(ConsumeSubscriptionVo consumeSubscriptionVo,
            Action<IRestResponse<ResultSrv<SubscriptionSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ConsumeSubscription, consumeSubscriptionVo, PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<SubscriptionSrv>>(request));
        }
    }
}
