using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Notification.Model.ValueObject
{
    public class PushNotificationByPeerIdVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public PushNotificationByPeerIdContentVo Content { get; }
        public string ApiToken { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public PushNotificationByPeerIdVo(Builder builder)
        {
            Content = builder.GetContent();
            ApiToken = builder.GetApiToken();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private PushNotificationByPeerIdContentVo content;

            [Required]
            private string apiToken;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public PushNotificationByPeerIdContentVo GetContent()
            {
                return content;
            }

            /// <param name="content">اطلاعات مورد نیاز برای ارسال پیام</param>
            public Builder SetContent(PushNotificationByPeerIdContentVo content)
            {
                this.content = content;
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

            public PushNotificationByPeerIdVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PushNotificationByPeerIdVo(this);
            }
        }
    }
}
