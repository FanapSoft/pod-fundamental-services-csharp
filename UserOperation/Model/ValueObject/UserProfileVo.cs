using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_UserOperation.Model.ValueObject
{
    public class UserProfileVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string Token { get; }
        public UserProfileVo(Builder builder)
        {
            ClientId = builder.GetClientId();
            ClientSecret = builder.GetClientSecret();
            Token = builder.GetToken();
        }

        public class Builder
        {
            private string clientId;
            private string clientSecret;

            [Required]
            private string token;

            public string GetClientId()
            {
                return clientId;
            }
            public Builder SetClientId(string clientId)
            {
                this.clientId = clientId;
                return this;
            }
            public string GetClientSecret()
            {
                return clientSecret;
            }
            public Builder SetClientSecret(string clientSecret)
            {
                this.clientSecret = clientSecret;
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

            public UserProfileVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UserProfileVo(this);
            }
        }
    }
}
