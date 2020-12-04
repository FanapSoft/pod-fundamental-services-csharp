using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using POD_Base_Service.Base;
using POD_Base_Service.Result;
using POD_Notification.Base;
using POD_Notification.Base.Enum;
using POD_Notification.Model.ServiceOutput;
using POD_Notification.Model.ValueObject;
using RestSharp;

namespace POD_Notification
{
    public static class NotificationService
    {
        public static void SendSms(SmsVo smsVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.SendSms, smsVo, Method.POST, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>>(request));
        }

        public static void GetSmsStatus(SmsStatusVo smsStatusVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsStatusSrv>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetSmsStatus, smsStatusVo, Method.GET, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsStatusSrv>>>>(request));
        }

        public static void SendValidationSms(ValidationSmsVo validationSmsVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<ValidationSmsSrv>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.SendValidationSms, validationSmsVo,Method.POST, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<ValidationSmsSrv>>>>(request));
        }

        public static void GetValidationSmsStatus(ValidationSmsStatusVo validationSmsStatusVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<ValidationSmsStatusSrv>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetValidationSmsStatus, validationSmsStatusVo, Method.GET, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<ValidationSmsStatusSrv>>>>(request));
        }
        public static void GetSmsList(SmsListVo smsListVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<List<SmsListSrv>>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetSmsList, smsListVo,Method.GET, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<List<SmsListSrv>>>>>(request));
        }
        public static void SendEmail(EmailVo emailVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.SendEmail, emailVo, Method.POST, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>>(request));
        }
        public static void GetEmailList(EmailListVo emailListVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<List<EmailListSrv>>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetEmailList, emailListVo, Method.GET, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<List<EmailListSrv>>>>>(request));
        }
        public static void GetEmailInfo(EmailInfoVo emailInfoVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<List<EmailListSrv>>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetEmailInfo, emailInfoVo, Method.GET, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<List<EmailListSrv>>>>>(request));
        }
        public static void SendPushNotification(PushNotificationByPeerIdVo pushNotificationByPeerIdVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.PushNotificationByPeerId, pushNotificationByPeerIdVo, Method.POST, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>>(request));
        }
        public static void SendPushNotification(PushNotificationByAppIdVo pushNotificationByAppIdVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.PushNotificationByAppId, pushNotificationByAppIdVo, Method.POST, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>>(request));
        }
        public static void GetPushNotificationStatus(PushNotificationStatusVo pushNotificationStatusVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsStatusSrv>>>>> callback)
        {
            long productId;
            if (pushNotificationStatusVo.StatusType == StatusType.received)
                productId = ServiceCallProducts.GetPushNotificationStatusReceived;
            else if (pushNotificationStatusVo.StatusType == StatusType.seen)
                productId = ServiceCallProducts.GetPushNotificationStatusSeen;
            else
                productId = ServiceCallProducts.GetPushNotificationStatusAll;

            PrepareRestClient(productId, pushNotificationStatusVo, Method.GET, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsStatusSrv>>>>(request));
        }
        public static void GetPushNotificationList(PushNotificationListVo pushNotificationListVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<ResponseSrv<List<PushNotificationListSrv>>>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.GetPushNotificationList, pushNotificationListVo, Method.GET, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<ResponseSrv<List<PushNotificationListSrv>>>>>(request));
        }

        private static void PrepareRestClient<T>(long entityId, T objectVo,Method method, out RestClient client, out RestRequest request)
        {
            client = new RestClient(BaseUrl.ServiceCallAddress);
            request = new RestRequest(Method.GET);
            request.AddHeader(nameof(Config.TokenIssuer).GetPodName(), Config.TokenIssuer.ToString())
                   .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                   .AddParameter("scProductId", entityId);

            PrepareParameters(objectVo, request, method);
        }

        private static void PrepareParameters<T>(T objectVo, IRestRequest request,Method method)
        {
            if (method == Method.POST)
            {
                var parameters = objectVo.ToDictionaryHierachy(PodParameterName.ParametersName);
                var apiToken = parameters.FirstOrDefault(_ => _.Key.Equals("apiToken"));
                request.AddHeader(apiToken.Key, apiToken.Value.ToString());
                parameters.Remove(apiToken.Key);

                var serviceCallParameters = parameters.FirstOrDefault(_ => _.Key.Equals("serviceCallParameters")).Value as Dictionary<string,object>;
                foreach (var parameter in serviceCallParameters)
                {
                    if (parameter.Key.Equals("_token_"))
                    {
                        request.AddHeader(parameter.Key, parameter.Value?.ToString());
                    }
                    else request.AddParameter(parameter.Key, parameter.Value);
                }
                parameters.Remove("serviceCallParameters");

                var jasonString = JsonConvert.SerializeObject(parameters, Formatting.Indented);
                request.AddParameter("body", jasonString);
            }
            else
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                var parameters = objectVo.FilterNotNull(PodParameterName.ParametersName);
                if (parameters == null) return;
                foreach (var parameter in parameters)
                {
                    if (parameter.Key.Equals("apiToken") || parameter.Key.Equals("_token_"))
                    {
                        request.AddHeader(parameter.Key, parameter.Value);
                    }
                    else request.AddParameter(parameter.Key, parameter.Value);
                }
               
            }
        }
    }
}
