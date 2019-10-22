using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class ValidationSmsVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public ValidationSmsContentVo Content { get; }
        public string Token { get; }

        public ValidationSmsVo(Builder builder)
        {
            Content = builder.GetContent();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private ValidationSmsContentVo content;

            [Required]
            private string token;

            public ValidationSmsContentVo GetContent()
            {
                return content;
            }

            public Builder SetContent(ValidationSmsContentVo content)
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
            public ValidationSmsVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ValidationSmsVo(this);
            }
        }
    }
}
