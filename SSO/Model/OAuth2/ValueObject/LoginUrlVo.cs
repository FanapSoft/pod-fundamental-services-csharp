using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_SSO.Base;
using POD_SSO.Base.Enum;

namespace POD_SSO.Model.OAuth2.ValueObject
{
    public class LoginUrlVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string ClientId { get; }
        public string ResponseType { get; }
        public string RedirectUri { get; }
        public string Scope { get; }

        public LoginUrlVo(Builder builder)
        {
            ClientId = builder.GetClientId();
            ResponseType = builder.GetResponseType();
            RedirectUri = builder.GetRedirectUri();
            Scope = builder.GetScope();
        }

        public class Builder
        {
            [Required]
            private string clientId;

            [Required]
            private string responseType;

            [Url]
            private string redirectUri;
            private string scope;

            public string GetClientId()
            {
                return clientId;
            }
            public Builder SetClientId(string clientId)
            {
                this.clientId = clientId;
                return this;
            }
            public string GetResponseType()
            {
                return responseType;
            }

            /// <summary>
            ///  استفاده نمایید “token” یا “id_token” و برای اپلیکیشن های موبایل از , “code” برای احرازهویت در اپلیکیشن های وب از
            /// </summary>
            public Builder SetResponseType(ResponseType responseType)
            {
                this.responseType = responseType.ToString();
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
            public string GetScope()
            {
                return scope;
            }

            public Builder SetScope(ScopeType[] scope)
            {
                this.scope = string.Join(" ", scope);
                return this;
            }

            public LoginUrlVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new LoginUrlVo(this);
            }
        }

        public string GetLink()
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/authorize/?{nameof(ClientId).GetPodName()}={ClientId}&{nameof(ResponseType).GetPodName()}={ResponseType}";
            if (!string.IsNullOrEmpty(RedirectUri)) url += $"&{nameof(RedirectUri).GetPodName()}={RedirectUri}";
            if (!string.IsNullOrEmpty(Scope)) url += $"&{nameof(Scope).GetPodName()}={Scope}";
            return url;
        }
    }
}
