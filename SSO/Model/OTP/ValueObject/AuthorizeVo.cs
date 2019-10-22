using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_SSO.Base.Enum;

namespace POD_SSO.Model.OTP.ValueObject
{
    public class AuthorizeVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string ResponseType { get; }
        public string State { get; }
        public ReferrerType? ReferrerType { get; }
        public string Referrer { get; }
        public string Authorization { get; }
        public string IdentityType { get; }
        public string LoginAsUserId { get; }
        public string ClientId { get; }
        public string RedirectUri { get; }
        public string CallbackUri { get; }
        public string Scope { get; }
        public string CodeChallenge { get; }
        public string CodeChallengeMethod { get; }
        public string Identity { get; }

        public AuthorizeVo(Builder builder)
        {
            ResponseType = builder.GetResponseType();
            State = builder.GetState();
            ReferrerType = builder.GetReferrerType();
            Referrer = builder.GetReferrer();
            Authorization = builder.GetAuthorization();
            IdentityType = builder.GetIdentityType();
            LoginAsUserId = builder.GetLoginAsUserId();
            ClientId = builder.GetClientId();
            RedirectUri = builder.GetRedirectUri();
            CallbackUri = builder.GetCallbackUri();
            Scope = builder.GetScope();
            CodeChallenge = builder.GetCodeChallenge();
            CodeChallengeMethod = builder.GetCodeChallengeMethod();
            Identity = builder.GetIdentity();
        }

        public class Builder
        {
            [Required]
            private string identity;

            [Required]
            private string authorization;

            [Required]
            private string responseType;
            private string state;
            private ReferrerType? referrerType;
            private string referrer;
            private string identityType;
            private string loginAsUserId;
            private string clientId;

            [Url]
            private string redirectUri;

            [Url]
            private string callbackUri;
            private string scope;
            private string codeChallenge;
            private string codeChallengeMethod;

            public string GetIdentity()
            {
                return identity;
            }

            /// <param name="identity">شماره تلفن و یا ایمیل کاربر</param>
            public Builder SetIdentity(string identity)
            {
                this.identity = identity;
                return this;
            }
            public string GetAuthorization()
            {
                return authorization;
            }
            public Builder SetAuthorization(string keyId, string privateKey)
            {
                var header = "host";
                var dataToSign = "host: accounts.pod.land";
                //if (signType == SignType.HostDate)
                //{
                //    header += " date";
                //    dataToSign += Environment.NewLine + DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToLongTimeString()+ " GMT+0430";
                //}

                var signature = dataToSign.GetSignature(privateKey, HashAlgorithmName.SHA256);
                authorization = $"Signature keyId = \"{keyId}\", signature = \"{signature}\", headers = \"{header}\"";
                return this;
            }
            public string GetResponseType()
            {
                return responseType;
            }
            public Builder SetResponseType(string responseType)
            {
                this.responseType = responseType;
                return this;
            }
            public string GetState()
            {
                return state;
            }

            /// <param name="state">آن را دریافت خواهید کرد Verify در صورت ارسال، در پاسخ سرویس</param>
            public Builder SetState(string state)
            {
                this.state = state;
                return this;
            }
            public ReferrerType? GetReferrerType()
            {
                return referrerType;
            }

            public Builder SetReferrerType(ReferrerType referrerType)
            {
                this.referrerType = referrerType;
                return this;
            }
            public string GetReferrer()
            {
                return referrer;
            }

            public Builder SetReferrer(string referrer)
            {
                this.referrer = referrer;
                return this;
            }
            public string GetIdentityType()
            {
                return identityType;
            }

            public Builder SetIdentityType(string identityType)
            {
                this.identityType = identityType;
                return this;
            }
            public string GetLoginAsUserId()
            {
                return loginAsUserId;
            }

            public Builder SetLoginAsUserId(string loginAsUserId)
            {
                this.loginAsUserId = loginAsUserId;
                return this;
            }
            public string GetClientId()
            {
                return clientId;
            }

            public Builder SetClientId(string clientId)
            {
                this.clientId = clientId;
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
            public string GetCallbackUri()
            {
                return callbackUri;
            }

            public Builder SetCallbackUri(string callbackUri)
            {
                this.callbackUri = callbackUri;
                return this;
            }
            public string GetScope()
            {
                return scope;
            }

            public Builder SetScope(string scope)
            {
                this.scope = scope;
                return this;
            }
            public string GetCodeChallenge()
            {
                return codeChallenge;
            }

            public Builder SetCodeChallenge(string codeChallenge)
            {
                this.codeChallenge = codeChallenge;
                return this;
            }
            public string GetCodeChallengeMethod()
            {
                return codeChallengeMethod;
            }

            public Builder SetCodeChallengeMethod(string codeChallengeMethod)
            {
                this.codeChallengeMethod = codeChallengeMethod;
                return this;
            }
            public AuthorizeVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();
                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AuthorizeVo(this);
            }
        }
    }
}
