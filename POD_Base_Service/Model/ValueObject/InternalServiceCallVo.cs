using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Base_Service.Model.ValueObject
{
    public class InternalServiceCallVo
    {
        public static Builder ConcreteBuilder => new Builder();

        public string[] ScVoucherHash { get; set; }
        public string Token { get; set; }
        public string ScApiKey { get; set; }

        public InternalServiceCallVo(Builder builder)
        {
            ScApiKey = builder.GetScApiKey();
            ScVoucherHash = builder.GetScVoucherHash();
            Token = builder.GetToken();
        }

        public class Builder
        {
            private string[] scVoucherHash;
            [Required] private string token;
            private string scApiKey;

            public string[] GetScVoucherHash()
            {
                return scVoucherHash;
            }

            public Builder SetScVoucherHash(string[] scVoucherHash)
            {
                this.scVoucherHash = scVoucherHash;
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
            public string GetScApiKey()
            {
                return scApiKey;
            }

            public Builder SetScApiKey(string scApiKey)
            {
                this.scApiKey = scApiKey;
                return this;
            }

            public InternalServiceCallVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new InternalServiceCallVo(this);
            }
        }
    }
}
