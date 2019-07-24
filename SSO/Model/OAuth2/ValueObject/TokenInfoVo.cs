using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_SSO.Base.Enum;

namespace POD_SSO.Model.OAuth2.ValueObject
{
    public class TokenInfoVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public TokenType? TokenTypeHint { get; }     
        public string Token { get; }

        public TokenInfoVo(Builder builder)
        {
            TokenTypeHint = builder.GetTokenTypeHint();
            Token = builder.GetToken();
        }

        public class Builder
        {
            [Required]
            private TokenType? tokenTypeHint;

            [Required]            
            private string token;

            public TokenType? GetTokenTypeHint()
            {
                return tokenTypeHint;
            }
            public Builder SetTokenTypeHint(TokenType tokenTypeHint)
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

            public TokenInfoVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new TokenInfoVo(this);
            }
        }
    }
}
