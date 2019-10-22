using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using POD_Base_Service.Base;
using POD_Base_Service.Result;
using POD_Notification.Base;
using POD_Notification.Model.ServiceOutput;
using POD_Notification.Model.ValueObject;
using RestSharp;

namespace POD_Notification
{
    public class NotificationService
    {
        private string baseAddress = "http://172.16.110.40:8017/v2/service/";

        public void SendSms(SmsVo smsVo, Action<IRestResponse<ResponseSrv<SmsSrv>>> callback)
        {
            var url = $"{baseAddress}sms";
            PrepareRestClient(url, smsVo,Method.POST, out var client, out var request);
            callback(client.Execute<ResponseSrv<SmsSrv>>(request));
        }

        public void GetSmsStatus(SmsStatusVo smsStatusVo, Action<IRestResponse<ResponseSrv<SmsStatusSrv>>> callback)
        {
            var url = $"{baseAddress}sms/status/{smsStatusVo.NotificationMessageId}";
            PrepareRestClient<SmsStatusVo>(url, null,Method.GET, out var client, out var request);
            request.AddHeader(nameof(smsStatusVo.Token).GetPodName(), smsStatusVo.Token);
            callback(client.Execute<ResponseSrv<SmsStatusSrv>>(request));
        }

        public void SendValidationSms(ValidationSmsVo validationSmsVo, Action<IRestResponse<ResponseSrv<ValidationSmsSrv>>> callback)
        {
            var url = $"http://172.16.0.249:8017/v2/service/validationSms";
            PrepareRestClient(url, validationSmsVo,Method.POST, out var client, out var request);
            callback(client.Execute<ResponseSrv<ValidationSmsSrv>>(request));
        }

        public void GetValidationSmsStatus(ValidationSmsStatusVo validationSmsStatusVo, Action<IRestResponse<ResponseSrv<ValidationSmsStatusSrv>>> callback)
        {
            var url = $"{baseAddress}validationSms/status/{validationSmsStatusVo.MessageId}";
            PrepareRestClient<ValidationSmsStatusVo>(url, null,Method.GET, out var client, out var request);
            request.AddHeader(nameof(validationSmsStatusVo.Token).GetPodName(), validationSmsStatusVo.Token);
            callback(client.Execute<ResponseSrv<ValidationSmsStatusSrv>>(request));
        }
        public void GetSmsList(SmsListVo smsListVo, Action<IRestResponse<ResponseSrv<List<SmsListSrv>>>> callback)
        {
            var url = $"{baseAddress}sms";
            PrepareRestClient(url, smsListVo,Method.GET, out var client, out var request);
            callback(client.Execute<ResponseSrv<List<SmsListSrv>>>(request));
        }
        public void SendEmail(EmailVo emailVo, Action<IRestResponse<ResponseSrv<SmsSrv>>> callback)
        {
            var url = $"{baseAddress}mail";
            PrepareRestClient(url, emailVo, Method.POST, out var client, out var request);
            callback(client.Execute<ResponseSrv<SmsSrv>>(request));
        }

        public void GetEmailList(EmailListVo emailListVo, Action<IRestResponse<ResponseSrv<List<EmailListSrv>>>> callback)
        {
            var url = $"{baseAddress}mail";
            PrepareRestClient(url, emailListVo, Method.GET, out var client, out var request);
            callback(client.Execute<ResponseSrv<List<EmailListSrv>>>(request));
        }
        public void SendPushNotification(PushNotificationByPeerIdVo pushNotificationByPeerIdVo, Action<IRestResponse<ResponseSrv<SmsSrv>>> callback)
        {
            var url = $"{baseAddress}pushNotification";
            PrepareRestClient(url, pushNotificationByPeerIdVo, Method.POST, out var client, out var request);
            callback(client.Execute<ResponseSrv<SmsSrv>>(request));
        }
        public void SendPushNotification(PushNotificationByAppIdVo pushNotificationByAppIdVo, Action<IRestResponse<ResponseSrv<SmsSrv>>> callback)
        {
            var url = $"{baseAddress}pushNotification/appId";
            PrepareRestClient(url, pushNotificationByAppIdVo, Method.POST, out var client, out var request);
            callback(client.Execute<ResponseSrv<SmsSrv>>(request));
        }
        public void GetPushNotificationStatus(PushNotificationStatusVo pushNotificationStatusVo, Action<IRestResponse<ResponseSrv<SmsStatusSrv>>> callback)
        {
            var url = $"{baseAddress}pushNotification/status/{pushNotificationStatusVo.StatusType.ToString()}/{pushNotificationStatusVo.MessageId}";
            PrepareRestClient<PushNotificationStatusVo>(url, null, Method.GET, out var client, out var request);
            request.AddHeader(nameof(pushNotificationStatusVo.Token).GetPodName(), pushNotificationStatusVo.Token);
            callback(client.Execute<ResponseSrv<SmsStatusSrv>>(request));
        }
        public void GetPushNotificationList(PushNotificationListVo pushNotificationListVo, Action<IRestResponse<ResponseSrv<List<PushNotificationListSrv>>>> callback)
        {
            var url = $"{baseAddress}pushNotification";
            PrepareRestClient(url, pushNotificationListVo, Method.GET, out var client, out var request);
            callback(client.Execute<ResponseSrv<List<PushNotificationListSrv>>>(request));
        }

        private void PrepareRestClient<T>(string url, T objectVo,Method method, out RestClient client, out RestRequest request)
        {
            client = new RestClient(url);
            request = new RestRequest(method);
            if (objectVo != null)
            {
                PrepareParameters(objectVo, request,method);
            }
        }

        private void PrepareParameters<T>(T objectVo, IRestRequest request,Method method)
        {
            if (method == Method.POST)
            {
                var parameters = objectVo.ToDictionaryHierachy(PodParameterName.ParametersName);
                var token = parameters.FirstOrDefault(_ => _.Key.Equals("apiToken"));
                request.AddHeader(token.Key, token.Value.ToString());
                parameters.Remove(token.Key);
                var jasonString = JsonConvert.SerializeObject(parameters, Formatting.Indented);
                request.AddParameter("application/json", jasonString, ParameterType.RequestBody);
            }
            else
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                var parameters = objectVo.FilterNotNull(PodParameterName.ParametersName);
                if (parameters == null) return;
                foreach (var parameter in parameters)
                {
                    if (parameter.Key.Equals("apiToken"))
                    {
                        request.AddHeader(parameter.Key, parameter.Value);
                    }
                    else request.AddParameter(parameter.Key, parameter.Value);
                }
            }
        }
    }
}
