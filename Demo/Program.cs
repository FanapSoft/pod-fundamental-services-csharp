using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using POD_SSO.Base.Enum;
using POD_SSO.Model.OAuth2.ValueObject;
using POD_UserOperation.Base;


namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            #region OAuth2

            //var ssoMethodInvoke = new SsoMethodInvoke("{Put your ClientId}", "{Put your ClientSecret}");
            //var accessToken = ssoMethodInvoke.GetAccessToken("51f1a761498d4780bff15febe7e2a73e", "https://www.google.com/");
            //var refreshAccessToken = ssoMethodInvoke.RefreshAccessToken("{Put yout RefreshToken}");
            //var tokenInfoSrv = ssoMethodInvoke.GetTokenInfo("{Put your Token}", POD_SSO.Base.Enum.TokenType.access_token); //{Put your TokenType}
            //var result = ssoMethodInvoke.RevokeToken("{Put your Token}", POD_SSO.Base.Enum.RevokeTokenType.access_token); //{Put your RevokeTokenType}

            //#endregion OAuth2

            //#region OTP       

            //var handshakeSrv = ssoMethodInvoke.Handshake("{Put your ApiToken}", "{Put your DeviceUid}");
            //var sentVerificationDTOSrv = ssoMethodInvoke.Authorize("{Put your Private Key}", "{Put your Mobile Number or Email}", handshakeSrv.KeyId);
            //refreshAccessToken = ssoMethodInvoke.Verify("{Put your Private Key}", "{Put your Mobile Number or Email}", handshakeSrv.KeyId, "{Put your OTP}");
            //refreshAccessToken = ssoMethodInvoke.GetAccessTokenByOtp(refreshAccessToken.Code);

            #region Scenario

            //var otpScenario = ssoMethodInvoke.GetOtpScenario("{Put your PeivateKey}", "{Put your Identity}", "{Put your ApiToken}", "{Put your DeviceUid}");
            //var accessTokenByOtpScenario = ssoMethodInvoke.GetAccessTokenByOtpScenario("{Put your PeivateKey}", "{Put your Identity}", otpScenario.KeyId, "{Put yout Otp}");

            #endregion Scenario

            #endregion OTP

            #region UserOperation

            //var userOperationMethodInvoke = new UserOperationMethodInvoke();
            //var customerProfileSrv = userOperationMethodInvoke.GetUserProfile();
            //var profile = userOperationMethodInvoke.EditProfileWithConfirmation();

            #endregion UserOperation

            #region Billing

            //var billingMethodInvoke = new BillingMethodInvoke();
            //billingMethodInvoke.IssueInvoice();
            //billingMethodInvoke.VerifyAndCloseInvoice();
            //billingMethodInvoke.GetOtt();
            //billingMethodInvoke.VerifyInvoice();
            //billingMethodInvoke.CloseInvoice();
            //billingMethodInvoke.CancelInvoice();
            //billingMethodInvoke.GetInvoiceList();
            //billingMethodInvoke.GetInvoiceListByMetadata();
            //billingMethodInvoke.GetExportList();
            //billingMethodInvoke.GetInvoiceListAsFile();
            //billingMethodInvoke.ReduceInvoice();
            //billingMethodInvoke.PayInvoice();
            //billingMethodInvoke.PayInvoiceInFuture();
            //billingMethodInvoke.PayInvoiceByInvoice();
            //billingMethodInvoke.SendInvoicePaymentSms();
            //billingMethodInvoke.CreatePreInvoice();
            //billingMethodInvoke.GetPayInvoiceByWalletLink();
            //billingMethodInvoke.GetInvoicePaymentLink();


            //billingMethodInvoke.GetPayInvoiceByUniqueNumberLink();
            //billingMethodInvoke.RequestWalletSettlement();
            //billingMethodInvoke.RequestGuildSettlement();
            //billingMethodInvoke.RequestSettlementByTool();
            //billingMethodInvoke.ListSettlements();
            //billingMethodInvoke.AddAutoSettlement();
            //billingMethodInvoke.RemoveAutoSettlement();

            #region Sharing

            //billingMethodInvoke.AddDealer();
            //billingMethodInvoke.DealerList();
            //billingMethodInvoke.EnableDealer();
            //billingMethodInvoke.DisableDealer();
            //billingMethodInvoke.BusinessDealingList();
            //billingMethodInvoke.IssueMultiInvoice();
            //billingMethodInvoke.ReduceMultiInvoice();
            //billingMethodInvoke.ReduceMultiInvoiceAndCashout();
            //billingMethodInvoke.AddDealerProductPermission();
            //billingMethodInvoke.DealerProductPermissionList();
            //billingMethodInvoke.DealingProductPermissionList();
            //billingMethodInvoke.DisableDealerProductPermission();
            //billingMethodInvoke.EnableDealerProductPermission();

            #endregion Sharing

            #endregion

            #region Dealing

            //var dealingMethodInvoke = new DealingMethodInvoke();
            //dealingMethodInvoke.AddUserAndBusiness();
            //dealingMethodInvoke.GuildList();
            //dealingMethodInvoke.ListUserCreatedBusiness();
            //dealingMethodInvoke.UpdateBusiness();
            //dealingMethodInvoke.GetApiTokenForCreatedBusiness();
            //dealingMethodInvoke.RateBusiness();
            //dealingMethodInvoke.CommentBusiness();
            //dealingMethodInvoke.BusinessFavorite();
            //dealingMethodInvoke.UserBusinessInfos();
            //dealingMethodInvoke.CommentBusinessList();
            //dealingMethodInvoke.ConfirmComment();

            #endregion

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
