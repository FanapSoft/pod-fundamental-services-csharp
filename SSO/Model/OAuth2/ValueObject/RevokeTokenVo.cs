using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_SSO.Base.Enum;

namespace POD_SSO.Model.OAuth2.ValueObject
{
    public class RevokeTokenVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public RevokeTokenType? TokenTypeHint { get; }
        public string Token { get; }

        public RevokeTokenVo(Builder builder)
        {
            TokenTypeHint = builder.GetTokenTypeHint();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private RevokeTokenType? tokenTypeHint;

            [Required]
            private string token;

            public RevokeTokenType? GetTokenTypeHint()
            {
                return tokenTypeHint;
            }
            public Builder SetTokenTypeHint(RevokeTokenType tokenTypeHint)
            {
                this.tokenTypeHint = tokenTypeHint;               
                return this;
            }
            public string GetToken()
            {
                return token;
            }
            public Builder SetToken(string token)
            {               
                this.token = token;
                return this;
            }
            public RevokeTokenVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RevokeTokenVo(this);
            }
        }
    }
}
