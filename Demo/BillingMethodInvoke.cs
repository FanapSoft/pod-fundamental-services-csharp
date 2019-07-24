using POD_Billing.Model.ServiceOutput;
using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Billing;
using POD_Billing.Model.ValueObject;
using POD_Billing.Base.Enum;

namespace Demo
{
    public class BillingMethodInvoke
    {
        private readonly BillingService billingService;
        private readonly string apiToken;
        public BillingMethodInvoke()
        {
            try
            {
                apiToken = "{Put your Api token}";
                billingService = new BillingService(apiToken);
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<InvoiceSrv> IssueInvoice()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var ottOutput = GetOtt();
                var invoiceSrv = IssueInvoiceVo.ConcreteBuilder
                    .SetGuildCode("") //{Put your GuildCode}
                    .SetProductsInfo(new List<ProductInfo>
                    {
                         ProductInfo.ConcreteBuilder.SetProductId(0) //{Put your ProductId}
                         .SetPrice(0.0) //{Put your Price}
                         .SetQuantity(0) //{Put your Quantity}
                         .SetProductDescription("") //{Put your ProductDescription}
                         .Build(),
                         ProductInfo.ConcreteBuilder
                         .SetProductId(0) //{Put your ProductId}
                         .SetPrice(0.0) //{Put your Price}
                         .SetQuantity(0) //{Put your Quantity}
                         .SetProductDescription("") //{Put your ProductDescription}
                         .Build()
                    })
                    .SetOtt(ottOutput.Ott)
                    .SetPreferredTaxRate(0) //{Put your PreferredTaxRate}
                    .SetPreview(false) //{Put your Preview}
                    .SetMetadata("") //{Put your Metadata}
                    .SetUserId(0) //{Put your UserId}
                    .SetAddressId(0) //{Put your AddressId}
                    .Build();
                billingService.IssueInvoice(invoiceSrv, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<AddressSrv> GetListAddress()
        {
            try
            {
                var output = new ResultSrv<AddressSrv>();
                var invoiceSrv = ListAddressVo.ConcreteBuilder
                    .SetOffset(0) //{Put your Offset}
                    //.SetSize("") //{Put your Size}
                    .Build();
                billingService.GetListAddress(invoiceSrv, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<string> GetOtt()
        {
            try
            {
                var output = new ResultSrv<string>();
                billingService.GetOtt(response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<InvoiceSrv> VerifyInvoice()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var verifyInvoiceVo = VerifyInvoiceVo.ConcreteBuilder
                    .SetId(0) //{Put your Id}
                    //.SetBillNumber("") //{Put your BillNumber}
                    .Build();
                billingService.VerifyInvoice(verifyInvoiceVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<bool> CloseInvoice()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var closeInvoiceVo = CloseInvoiceVo.ConcreteBuilder
                    .SetId(0) //{Put your Id}
                    .Build();
                billingService.CloseInvoice(closeInvoiceVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<InvoiceSrv> VerifyAndCloseInvoice()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var verifyAndCloseInvoiceVo = VerifyAndCloseInvoiceVo.ConcreteBuilder
                    .SetId(0) //{Put your Id}
                    .Build();
                billingService.VerifyAndCloseInvoice(verifyAndCloseInvoiceVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<bool> CancelInvoice()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var cancelInvoiceVo = CancelInvoiceVo.ConcreteBuilder
                    .SetId(0) //{Put your Id}
                    .Build();
                billingService.CancelInvoice(cancelInvoiceVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
         
        public ResultSrv<List<InvoiceSrv>> GetInvoiceList()
        {
            try
            {
                var output = new ResultSrv<List<InvoiceSrv>>();
                var getInvoiceListVo = GetInvoiceListVo.ConcreteBuilder
                    .SetSize(0) //{Put your Size}
                    .SetOffset(0) //{Put your Offset}
                    //.SetGuildCode("") //{Put your GuildCode}
                    .Build();
                billingService.GetInvoiceList(getInvoiceListVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<List<InvoiceSrv>> GetInvoiceListByMetadata()
        {
            try
            {
                var output = new ResultSrv<List<InvoiceSrv>>();
                var getInvoiceListByMetadataVo = GetInvoiceListByMetadataVo.ConcreteBuilder
                    .SetMetaQuery("") //{Put your MetaQuery}
                    .SetSize(0) //{Put your Size}
                    //.SetOffSet("") //{Put your Offset}
                    //.SetIsCanceled(false) //{Put your IsCanceled}
                    //.SetIsPayed(false) //{Put your IsPayed}
                    .Build();
                billingService.GetInvoiceListByMetadata(getInvoiceListByMetadataVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<InvoiceSrv> GetInvoiceListAsFile()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var getInvoiceListAsFileVo = GetInvoiceListAsFileVo.ConcreteBuilder
                    .SetLastNRows(0)
                    //.SetFromDate("")
                    //.SetToDate("")
                    //.SetGuildCode("")
                    //.SetId(0)
                    //.SetBillNumber("")
                    //.SetUniqueNumber("")
                    //.SetTrackerId(0)
                    //.SetIsCanceled(false)
                    //.SetIsClosed(false)
                    //.SetIsPayed(false)
                    //.SetIsWaiting(false)
                    //.SetReferenceNumber("")
                    //.SetUserId(0)
                    //.SetQuery("")
                    //.SetProductIdList(new long[]{})
                    //.SetCallbackUrl("")
                    .Build();
                billingService.GetInvoiceListAsFile(getInvoiceListAsFileVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<InvoiceSrv> ReduceInvoice()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var reduceInvoiceVo = ReduceInvoiceVo.ConcreteBuilder
                    .SetId(3132542)
                    .SetInvoiceItemsInfo(new List<InvoiceItemInfoVo>
                    {
                        InvoiceItemInfoVo.ConcreteBuilder.SetInvoiceItemId(3165038).SetItemDescription("te234").SetPrice(1700).SetQuantity(1).Build(),
                        InvoiceItemInfoVo.ConcreteBuilder.SetInvoiceItemId(3165039).SetItemDescription("tdfr").SetPrice(1700).SetQuantity(1).Build()
                    })
                    //.SetPreferredTaxRate(0)
                    .Build();
                billingService.ReduceInvoice(reduceInvoiceVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<List<ExportServiceSrv>> GetExportList()
        {
            try
            {
                var output = new ResultSrv<List<ExportServiceSrv>>();
                var getExportListVo = GetExportListVo.ConcreteBuilder
                    .SetOffset(0)
                    .SetSize(1)
                    //.SetId(0)
                    .SetStatusCode(FileStatusCode.EXPORT_SERVICE_STATUS_SUCCESSFUL)
                    //.SetServiceUrl("")
                    .Build();
                billingService.GetExportList(getExportListVo, response => Listener.GetResult(response, out output));
                var link=getExportListVo.GetLink(185264, "16bcaf8a14b-0.6677722751789689");
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<bool> PayInvoice()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var payInvoiceVo = PayInvoiceVo.ConcreteBuilder
                    .SetInvoiceId(3328188)
                    .Build();
                billingService.PayInvoice(payInvoiceVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<bool> SendInvoicePaymentSms()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var sendInvoicePaymentSmsVo = SendInvoicePaymentSmsVo.ConcreteBuilder
                    .SetInvoiceId(3163071)
                    //.SetWallet("")
                    //.SetCallbackUri("")
                    //.SetRedirectUri("")
                    //.SetDelegationId(new long[]{1,2})
                    //.SetForceDelegation(false)
                    .Build();
                billingService.SendInvoicePaymentSms(sendInvoicePaymentSmsVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);



                throw;
            }
        }

        public ResultSrv<bool> PayInvoiceInFuture()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var ottOutput = GetOtt();
                var payInvoiceInFutureVo = PayInvoiceInFutureVo.ConcreteBuilder
                    .SetInvoiceId(3185918)
                    .SetDate("1398/06/10")
                    .SetOtt(ottOutput.Ott)
                    //.SetGuildCode("TOILETRIES_GUILD")
                    //.SetWallet("")
                    .Build();
                billingService.PayInvoiceInFuture(payInvoiceInFutureVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<bool> PayInvoiceByInvoice()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var payInvoiceByInvoiceVo = PayInvoiceByInvoiceVo.ConcreteBuilder
                    .SetCreditorInvoiceId(3164963)
                    .SetDebtorInvoiceId(3164833)
                    .Build();
                billingService.PayInvoiceByInvoice(payInvoiceByInvoiceVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public LinkSrv CreatePreInvoice()
        {
            try
            {
                var output = new ResultSrv<string>();
                var ottOutput = GetOtt();
                var createPreInvoiceVo = CreatePreInvoiceVo.ConcreteBuilder
                    .SetToken(apiToken)
                    .SetOtt(ottOutput.Ott)
                    .SetProductsInfo(new List<ProductInfo>
                    {
                        ProductInfo.ConcreteBuilder.SetProductId(0) //{Put your ProductId}
                         .SetPrice(0.0) //{Put your Price}
                         .SetQuantity(0) //{Put your Quantity}
                         .SetProductDescription("") //{Put your ProductDescription}
                         .Build(),
                         ProductInfo.ConcreteBuilder
                         .SetProductId(0) //{Put your ProductId}
                         .SetPrice(0.0) //{Put your Price}
                         .SetQuantity(0) //{Put your Quantity}
                         .SetProductDescription("") //{Put your ProductDescription}
                         .Build()
                    })
                    .SetGuildCode("") //{Put your GuildCode}
                    .SetRedirectUri("") //{Put your RedirectUri}
                    .SetUserId(0) //{Put your UserId}
                    //.SetBillNumber("") //{Put your BillNumber}
                    //.SetCallUrl("") //{Put your callUrl}
                    //.SetCurrencyCode("") //{Put your CurrencyCode}
                    //.SetDeadline("") //{Put your Deadline}
                    //.SetDescription("") //{Put your Description}
                    //.SetPreferredTaxRate(1) //{Put your PreferredTaxRate}
                    //.SetRedirectUri("") //{Put your RedirectUri}
                    //.SetVerificationNeeded(false) //{Put your VerificationNeeded}
                    .Build();
                billingService.CreatePreInvoice(createPreInvoiceVo,response => Listener.GetResult(response, out output));
                var linkSrv = createPreInvoiceVo.GetLink(output.Result);

                return linkSrv;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public string GetPayInvoiceByWalletLink()
        {
            try
            {
                var payInvoiceByWalletVo = PayInvoiceByWalletVo.ConcreteBuilder
                    .SetInvoiceId(0) //{Put your InvoiceId}
                    //.SetCallUri("") //{Put your CallUri}
                    //.SetRedirectUri("") //{Put your RedirectUri}
                    .Build();
                var output = payInvoiceByWalletVo.GetLink();
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<string> GetInvoicePaymentLink()
        {
            try
            {
                var output = new ResultSrv<string>();
                var getInvoicePaymentLinkVo = GetInvoicePaymentLinkVo.ConcreteBuilder
                    .SetInvoiceId(0) //{Put your InvoiceId}
                    .Build();
                billingService.GetInvoicePaymentLink(getInvoicePaymentLinkVo,response => Listener.GetResult(response, out output));
                var advanceLink = getInvoicePaymentLinkVo.GetAdvanceLink(output.Result, "PEP");

                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public string GetPayInvoiceByUniqueNumberLink()
        {
            try
            {
                var payInvoiceByUniqueNumberVo = PayInvoiceByUniqueNumberVo.ConcreteBuilder
                    .SetUniqueNumber("") //{Put your UniqueNumber}
                    //.SetGateway("") //{Put your Gateway}
                    //.SetRedirectUri("") //{Put your RedirectUri}
                    //.SetCallUri("") //{Put your CallUri}
                    .Build();
                var output = payInvoiceByUniqueNumberVo.GetLink();
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }


        public ResultSrv<SettlementRequestSrv> RequestWalletSettlement()
        {
            try
            {
                var ottOutput = GetOtt();
                var output = new ResultSrv<SettlementRequestSrv>();
                var requestWalletSettlementVo = RequestWalletSettlementVo.ConcreteBuilder
                    .SetAmount(0)
                    .SetOtt(ottOutput.Ott)
                    //.SetWallet("")
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetSheba("")
                    //.SetCurrencyCode("")
                    //.SetUniqueId("")
                    //.SetDescription("")
                    .Build();
                billingService.RequestSettlement(requestWalletSettlementVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<SettlementRequestSrv> RequestGuildSettlement()
        {
            try
            {
                var ottOutput = GetOtt();
                var output = new ResultSrv<SettlementRequestSrv>();
                var requestGuildSettlementVo = RequestGuildSettlementVo.ConcreteBuilder
                    .SetGuildCode("")
                    .SetAmount(0)
                    .SetOtt(ottOutput.Ott)
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetSheba("")
                    //.SetCurrencyCode("")
                    //.SetUniqueId("")
                    //.SetDescription("")
                    .Build();
                billingService.RequestSettlement(requestGuildSettlementVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<SettlementRequestSrv> RequestSettlementByTool()
        {
            try
            {
                var ottOutput = GetOtt();
                var output = new ResultSrv<SettlementRequestSrv>();
                var requestSettlementByToolVo = RequestSettlementByToolVo.ConcreteBuilder
                    .SetToolCode(ToolCode.SETTLEMENT_TOOL_CARD)
                    .SetToolId("")
                    .SetAmount(0)
                    .SetGuildCode("")
                    .SetOtt(ottOutput.Ott)
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetCurrencyCode("")
                    //.SetUniqueId("")
                    //.SetDescription("")
                    .Build();
                billingService.RequestSettlement(requestSettlementByToolVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<List<SettlementRequestSrv>> ListSettlements()
        {
            try
            {
                var output = new ResultSrv<List<SettlementRequestSrv>>();
                var listSettlementsVo = ListSettlementsVo.ConcreteBuilder
                    .SetOffset(0)
                    .SetSize(0)
                    //.SetStatusCode(SettlementStatusCode.SETTLEMENT_DONE)
                    //.SetFromAmount(0)
                    //.SetToAmount(0)
                    //.SetFromDate("")
                    //.SetToDate(DateTime.Now)
                    //.SetUniqueId("")
                    //.SetCurrencyCode("")
                    .Build();
                billingService.ListSettlements(listSettlementsVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<bool> AddAutoSettlement()
        {
            try
            {
                var ottOutput = GetOtt();
                var output = new ResultSrv<bool>();
                var addAutoSettlementVo = AddAutoSettlementVo.ConcreteBuilder
                    .SetGuildCode("")
                    .SetOtt(ottOutput.Ott)
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetSheba("")
                    //.SetCurrencyCode("")
                    //.SetInstant(false)
                    .Build();
                billingService.AddAutoSettlement(addAutoSettlementVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<bool> RemoveAutoSettlement()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var registerUserVo = RemoveAutoSettlementVo.ConcreteBuilder
                    .SetGuildCode("")
                    //.SetCurrencyCode("")
                    .Build();
                billingService.RemoveAutoSettlement(registerUserVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        #region Sharing

        public ResultSrv<BusinessDealerSrv> AddDealer()
        {
            try
            {
                var output = new ResultSrv<BusinessDealerSrv>();
                var addDealerVo = AddDealerVo.ConcreteBuilder
                    .SetDealerBizId(0)
                    //.SetAllProductAllow(false)
                    .Build();
                billingService.AddDealer(addDealerVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<List<BusinessDealerSrv>> DealerList()
        {
            try
            {
                var output = new ResultSrv<List<BusinessDealerSrv>>();
                var dealerListVo = DealerListVo.ConcreteBuilder
                    //.SetDealerBizId(0)
                    //.SetEnable(false)
                    //.SetOffset(0)
                    //.SetSize(0)
                    .Build();
                billingService.DealerList(dealerListVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<BusinessDealerSrv> EnableDealer()
        {
            try
            {
                var output = new ResultSrv<BusinessDealerSrv>();
                var enableDealerVo = EnableDealerVo.ConcreteBuilder
                    .SetDealerBizId(0)
                    .Build();
                billingService.EnableDealer(enableDealerVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<BusinessDealerSrv> DisableDealer()
        {
            try
            {
                var output = new ResultSrv<BusinessDealerSrv>();
                var disableDealerVo = DisableDealerVo.ConcreteBuilder
                    .SetDealerBizId(0)
                    .Build();
                billingService.DisableDealer(disableDealerVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<List<BusinessDealerSrv>> BusinessDealingList()
        {
            try
            {
                var output = new ResultSrv<List<BusinessDealerSrv>>();
                var businessDealingListVo = BusinessDealingListVo.ConcreteBuilder
                    .SetDealerBizId(0)
                    //.SetEnable(false)
                    //.SetOffset(0)
                    //.SetSize(0)
                    .Build();
                billingService.BusinessDealingList(businessDealingListVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<InvoiceSrv> IssueMultiInvoice()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var ottOutput = GetOtt();
                var mainInvoiceVos = MainInvoiceVo.ConcreteBuilder
                    .SetGuildCode("")
                    .SetInvoiceItemVOs(new List<InvoiceItemVo>
                    {
                        InvoiceItemVo.ConcreteBuilder.SetProductId(0).SetDescription("tst5").SetPrice(100).SetQuantity(2).Build()
                    })
                    //.SetBillNumber("")
                    .SetDescription("")
                    //.SetMetadata("")
                    .Build();
                  
                var subInvoiceVos = new List<SubInvoiceVo>
                {
                    SubInvoiceVo.ConcreteBuilder
                        .SetBusinessId(0)
                        .SetGuildCode("")
                        .SetInvoiceItemVOs(new List<InvoiceItemVo>
                        {
                            InvoiceItemVo.ConcreteBuilder.SetProductId(0)
                            .SetDescription("")
                            .SetPrice(0.0)
                            .SetQuantity(0)
                            .Build()
                        })
                        //.SetBillNumber("")
                        .SetDescription("")
                        //.SetMetadata("")
                        .Build()
                   
                };
                var customerInvoiceItems = new List<InvoiceItemVo>
                {
                    InvoiceItemVo.ConcreteBuilder.SetProductId(0)
                    .SetDescription("")
                    .SetPrice(0.0)
                    .SetQuantity(0)
                    .Build()
                };
                var multiInvoiceData = MultiInvoiceDataVo.ConcreteBuilder
                    .SetMainInvoice(mainInvoiceVos)
                    .SetSubInvoices(subInvoiceVos)
                    .SetCustomerInvoiceItemVOs(customerInvoiceItems)
                    //.SetPreview(false)
                    //.SetCurrencyCode("")
                    //.SetCustomerDescription("")
                    //.SetCustomerMetadata("")
                    //.SetPreferredTaxRate(0)
                    //.SetRedirectUrl("")
                    //.SetUserId(0)
                    //.SetVerificationNeeded(false)
                    //.SetVoucherHashs(new string[] { })
                    .Build();

                var issueMultiInvoiceVo = IssueMultiInvoiceVo.ConcreteBuilder
                    .SetOtt(ottOutput.Ott)
                    .SetData(multiInvoiceData)
                    //.SetDelegationHash(new string[]{})
                    //.SetDelegatorId(new long[]{})
                    //.SetForceDelegation(false)
                    .Build();
                billingService.IssueMultiInvoice(issueMultiInvoiceVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<InvoiceSrv> ReduceMultiInvoice()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var mainInvoiceVos = ReduceInvoiceItemVo.ConcreteBuilder
                    .SetId(0)
                    .SetReduceInvoiceItemVOs(new List<ReduceInvoiceSubItemVo>
                    {
                        ReduceInvoiceSubItemVo.ConcreteBuilder
                        .SetId(0)
                        .SetDescription("")
                        .SetPrice(0.0)
                        .SetQuantity(0)
                        .Build()
                    })
                    .Build();

                var subInvoiceVos = new List<ReduceInvoiceItemVo>
                {
                    ReduceInvoiceItemVo.ConcreteBuilder
                        .SetId(0)
                        .SetReduceInvoiceItemVOs(new List<ReduceInvoiceSubItemVo>
                        {
                            ReduceInvoiceSubItemVo.ConcreteBuilder
                            .SetId(0)
                            .SetDescription("")
                            .SetPrice(0.0)
                            .SetQuantity(0)
                            .Build()
                        })
                        .Build()
                };
                var customerInvoiceItems = new List<ReduceInvoiceSubItemVo>
                {
                    ReduceInvoiceSubItemVo.ConcreteBuilder
                    .SetId(0)
                    .SetDescription("")
                    .SetPrice(0.0)
                    .SetQuantity(0)
                    .Build()
                };

                var reduceMultiInvoiceDataVo = ReduceMultiInvoiceDataVo.ConcreteBuilder
                    .SetMainInvoice(mainInvoiceVos)
                    .SetSubInvoices(subInvoiceVos)
                    .SetCustomerInvoiceItemVOs(customerInvoiceItems)
                    //.SetPreferredTaxRate(0)
                    .Build();

                var reduceMultiInvoiceVo = ReduceMultiInvoiceVo.ConcreteBuilder
                    .SetData(reduceMultiInvoiceDataVo)
                    .Build();
                billingService.ReduceMultiInvoice(reduceMultiInvoiceVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<InvoiceSrv> ReduceMultiInvoiceAndCashout()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();

                var mainInvoiceVos = ReduceInvoiceItemVo.ConcreteBuilder
                    .SetId(0)
                    .SetReduceInvoiceItemVOs(new List<ReduceInvoiceSubItemVo>
                    {
                        ReduceInvoiceSubItemVo.ConcreteBuilder
                        .SetId(0)
                        .SetDescription("")
                        .SetPrice(0.0)
                        .SetQuantity(0)
                        .Build()
                    })
                    .Build();

                var subInvoiceVos = new List<ReduceInvoiceItemVo>
                {
                    ReduceInvoiceItemVo.ConcreteBuilder
                        .SetId(0)
                        .SetReduceInvoiceItemVOs(new List<ReduceInvoiceSubItemVo>
                        {
                            ReduceInvoiceSubItemVo.ConcreteBuilder
                            .SetId(0)
                            .SetDescription("")
                            .SetPrice(0.0)
                            .SetQuantity(0)
                            .Build()
                        })
                        .Build()
                };
                var customerInvoiceItems = new List<ReduceInvoiceSubItemVo>
                {
                    ReduceInvoiceSubItemVo.ConcreteBuilder.SetId(3588065)
                    .SetDescription("")
                    .SetPrice(0.0)
                    .SetQuantity(0)
                    .Build()
                };

                var reduceMultiInvoiceDataVo = ReduceMultiInvoiceDataVo.ConcreteBuilder
                    .SetMainInvoice(mainInvoiceVos)
                    .SetSubInvoices(subInvoiceVos)
                    .SetCustomerInvoiceItemVOs(customerInvoiceItems)
                    //.SetPreferredTaxRate(0)
                    .Build();

                var reduceMultiInvoiceAndCashoutVo = ReduceMultiInvoiceAndCashoutVo.ConcreteBuilder
                    .SetData(reduceMultiInvoiceDataVo)
                    .SetToolCode(ToolCode.SETTLEMENT_TOOL_CARD)
                    .Build();
                billingService.ReduceMultiInvoiceAndCashout(reduceMultiInvoiceAndCashoutVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<DealerProductPermissionSrv> AddDealerProductPermission()
        {
            try
            {
                var output = new ResultSrv<DealerProductPermissionSrv>();
                var registerUserVo = AddDealerProductPermissionVo.ConcreteBuilder
                    .SetEntityId(0)
                    .SetDealerBizId(0)
                    .Build();
                billingService.AddDealerProductPermission(registerUserVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<List<DealerProductPermissionSrv>> DealerProductPermissionList()
        {
            try
            {
                var output = new ResultSrv<List<DealerProductPermissionSrv>>();
                var registerUserVo = DealerProductPermissionListVo.ConcreteBuilder
                                    //.SetSize(0)
                                    //.SetDealingBusinessId(0)
                                    //.SetEnable(false)
                                    //.SetOffset(0)
                                    //.SetEntityId(0)
                    .Build();
                billingService.DealerProductPermissionList(registerUserVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<List<DealerProductPermissionSrv>> DealingProductPermissionList()
        {
            try
            {
                var output = new ResultSrv<List<DealerProductPermissionSrv>>();
                var registerUserVo = DealingProductPermissionListVo.ConcreteBuilder
                    //.SetSize(0)
                    //.SetDealingBusinessId(0)
                    //.SetEnable(false)
                    //.SetOffset(0)
                    //.SetEntityId(0)
                    .Build();
                billingService.DealingProductPermissionList(registerUserVo,response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<DealerProductPermissionSrv> DisableDealerProductPermission()
        {
            try
            {
                var output = new ResultSrv<DealerProductPermissionSrv>();
                var registerUserVo = DisableDealerProductPermissionVo.ConcreteBuilder
                    .SetEntityId(0)
                    .SetDealerBizId(0)
                    .Build();
                billingService.DisableDealerProductPermission(registerUserVo,
                    response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<DealerProductPermissionSrv> EnableDealerProductPermission()
        {
            try
            {
                var output = new ResultSrv<DealerProductPermissionSrv>();
                var enableDealerProductPermissionVo = EnableDealerProductPermissionVo.ConcreteBuilder
                    .SetEntityId(0)
                    .SetDealerBizId(0)
                    .Build();
                billingService.EnableDealerProductPermission(enableDealerProductPermissionVo,response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        #endregion Sharing
    }
}
