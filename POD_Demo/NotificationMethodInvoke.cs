using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_Notification;
using POD_Notification.Base.Enum;
using POD_Notification.Model.ServiceOutput;
using POD_Notification.Model.ValueObject;

namespace POD_Demo
{
    public class NotificationMethodInvoke
    {
        private string apiToken = "";
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>> SendSms()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>();
                var smsVo = SmsVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetContent(SmsContentVo.ConcreteBuilder
                        .SetBody("Hellllooooo")
                        .SetMobileNumbers(new[] { "" })
                        //.SetScheduler(new DateTime(2019,08,18,9,52,0))
                        .Build())
                    //.SetServiceName("")
                    .Build();
                NotificationService.SendSms(smsVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsStatusSrv>>> GetSmsStatus()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsStatusSrv>>>();
                var smsStatusVo = SmsStatusVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetNotificationMessageId("bf8ca1e9-9322-414b-bca1-a286f3f4c75e")
                    .Build();
                NotificationService.GetSmsStatus(smsStatusVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<ValidationSmsSrv>>> SendValidationSms()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<ValidationSmsSrv>>>();
                var validationSmsVo = ValidationSmsVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetContent(ValidationSmsContentVo.ConcreteBuilder
                        .SetToken1("Helloo")
                        .SetReceptor("")
                        .SetTemplate("testTemplate")
                        //.SetToken2("Hi")
                        //.SetToken3("")
                        //.SetType("")
                        .Build())
                    .Build();
                NotificationService.SendValidationSms(validationSmsVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<ValidationSmsStatusSrv>>> GetValidationSmsStatus()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<ValidationSmsStatusSrv>>>();
                var validationSmsStatusVo = ValidationSmsStatusVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetMessageId(0)
                    .Build();
                NotificationService.GetValidationSmsStatus(validationSmsStatusVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<List<SmsListSrv>>>> GetSmsList()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<List<SmsListSrv>>>>();
                var smsListVo = SmsListVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    //.SetOffset(0)
                    //.SetSize(0)
                    //.SetFilter(SmsFilterField.message)
                    //.SetFilterValue("Hellllooooo")
                    //.SetOrder(OrderType.desc)
                    //.SetOrderBy(SmsOrderField.id)
                    .Build();
                NotificationService.GetSmsList(smsListVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>> SendEmail()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>();
                var emailVo = EmailVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetContent(EmailContentVo.ConcreteBuilder
                        .SetTo(new[] { "" })
                        //.SetReplyAddress("")
                        //.SetBody("Hellllooooo")
                        //.SetSubject("test")
                        //.SetCc(new []{""})
                        //.SetBcc(new []{""})
                        //.SetFileHashes(new []{""})
                        //.SetScheduler(new DateTime(2019, 08, 25, 13, 40, 0))
                        .Build())
                    //.SetServiceName("test")
                    .Build();
                NotificationService.SendEmail(emailVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<List<EmailListSrv>>>> GetEmailList()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<List<EmailListSrv>>>>();
                var emailListVo = EmailListVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    //.SetOffset(0)
                    //.SetSize(0)
                    //.SetFilter(EmailFilterField.subject)
                    //.SetFilterValue("test")
                    //.SetOrder(OrderType.desc)
                    //.SetOrderBy(EmailOrderField.id)
                    .Build();
                NotificationService.GetEmailList(emailListVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<List<EmailListSrv>>>> GetEmailInfo()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<List<EmailListSrv>>>>();
                var emailInfoVo = EmailInfoVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetMessageId("9b137f8b-2369-487b-8b8b-5b5c8ba1da78")
                    .Build();
                NotificationService.GetEmailInfo(emailInfoVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>> SendPushNotificationByPeerId()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>();
                var pushNotificationByPeerIdVo = PushNotificationByPeerIdVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetContent(PushNotificationByPeerIdContentVo.ConcreteBuilder
                        .SetPeerId(new long[] { 0 })
                        //.SetTitle("")
                        //.SetText("")
                        //.SetExtraData("")
                        //.SetScheduler(new DateTime(2019, 08, 25, 13, 40, 0))
                        .Build())
                    .Build();
                NotificationService.SendPushNotification(pushNotificationByPeerIdVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>> SendPushNotificationByAppId()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsSrv>>>();
                var pushNotificationByAppIdVo = PushNotificationByAppIdVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetContent(PushNotificationByAppIdContentVo.ConcreteBuilder
                        .SetAppId("")
                        //.SetTitle("")
                        //.SetText("")
                        //.SetScheduler(new DateTime(2019, 08, 25, 13, 40, 0))
                        .Build())
                    .Build();
                NotificationService.SendPushNotification(pushNotificationByAppIdVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsStatusSrv>>> GetPushNotificationStatus()
        {
            try
            {               
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<SmsStatusSrv>>>();
                var pushNotificationStatusVo = PushNotificationStatusVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    .SetMessageId("b7d1c809-5eed-47f7-943a-a341e55df9f7")
                    .SetStatusType(StatusType.all)
                    .Build();
                NotificationService.GetPushNotificationStatus(pushNotificationStatusVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<ResponseSrv<List<PushNotificationListSrv>>>> GetPushNotificationList()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ResponseSrv<List<PushNotificationListSrv>>>>();
                var pushNotificationListVo = PushNotificationListVo.ConcreteBuilder
                    .SetServiceCallParameters(InternalServiceCallVo.ConcreteBuilder.SetToken(apiToken).SetScApiKey("").Build())
                    .SetApiToken(apiToken)
                    //.SetOffset(0)
                    //.SetSize(0)
                    //.SetFilter(NotificationFilterField.subject)
                    //.SetFilterValue("test")
                    //.SetOrder(OrderType.desc)
                    //.SetOrderBy(NotificationOrderField.id)
                    .Build();
                NotificationService.GetPushNotificationList(pushNotificationListVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
