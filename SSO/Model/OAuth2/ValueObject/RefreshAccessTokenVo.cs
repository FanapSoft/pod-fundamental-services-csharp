using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

 namespace POD_SSO.Model.OAuth2.ValueObject
{
    public class RefreshAccessTokenVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string GrantType { get; }
        public string RefreshToken { get; }

        public RefreshAccessTokenVo(Builder builder)
        {
            GrantType = builder.GetGrantType();
            RefreshToken = builder.GetRefreshToken();
        }
        public class Builder
        {
            [Required]
            private string grantType;

            [Required]
            private string refreshToken;

            public string GetGrantType()
            {
                return grantType;
            }

            /// <param name="grantType">Value must be refresh_token</param>
            public Builder SetGrantType(string grantType)
            {               
                this.grantType = grantType;
                return this;
            }
            public string GetRefreshToken()
            {
                return refreshToken;
            }
            public Builder SetRefreshToken(string refreshToken)
            {               
                this.refreshToken = refreshToken;
                return this;
            }

            public RefreshAccessTokenVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RefreshAccessTokenVo(this);
            }
        }
    }
}
