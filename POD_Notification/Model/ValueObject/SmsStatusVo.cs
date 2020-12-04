using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Notification.Model.ValueObject
{
    public class SmsStatusVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string NotificationMessageId { get; }
        public string ApiToken { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public SmsStatusVo(Builder builder)
        {
            NotificationMessageId = builder.GetNotificationMessageId();
            ApiToken = builder.GetApiToken();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string notificationMessageId;

            [Required]
            private string apiToken;

            [Required] private InternalServiceCallVo serviceCallParameters;

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
            public string GetApiToken()
            {
                return apiToken;
            }

            /// <param name="apiToken">AccessApiToken Or ApiApiToken         
            /// توکنی که بعد از ورود به سیستم یا از پنل کسب و کار دریافت شده است
            /// </param>
            public Builder SetApiToken(string apiToken)
            {
                this.apiToken = apiToken;
                return this;
            }
            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
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
