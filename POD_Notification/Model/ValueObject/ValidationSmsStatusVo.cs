using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Notification.Model.ValueObject
{
    public class ValidationSmsStatusVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? MessageId { get; }
        public string Token { get; }

        public ValidationSmsStatusVo(Builder builder)
        {
            MessageId = builder.GetMessageId();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private long? messageId;

            [Required]
            private string token;

            public long? GetMessageId()
            {
                return messageId;
            }

            /// <param name="messageId">شناسه پیامک ارسال شده</param>
            public Builder SetMessageId(long messageId)
            {
                this.messageId = messageId;
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
            public ValidationSmsStatusVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ValidationSmsStatusVo(this);
            }
        }
    }
}
