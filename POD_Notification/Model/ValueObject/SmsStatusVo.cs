using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class SmsStatusVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string NotificationMessageId { get; }
        public string Token { get; }

        public SmsStatusVo(Builder builder)
        {
            NotificationMessageId = builder.GetNotificationMessageId();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private string notificationMessageId;

            [Required]
            private string token;

            public string GetNotificationMessageId()
            {
                return notificationMessageId;
            }

            /// <param name="notificationMessageId">شناسه پیامک ارسال شده</param>
            public Builder SetNotificationMessageId(string notificationMessageId)
            {
                this.notificationMessageId =notificationMessageId;
                return this;
            }
            public string GetToken()
            {
                return token;
            }

            /// <param name="token">AccessToken Or ApiToken         
            /// توکنی که بعد از ورود به سیستم یا از پنل کسب و کار دریافت شده است
            /// </param>
            public Builder SetToken(string token)
            {
                this.token = token;
                return this;
            }
            public SmsStatusVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SmsStatusVo(this);
            }
        }
    }
}
