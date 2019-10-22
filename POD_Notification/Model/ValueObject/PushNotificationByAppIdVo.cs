using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class PushNotificationByAppIdVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public PushNotificationByAppIdContentVo Content { get; }
        public string Token { get; }

        public PushNotificationByAppIdVo(Builder builder)
        {
            Content = builder.GetContent();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private PushNotificationByAppIdContentVo content;

            [Required]
            private string token;

            public PushNotificationByAppIdContentVo GetContent()
            {
                return content;
            }

            /// <param name="content">اطلاعات مورد نیاز برای ارسال پیام</param>
            public Builder SetContent(PushNotificationByAppIdContentVo content)
            {
                this.content = content;
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
            public PushNotificationByAppIdVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new PushNotificationByAppIdVo(this);
            }
        }
    }
}
