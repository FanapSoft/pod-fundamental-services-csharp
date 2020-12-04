using System;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_SSO;
using POD_SSO.Base;
using POD_SSO.Base.Enum;
using POD_SSO.Model.OAuth2.ServiceOutput;
using POD_SSO.Model.OAuth2.ValueObject;
using POD_SSO.Model.OTP.ServiceOutput;
using POD_SSO.Model.OTP.ValueObject;


namespace POD_Demo
{
    public class SsoMethodInvoke
    {
        private readonly SsoService ssoService;
        public readonly ClientInfo ClientInfo;

        public SsoMethodInvoke()
        {
            try
            {
                ClientInfo = new ClientInfo
                {
                    ClientId = "",
                    ClientSecret = ""
                };

                ssoService = new SsoService(ClientInfo);
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        #region OAuth2

        public OAuthResponseSrv GetAccessToken(string code, string redirectUri)
        {
            try
            {
                var output = new OAuthResponseSrv();
                var accessTokenVo = AccessTokenVo.ConcreteBuilder
                    .SetCode(code)
                    .SetGrantType("authorization_code")
                    .SetRedirectUri(redirectUri)
                    .Build();
                ssoService.GetAccessToken(accessTokenVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public OAuthResponseSrv RefreshAccessToken()
        {
            try
            {
                var output = new OAuthResponseSrv();
                var refreshTokenVo = RefreshAccessTokenVo.ConcreteBuilder
                    .SetGrantType("refresh_token")
                    .SetRefreshToken("")
                    .Build();
                ssoService.RefreshAccessToken(refreshTokenVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public TokenInfoSrv GetTokenInfo()
        {
            try
            {
                var output = new TokenInfoSrv();
                var tokenInfoVo = TokenInfoVo.ConcreteBuilder
                    .SetToken("")
                    .SetTokenTypeHint(TokenType.refresh_token)
                    .Build();
                ssoService.GetTokenInfo(tokenInfoVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public string RevokeToken()
        {
            try
            {
                var output = string.Empty;
                var revokeTokenVo = RevokeTokenVo.ConcreteBuilder
                    .SetTokenTypeHint(RevokeTokenType.refresh_token)
                    .SetToken("")
                    .Build();
                ssoService.RevokeToken(revokeTokenVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public string GetLoginUrl()
        {
            try
            {
                var loginUrlVo = LoginUrlVo.ConcreteBuilder
                    .SetClientId(ClientInfo.ClientId)
                    .SetResponseType(ResponseType.code)
                    .SetRedirectUri("")
                    .SetScope(new[] { ScopeType.profile, ScopeType.email })
                    .Build();
                var output = loginUrlVo.GetLink();
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        #endregion OAuth2

        #region OTP

        public HandshakeSrv Handshake(string apiToken, string deviceUid)
        {
            try
            {
                var output = new HandshakeSrv();
                var handshakeVo = HandshakeVo.ConcreteBuilder
                    .SetAuthorization(apiToken)
                    .SetDeviceUid(deviceUid)
                    .Build();
                ssoService.Handshake(handshakeVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public SentVerificationDTOSrv Authorize(string privateKey, string identity, string keyId)
        {
            try
            {
                var output = new SentVerificationDTOSrv();
                var authorizeVo = AuthorizeVo.ConcreteBuilder
                    .SetIdentity(identity)
                    .SetAuthorization(keyId, privateKey)
                    .SetResponseType("code")
                    .Build();
                ssoService.Authorize(authorizeVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public OAuthResponseSrv Verify(string privateKey, string identity, string keyId, string otp)
        {
            try
            {
                var output = new OAuthResponseSrv();
                var verifyVo = VerifyVo.ConcreteBuilder
                    .SetIdentity(identity)
                    .SetAuthorization(keyId, privateKey)
                    .SetOtp(otp)
                    .Build();
                ssoService.Verify(verifyVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public OAuthResponseSrv GetAccessTokenByOtp(string code)
        {
            try
            {
                var output = new OAuthResponseSrv();
                var accessTokenByOtpVo = AccessTokenByOtpVo.ConcreteBuilder
                    .SetCode(code)
                    .SetGrantType("authorization_code")
                    .Build();
                ssoService.GetAccessTokenByOtp(accessTokenByOtpVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        #region Scenario

        public HandshakeSrv GetOtpScenario(string privateKey, string identity, string apiToken, string deviceUid)
        {
            try
            {
                var output = Handshake(apiToken, deviceUid);
                Authorize(privateKey, identity, output.KeyId);
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public OAuthResponseSrv GetAccessTokenByOtpScenario(string privateKey, string identity, string keyId, string otp)
        {
            try
            {
                var oAuthResponseSrv = Verify(privateKey, identity, keyId, otp);
                var output = GetAccessTokenByOtp(oAuthResponseSrv.Code);
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        #endregion Scenario

        #endregion OTP
    }
}
