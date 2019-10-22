using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            #region Base

            //var baseMethodInvoke = new BaseMethodInvoke();
            //baseMethodInvoke.GetOtt();
            //baseMethodInvoke.GetCurrencyList();
            //baseMethodInvoke.GetGuildList();
            //baseMethodInvoke.AddTagTreeCategory();
            //baseMethodInvoke.GetTagTreeCategoryList();
            //baseMethodInvoke.UpdateTagTreeCategory();
            //baseMethodInvoke.AddTagTree();
            //baseMethodInvoke.GetTagTreeList();
            //baseMethodInvoke.UpdateTagTree();

            #endregion Base

            #region OAuth2

            //var ssoMethodInvoke = new SsoMethodInvoke();
            //var loginUrl = ssoMethodInvoke.GetLoginUrl();
            //var accessToken = ssoMethodInvoke.GetAccessToken("", "");
            //var refreshAccessToken = ssoMethodInvoke.RefreshAccessToken();
            //var tokenInfoSrv = ssoMethodInvoke.GetTokenInfo();
            //var result = ssoMethodInvoke.RevokeToken();


            #endregion OAuth2

            #region OTP  

            //var handshakeSrv = ssoMethodInvoke.Handshake("", "");
            //var sentVerificationDTOSrv = ssoMethodInvoke.Authorize(privateKey, "", handshakeSrv.KeyId);
            //var refreshAccessToken = ssoMethodInvoke.Verify(privateKey, "", handshakeSrv.KeyId, "");
            //refreshAccessToken = ssoMethodInvoke.GetAccessTokenByOtp(refreshAccessToken.Code);

            #region Scenario



            //var otpScenario = ssoMethodInvoke.GetOtpScenario(privateKey, "", "", "");
            //var accessTokenByOtpScenario = ssoMethodInvoke.GetAccessTokenByOtpScenario(privateKey, "09153864790", otpScenario.KeyId, "");

            #endregion Scenario

            #endregion OTP

            #region UserOperation

            //var userOperationMethodInvoke = new UserOperationMethodInvoke();
            //userOperationMethodInvoke.GetUserProfile();
            //userOperationMethodInvoke.EditProfileWithConfirmation();
            //userOperationMethodInvoke.GetListAddress();
            //userOperationMethodInvoke.ConfirmEditProfile();

            #endregion UserOperation

            #region Billing

            var billingMethodInvoke = new BillingMethodInvoke();
            //billingMethodInvoke.IssueInvoice();
            ////billingMethodInvoke.VerifyInvoice();
            //billingMethodInvoke.VerifyAndCloseInvoice();
            ////billingMethodInvoke.CloseInvoice();
            ////billingMethodInvoke.CancelInvoice();
            ////billingMethodInvoke.GetOtt();
            //billingMethodInvoke.GetInvoiceList();
            ////billingMethodInvoke.GetInvoiceListByMetadata();
            //billingMethodInvoke.GetExportList();
            ////billingMethodInvoke.GetInvoiceListAsFile();
            ////billingMethodInvoke.ReduceInvoice();
            ////billingMethodInvoke.PayInvoice();
            //billingMethodInvoke.PayInvoiceInFuture();
            //billingMethodInvoke.PayInvoiceByInvoice();
            //billingMethodInvoke.PayInvoiceByCredit();
            //billingMethodInvoke.PayAnyInvoiceByCredit();
            //billingMethodInvoke.SendInvoicePaymentSms();
            //billingMethodInvoke.CreatePreInvoice();
            //billingMethodInvoke.GetPayInvoiceByWalletLink();
            ////billingMethodInvoke.GetInvoicePaymentLink();


            ////billingMethodInvoke.GetPayInvoiceByUniqueNumberLink();
            //billingMethodInvoke.RequestWalletSettlement();
            //billingMethodInvoke.RequestGuildSettlement();
            //billingMethodInvoke.RequestSettlementByTool();
            //billingMethodInvoke.ListSettlements();
            //billingMethodInvoke.AddAutoSettlement();
            //billingMethodInvoke.RemoveAutoSettlement();

            #region Sharing

            //billingMethodInvoke.IssueMultiInvoice();
            //billingMethodInvoke.ReduceMultiInvoice();
            //billingMethodInvoke.ReduceMultiInvoiceAndCashout();

            #endregion Sharing

            #region Voucher

            //billingMethodInvoke.DefineCreditVoucher();
            //billingMethodInvoke.DefineDiscountAmountVoucher();
            //billingMethodInvoke.DefineDiscountPercentageVoucher();
            //billingMethodInvoke.ApplyVoucher();
            //billingMethodInvoke.GetVoucherList();
            //billingMethodInvoke.ActivateVoucher();
            //billingMethodInvoke.DeactivateVoucher();

            #endregion Voucher

            #region DirectDebit

            //billingMethodInvoke.DefineDirectWithdraw();
            //billingMethodInvoke.GetDirectWithdrawList();
            //billingMethodInvoke.UpdateDirectWithdraw();
            //billingMethodInvoke.RevokeDirectWithdraw();

            #endregion DirectDebit

            #endregion

            #region Dealing

            //var dealingMethodInvoke = new DealingMethodInvoke();
            //dealingMethodInvoke.AddUserAndBusiness();
            //dealingMethodInvoke.ListUserCreatedBusiness();
            //dealingMethodInvoke.UpdateBusiness();
            //dealingMethodInvoke.GetApiTokenForCreatedBusiness();
            //dealingMethodInvoke.RateBusiness();
            //dealingMethodInvoke.CommentBusiness();
            //dealingMethodInvoke.BusinessFavorite();
            //dealingMethodInvoke.UserBusinessInfos();
            //dealingMethodInvoke.CommentBusinessList();
            //dealingMethodInvoke.ConfirmComment();
            //dealingMethodInvoke.UnConfirmComment();

            #endregion

            #region Subscription

            //var subscriptionMethodInvoke = new SubscriptionMethodInvoke();
            //subscriptionMethodInvoke.AddSubscriptionPlan();
            //subscriptionMethodInvoke.SubscriptionPlanList();
            //subscriptionMethodInvoke.UpdateSubscriptionPlan();
            //subscriptionMethodInvoke.RequestSubscription();
            //subscriptionMethodInvoke.ConfirmSubscription();
            //subscriptionMethodInvoke.SubscriptionList();
            //subscriptionMethodInvoke.ConsumeSubscription();

            #endregion Subscription

            #region Notification

            //var notificationMethodInvoke=new NotificationMethodInvoke();
            //notificationMethodInvoke.SendSms();
            //notificationMethodInvoke.GetSmsStatus();
            //notificationMethodInvoke.SendValidationSms();
            //notificationMethodInvoke.GetValidationSmsStatus();
            //notificationMethodInvoke.GetSmsList();
            //notificationMethodInvoke.SendEmail();
            //notificationMethodInvoke.GetEmailList();
            //notificationMethodInvoke.SendPushNotificationByPeerId();
            //notificationMethodInvoke.SendPushNotificationByAppId();
            //notificationMethodInvoke.GetPushNotificationStatus();
            //notificationMethodInvoke.GetPushNotificationList();

            #endregion Notification

            #region Product

            var productMethodInvoke=new ProductMethodInvoke();
            //productMethodInvoke.AddProduct();
            //productMethodInvoke.AddSubProduct();
            //productMethodInvoke.AddProducts();
            //productMethodInvoke.GetAttributeTemplateList();
            //productMethodInvoke.GetBusinessProductList();
            productMethodInvoke.UpdateProduct();
            //productMethodInvoke.UpdateProducts();
            //productMethodInvoke.GetProductList();
            //productMethodInvoke.SearchProduct();
            //productMethodInvoke.SearchSubProduct();

            #endregion Product

            #region Neshan

            var neshanMethodInvoke = new NeshanMethodInvoke();
            //neshanMethodInvoke.Search();
            //neshanMethodInvoke.ReverseGeo();
            //neshanMethodInvoke.Direction();
            //neshanMethodInvoke.NoTrafficDirection();
            //neshanMethodInvoke.DistanceMatrix();
            //neshanMethodInvoke.NoTrafficDistanceMatrix();
            //neshanMethodInvoke.MapMatching();

            #endregion Neshan

            #region Tools

            var toolsMethodInvoke= new ToolsMethodInvoke();
            //toolsMethodInvoke.PayBill();
            toolsMethodInvoke.GetPayedBillList();

            #endregion Tools

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
