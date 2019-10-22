using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Result;
using POD_Notification;
using POD_Notification.Base.Enum;
using POD_Notification.Model.ServiceOutput;
using POD_Notification.Model.ValueObject;

namespace Demo
{
    public class NotificationMethodInvoke
    {
        private readonly NotificationService notificationService;
        private string apiToken = "";
        public NotificationMethodInvoke()
        {
            notificationService = new NotificationService();
        }
        public ResultSrv<SmsSrv> SendSms()
        {
            try
            {
                var output = new ResultSrv<SmsSrv>();
                var smsVo = SmsVo.ConcreteBuilder
                    .SetToken(apiToken)
                    .SetContent(SmsContentVo.ConcreteBuilder
                        .SetBody("Hellllooooo")
                        .SetMobileNumbers(new []{""})
                        .SetScheduler(new DateTime(2019,08,18,9,52,0))
                        .Build())
                    //.SetServiceName("")
                    .Build();
                notificationService.SendSms(smsVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<SmsStatusSrv> GetSmsStatus()
        {
            try
            {
                var output = new ResultSrv<SmsStatusSrv>();
                var smsStatusVo = SmsStatusVo.ConcreteBuilder
                    .SetToken(apiToken)
                    .SetNotificationMessageId("87f9fbd8-36d3-4777-9a2b-706a2d48882f")
                    .Build();
                notificationService.GetSmsStatus(smsStatusVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ValidationSmsSrv> SendValidationSms()
        {
            try
            {
                var output = new ResultSrv<ValidationSmsSrv>();
                var validationSmsVo = ValidationSmsVo.ConcreteBuilder
                    .SetToken("")
                    .SetContent(ValidationSmsContentVo.ConcreteBuilder
                        .SetToken1("Helloo")
                        .SetReceptor("")
                        .SetTemplate("testTemplate")
                        //.SetToken2("Hi")
                        //.SetToken3("")
                        //.SetType("")
                        .Build())
                    .Build();
                notificationService.SendValidationSms(validationSmsVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ValidationSmsStatusSrv> GetValidationSmsStatus()
        {
            try
            {
                var output = new ResultSrv<ValidationSmsStatusSrv>();
                var validationSmsStatusVo = ValidationSmsStatusVo.ConcreteBuilder
                    .SetToken(apiToken)
                    .SetMessageId(757190395)
                    .Build();
                notificationService.GetValidationSmsStatus(validationSmsStatusVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<SmsListSrv>> GetSmsList()
        {
            try
            {
                var output = new ResultSrv<List<SmsListSrv>>();
                var smsListVo = SmsListVo.ConcreteBuilder
                    .SetToken(apiToken)
                    //.SetOffset(0)
                    //.SetSize(0)
                    .SetFilter(SmsFilterField.message)
                    .SetFilterValue("Hellllooooo")
                    .SetOrder(OrderType.desc)
                    .SetOrderBy(SmsOrderField.id)
                    .Build();
                notificationService.GetSmsList(smsListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<SmsSrv> SendEmail()
        {
            try
            {
                var output = new ResultSrv<SmsSrv>();
                var emailVo = EmailVo.ConcreteBuilder
                    .SetToken(apiToken)
                    .SetContent(EmailContentVo.ConcreteBuilder
                        .SetTo(new []{"anvarinadia@gmail.com"})
                        //.SetReplyAddress("nadiaanvari@yahoo.com")
                        //.SetBody("Hellllooooo")
                        //.SetSubject("test")
                        //.SetCc(new []{""})
                        //.SetBcc(new []{""})
                        //.SetFileHashes(new []{""})
                        //.SetScheduler(new DateTime(2019, 08, 25, 13, 40, 0))
                        .Build())
                    //.SetServiceName("test")
                    .Build();
                notificationService.SendEmail(emailVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<EmailListSrv>> GetEmailList()
        {
            try
            {
                var output = new ResultSrv<List<EmailListSrv>>();
                var emailListVo = EmailListVo.ConcreteBuilder
                    .SetToken(apiToken)
                    //.SetOffset(0)
                    //.SetSize(0)
                    .SetFilter(EmailFilterField.subject)
                    .SetFilterValue("test")
                    .SetOrder(OrderType.desc)
                    .SetOrderBy(EmailOrderField.id)
                    .Build();
                notificationService.GetEmailList(emailListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<SmsSrv> SendPushNotificationByPeerId()
        {
            try
            {
                var output = new ResultSrv<SmsSrv>();
                var pushNotificationByPeerIdVo = PushNotificationByPeerIdVo.ConcreteBuilder
                    .SetToken(apiToken)
                    .SetContent(PushNotificationByPeerIdContentVo.ConcreteBuilder
                        .SetPeerId(new long[]{0})
                        //.SetTitle("")
                        //.SetText("")
                        //.SetExtraData("")
                        //.SetScheduler(new DateTime(2019, 08, 25, 13, 40, 0))
                        .Build())
                    .Build();
                notificationService.SendPushNotification(pushNotificationByPeerIdVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<SmsSrv> SendPushNotificationByAppId()
        {
            try
            {
                var output = new ResultSrv<SmsSrv>();
                var pushNotificationByAppIdVo = PushNotificationByAppIdVo.ConcreteBuilder
                    .SetToken(apiToken)
                    .SetContent(PushNotificationByAppIdContentVo.ConcreteBuilder
                        .SetAppId("")
                        //.SetTitle("")
                        //.SetText("")
                        //.SetScheduler(new DateTime(2019, 08, 25, 13, 40, 0))
                        .Build())
                    .Build();
                notificationService.SendPushNotification(pushNotificationByAppIdVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<SmsStatusSrv> GetPushNotificationStatus()
        {
            try
            {
                var output = new ResultSrv<SmsStatusSrv>();
                var pushNotificationStatusVo = PushNotificationStatusVo.ConcreteBuilder
                    .SetToken(apiToken)
                    .SetMessageId("b7d1c809-5eed-47f7-943a-a341e55df9f7")
                    .SetStatusType(StatusType.all)
                    .Build();
                notificationService.GetPushNotificationStatus(pushNotificationStatusVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<List<PushNotificationListSrv>> GetPushNotificationList()
        {
            try
            {
                var output = new ResultSrv<List<PushNotificationListSrv>>();
                var pushNotificationListVo = PushNotificationListVo.ConcreteBuilder
                    .SetToken(apiToken)
                    //.SetOffset(0)
                    //.SetSize(0)
                    //.SetFilter(NotificationFilterField.subject)
                    //.SetFilterValue("test")
                    //.SetOrder(OrderType.desc)
                    //.SetOrderBy(NotificationOrderField.id)
                    .Build();
                notificationService.GetPushNotificationList(pushNotificationListVo, response => Listener.GetResult(response, out output));
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
