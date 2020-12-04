using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Notification.Base.Enum;

namespace POD_Notification.Model.ValueObject
{
    public class PushNotificationStatusVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string MessageId { get; }
        public StatusType? StatusType { get; }
        public string ApiToken { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PushNotificationStatusVo(Builder builder)
        {
            MessageId = builder.GetMessageId();
            StatusType = builder.GetStatusType();
            ApiToken = builder.GetApiToken();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder           
        {
            [Required] private string messageId;
            [Required] private StatusType? statusType;
            [Required] private string apiToken;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetMessageId()
            {
                return messageId;
            }

            /// <param name="messageId">شناسه پیامک ارسال شده</param>
            public Builder SetMessageId(string messageId)
            {
                this.messageId = messageId;
                return this;
            }
            public StatusType? GetStatusType()
            {
                return statusType;
            }

            public Builder SetStatusType(StatusType statusType)
            {
                this.statusType = statusType;
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

            public PushNotificationStatusVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PushNotificationStatusVo(this);
            }
        }
    }
}
