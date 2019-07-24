using System;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_SSO.Base;
using POD_SSO.Model.OAuth2.ServiceOutput;
using POD_SSO.Model.OAuth2.ValueObject;
using POD_SSO.Model.OTP.ServiceOutput;
using POD_SSO.Model.OTP.ValueObject;
using RestSharp;

namespace POD_SSO
{
    public class SsoService
    {
        private readonly ClientInfo clientInfo;
        public SsoService(ClientInfo clientInfo)
        {
            var hasErrorFields = clientInfo.Validate();
            if (hasErrorFields.Any())
            {
                throw PodException.BuildException(new InvalidParameter(hasErrorFields));
            }

            this.clientInfo = clientInfo;
        }

        #region OAuth2

        public void GetAccessToken(AccessTokenVo accessTokenVo, Action<IRestResponse<OAuthResponseSrv>> callback)
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/token";
            PrepareRestClient(url, accessTokenVo, out var client, out var request);
            callback(client.Execute<OAuthResponseSrv>(request));
        }

        public void RefreshAccessToken(RefreshAccessTokenVo refreshAccessTokenVo, Action<IRestResponse<OAuthResponseSrv>> callback)
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/token";
            PrepareRestClient(url, refreshAccessTokenVo, out var client, out var request);
            callback(client.Execute<OAuthResponseSrv>(request));
        }

        public void GetTokenInfo(TokenInfoVo tokenInfoVo, Action<IRestResponse<TokenInfoSrv>> callback)
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/token/info";
            PrepareRestClient(url, tokenInfoVo, out var client, out var request);
            callback(client.Execute<TokenInfoSrv>(request));

        }

        public void RevokeToken(RevokeTokenVo revokeTokenVo, Action<IRestResponse> callback)
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/token/revoke";
            PrepareRestClient(url, revokeTokenVo, out var client, out var request);
            callback(client.Execute(request));
        }

        #endregion OAuth2

        #region OTP

        public void Handshake(HandshakeVo handshakeVo, Action<IRestResponse<HandshakeSrv>> callback)
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/clients/handshake/{clientInfo.ClientId}";
            PrepareRestClient(url, handshakeVo, out var client, out var request,false);
            request.AddHeader(nameof(handshakeVo.Authorization).GetPodName(), handshakeVo.Authorization);
            callback(client.Execute<HandshakeSrv>(request));
        }

        public void Authorize(AuthorizeVo authorizeVo, Action<IRestResponse<SentVerificationDTOSrv>> callback)
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/otp/authorize/{authorizeVo.Identity}";
            PrepareRestClient(url, authorizeVo, out var client, out var request,false);
            var parameter=request.Parameters.FirstOrDefault(_ => _.Name.Equals(nameof(authorizeVo.Identity).GetPodName()));
            request.Parameters.Remove(parameter);
            request.AddHeader(nameof(authorizeVo.Authorization).GetPodName(), authorizeVo.Authorization);
            callback(client.Execute<SentVerificationDTOSrv>(request));
        }

        public void Verify(VerifyVo verifyVo, Action<IRestResponse<OAuthResponseSrv>> callback)
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/otp/verify/{verifyVo.Identity}";
            PrepareRestClient(url, verifyVo, out var client, out var request,false);
            var parameter = request.Parameters.FirstOrDefault(_ => _.Name.Equals(nameof(verifyVo.Identity).GetPodName()));
            request.Parameters.Remove(parameter);
            request.AddHeader(nameof(verifyVo.Authorization).GetPodName(), verifyVo.Authorization);
            callback(client.Execute<OAuthResponseSrv>(request));
        }

        public void GetAccessTokenByOtp(AccessTokenByOtpVo accessTokenByOtpVo, Action<IRestResponse<OAuthResponseSrv>> callback)
        {
            var url = $"{BaseUrl.SsoAddress}/oauth2/token";
            PrepareRestClient(url,accessTokenByOtpVo, out var client, out var request);
            callback(client.Execute<OAuthResponseSrv>(request));
        }

        #endregion OTP

        private void PrepareRestClient<T>(string url, T objectVo, out RestClient client, out RestRequest request,bool addClientInfo=true)
        {
            client = new RestClient(url);
            request = new RestRequest(Method.POST);
            request.AddHeader("ContentType".GetPodName(), "application/x-www-form-urlencoded");
            PrepareParameters(objectVo, request,addClientInfo);
        }

        private void PrepareParameters<T>(T objectVo, RestRequest request, bool addClientInfo)
        {
            if (addClientInfo)
            {
                request.AddParameter(nameof(clientInfo.ClientId).GetPodName(), clientInfo.ClientId)
                       .AddParameter(nameof(clientInfo.ClientSecret).GetPodName(), clientInfo.ClientSecret);
            }
            var parameters = objectVo.FilterNotNull(PodParameterName.ParametersName);
            if (parameters == null) return;
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }
        }
    }
}
