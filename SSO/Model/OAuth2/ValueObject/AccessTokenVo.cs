using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_SSO.Model.OAuth2.ValueObject
{
    public class AccessTokenVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GrantType { get; }
        public string Code { get; }
        public string RedirectUri { get; }

        public AccessTokenVo(Builder builder)
        {
            GrantType = builder.GetGrantType();
            Code = builder.GetCode();
            RedirectUri = builder.GetRedirectUri();
        }

        public class Builder
        {
            [Required]
            private string grantType;

            [Required]
            private string code;

            [Url]
            [Required]
            private string redirectUri;

            public string GetGrantType()
            {
                return grantType;
            }

            public Builder SetGrantType(string grantType)
            {
                this.grantType = grantType;
                return this;
            }

            public string GetCode()
            {
                return code;
            }

            public Builder SetCode(string code)
            {
                this.code = code;
                return this;
            }

            public string GetRedirectUri()
            {
                return redirectUri;
            }

            public Builder SetRedirectUri(string redirectUri)
            {
                this.redirectUri = redirectUri;
                return this;
            }

            public AccessTokenVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AccessTokenVo(this);
            }
        }
    }
}
