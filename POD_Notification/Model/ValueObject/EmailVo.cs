using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class EmailVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public EmailContentVo Content { get; }
        public string ServiceName { get; }
        public string Token { get; }

        public EmailVo(Builder builder)
        {
            Content = builder.GetContent();
            ServiceName = builder.GetServiceName();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private EmailContentVo content;

            private string serviceName;

            [Required]
            private string token;

            public EmailContentVo GetContent()
            {
                return content;
            }

            /// <param name="content">اطلاعات مورد نیاز برای ارسال پیام</param>
            public Builder SetContent(EmailContentVo content)
            {
                this.content = content;
                return this;
            }
            public string GetServiceName()
            {
                return serviceName;
            }

            /// <param name="serviceName">نام سرویسی که قصد ارسال پیامک از طریق آن را دارید وارد نمایید. در صورت وارد نکردن این فیلد، سرویس پیش ­فرض در نظرگرفته خواهد شد.</param>
            public Builder SetServiceName(string serviceName)
            {
                this.serviceName = serviceName;
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
            public EmailVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new EmailVo(this);
            }
        }
    }
}
