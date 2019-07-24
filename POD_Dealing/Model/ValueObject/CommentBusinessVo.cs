using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Dealing.Model.ValueObject
{
    public class CommentBusinessVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public string Text { get; }
        public string Token { get; }

        public CommentBusinessVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            Text = builder.GetText();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required] private long? businessId;
            [Required] private string text;
            [Required] private string token;

            public long? GetBusinessId()
            {
                return businessId;
            }

            /// <param name="businessId">شناسه کسب و کار </param>
            public Builder SetBusinessId(long businessId)
            {
                this.businessId = businessId;
                return this;
            }

            public string GetText()
            {
                return text;
            }

            public Builder SetText(string text)
            {
                this.text = text.Trim();
                return this;
            }
            public string GetToken()
            {
                return token;
            }

            /// <param name="token">توکنی که بعد از ورود به سیستم دریافت کرده اید - AccessToken</param>
            public Builder SetToken(string token)
            {
                this.token = token;
                return this;
            }

            public CommentBusinessVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new CommentBusinessVo(this);
            }
        }
    }
}
