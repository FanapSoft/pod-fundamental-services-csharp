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


namespace Demo
{
    public class SsoMethodInvoke
    {
        private readonly SsoService ssoService;
        public readonly ClientInfo ClientInfo;
        public SsoMethodInvoke(string clientId, string clientSecret)
        {
            ClientInfo = new ClientInfo()
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };
           ssoService=new SsoService(ClientInfo);
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

        public OAuthResponseSrv RefreshAccessToken(string refreshToekn)
        {
            try
            {
                var output = new OAuthResponseSrv();
                var refreshTokenVo = RefreshAccessTokenVo.ConcreteBuilder
                    .SetGrantType("refresh_token")
                    .SetRefreshToken(refreshToekn)
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

        public TokenInfoSrv GetTokenInfo(string token,TokenType tokenType)
        {
            try
            {
                var output = new TokenInfoSrv();
                var tokenInfoVo = TokenInfoVo.ConcreteBuilder
                    .SetToken(token)
                    .SetTokenTypeHint(tokenType)
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

        public string RevokeToken(string token,RevokeTokenType revokeTokenType)
        {
            try
            {
                var output = string.Empty;
                var revokeTokenVo = RevokeTokenVo.ConcreteBuilder
                    .SetTokenTypeHint(revokeTokenType)
                    .SetToken(token)
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
                    //.SetDeviceLat(0) //{Put your DeviceLat}
                    //.SetDeviceLon(0) //{Put your DeviceLon}
                    //.SetDeviceName("") //{Put your DeviceName}
                    //.SetDeviceOs("") //{Put your DeviceOs}
                    //.SetDeviceOsVersion("") //{Put your DeviceOsVersion}
                    //.SetDeviceType(DeviceType.MobilePhone) //{Put your DeviceType}
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
                    //.SetCallbackUri("") //{Put your CallbackUri}
                    //.SetClientId("") //{Put your ClientId}
                    //.SetCodeChallenge("") //{Put your CodeChallenge}
                    //.SetCodeChallengeMethod("") //{Put your CodeChallengeMethod}
                    //.SetIdentityType("") //{Put your IdentityType}
                    //.SetLoginAsUserId("") //{Put your LoginAsUserId}
                    //.SetRedirectUri("") //{Put your RedirectUri}
                    //.SetReferrer("") //{Put your Referrer}
                    //.SetReferrerType(ReferrerType.phone_number) //{Put your ReferrerType}
                    //.SetResponseType("") //{Put your ResponseType}
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
                var oAuthResponseSrv = Verify(privateKey,identity,keyId,otp);
                var output= GetAccessTokenByOtp(oAuthResponseSrv.Code);
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
