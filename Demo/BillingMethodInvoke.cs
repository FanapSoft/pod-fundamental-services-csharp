using POD_Billing.Model.ServiceOutput;
using System;
using System.Collections.Generic;
using POD_Base_Service;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Billing;
using POD_Billing.Model.ValueObject;
using POD_Billing.Base.Enum;
using POD_Billing.Model.ServiceOutput.DirectDebit;
using POD_Billing.Model.ServiceOutput.Voucher;
using POD_Billing.Model.ValueObject.DirectDebit;
using POD_Billing.Model.ValueObject.Settlement;
using POD_Billing.Model.ValueObject.Voucher;
using POD_Billing.Model.ServiceOutput.Settlement;
using POD_Billing.Model.ValueObject.Sharing;
using POD_Base_Service.Result;

namespace Demo
{
    public class BillingMethodInvoke
    {
        private const string GuildCode= "TOILETRIES_GUILD";
        private  InternalServiceCallVo internalServiceCallVo;
        public BillingMethodInvoke()
        {
            try
            {
                internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();
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
                //
                var output = new ResultSrv<InvoiceSrv>();
                var ottOutput = GetOtt();
                var invoiceSrv = IssueInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetGuildCode(GuildCode)
                    .SetProductsInfo(new List<ProductInfo>
                    {
                         ProductInfo.ConcreteBuilder.SetProductId(0).SetPrice(10).SetQuantity(3.5M).SetProductDescription("tst1").Build(),
                         //ProductInfo.ConcreteBuilder.SetProductId(0).SetPrice(1000).SetQuantity(3.7M).SetProductDescription("tst1").Build()
                    })
                    .SetOtt(ottOutput.Ott)
                    //.SetVerificationNeeded(true)
                    //.SetPreferredTaxRate(0.5)
                    //.SetPreview(false)
                    //.SetMetadata("{\"name\":\"arz\"}")
                    .SetUserId(1468849)
                    //.SetAddressId("")
                    //.SetDeadline("1398/08/09")
                    .Build();
                BillingService.IssueInvoice(invoiceSrv, response => Listener.GetResult(response, out output));
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
                BaseService.GetOtt(internalServiceCallVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(6859502)
                    //.SetBillNumber("")
                    .Build();
                BillingService.VerifyInvoice(verifyInvoiceVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(6859393)
                    .Build();
                BillingService.CloseInvoice(closeInvoiceVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(3328298)
                    .Build();
                BillingService.VerifyAndCloseInvoice(verifyAndCloseInvoiceVo,
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(6859502)
                    .Build();
                BillingService.CancelInvoice(cancelInvoiceVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetSize(1)
                    .SetOffset(0)
                    //.SetGuildCode("TOILETRIES_GUILD")
                    .Build();
                BillingService.GetInvoiceList(getInvoiceListVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetMetaQuery("{\"field\":\"name\",\"is\":\"av\"}")
                    //.SetSize(0)
                    //.SetOffSet("")
                    //.SetIsCanceled(false)
                    //.SetIsPayed(false)
                    .Build();
                BillingService.GetInvoiceListByMetadata(getInvoiceListByMetadataVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
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
                BillingService.GetInvoiceListAsFile(getInvoiceListAsFileVo,
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(6859679)
                    .SetInvoiceItemsInfo(new List<InvoiceItemInfoVo>
                    {
                        InvoiceItemInfoVo.ConcreteBuilder.SetInvoiceItemId(7070162).SetItemDescription("te234").SetPrice(5).SetQuantity(1).Build(),
                        //InvoiceItemInfoVo.ConcreteBuilder.SetInvoiceItemId(3165039).SetItemDescription("tdfr").SetPrice(1700).SetQuantity(1).Build()
                    })
                    //.SetPreferredTaxRate(0)
                    .Build();
                BillingService.ReduceInvoice(reduceInvoiceVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(1)
                    //.SetId(0)
                    .SetStatusCode(FileStatusCode.EXPORT_SERVICE_STATUS_SUCCESSFUL)
                    //.SetServiceUrl("")
                    .Build();
                BillingService.GetExportList(getExportListVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<bool> SendInvoicePaymentSms()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var sendInvoicePaymentSmsVo = SendInvoicePaymentSmsVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetInvoiceId(3163071)
                    //.SetWallet("")
                    //.SetCallbackUri("")
                    //.SetRedirectUri("")
                    //.SetDelegationId(new long[]{1,2})
                    //.SetForceDelegation(false)
                    .Build();
                BillingService.SendInvoicePaymentSms(sendInvoicePaymentSmsVo,
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
        public ResultSrv<bool> PayInvoice()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var payInvoiceVo = PayInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetInvoiceId(6859393)
                    .Build();
                BillingService.PayInvoice(payInvoiceVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetInvoiceId(4289142)
                    .SetDate("1398/07/05")
                    .SetOtt(ottOutput.Ott)
                    .SetGuildCode("TOILETRIES_GUILD")
                    //.SetWallet("")
                    .Build();
                BillingService.PayInvoice(payInvoiceInFutureVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetCreditorInvoiceId(3164963)
                    .SetDebtorInvoiceId(3164833)
                    .Build();
                BillingService.PayInvoice(payInvoiceByInvoiceVo,
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
        public ResultSrv<bool> PayInvoiceByCredit()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var ottOutput = GetOtt();
                var payInvoiceByCreditVo = PayInvoiceByCreditVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOtt(ottOutput.Ott)
                    .SetInvoiceId(6906020)
                    //.SetWallet("PODLAND_WALLET")
                    //.SetForceDelegation(false)
                    //.SetDelegatorId(new long[]{0})
                    //.SetDelegationHash(new []{""})
                    .Build();
                BillingService.PayInvoice(payInvoiceByCreditVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<bool> PayAnyInvoiceByCredit()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var ottOutput = GetOtt();
                var payInvoiceByInvoiceVo = PayInvoiceByCreditVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOtt(ottOutput.Ott)
                    .SetInvoiceId(3163071)
                    .SetWallet("PODLAND_WALLET")
                    //.SetForceDelegation(false)
                    //.SetDelegatorId(new long[]{0})
                    //.SetDelegationHash(new []{""})
                    .Build();
                BillingService.PayAnyInvoice(payInvoiceByInvoiceVo,
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
                var output = new ResultSrv<ServiceCallResultSrv<PrivateCallSrv>>();
                var ottOutput = GetOtt();
                var createPreInvoiceVo = CreatePreInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetApiToken("")
                    .SetOtt(ottOutput.Ott)
                    .SetProductsInfo(new List<ProductInfo>
                    {
                        ProductInfo.ConcreteBuilder.SetProductId(0).SetPrice(1200).SetQuantity(3).SetProductDescription("tst").Build(),
                        ProductInfo.ConcreteBuilder.SetProductId(0).SetPrice(1400).SetQuantity(3).SetProductDescription("tst1").Build()
                    })
                    .SetGuildCode(GuildCode)
                    .SetRedirectUri("")
                    .SetUserId(1468849)
                    //.SetBillNumber("")
                    //.SetCallUrl("")
                    //.SetCurrencyCode("")
                    //.SetDeadline("")
                    //.SetDescription("")
                    //.SetPreferredTaxRate(1)
                    //.SetRedirectUri("")
                    //.SetVerificationNeeded(false)
                    .Build();
                BillingService.CreatePreInvoice(createPreInvoiceVo,response => Listener.GetResult(response, out output));
                var linkSrv = createPreInvoiceVo.GetLink(output);

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
                    .SetInvoiceId(6860137)
                    //.SetCallUri("")
                    .SetRedirectUri("")
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetInvoiceId(6859734)
                    .Build();
                BillingService.GetInvoicePaymentLink(getInvoicePaymentLinkVo,response => Listener.GetResult(response, out output));
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
                    .SetUniqueNumber("")
                    .SetGateway("PEP")
                    .SetRedirectUri("")
                    //.SetCallUri("")
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetAmount(10)
                    .SetOtt(ottOutput.Ott)
                    //.SetWallet("")
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetSheba("")
                    //.SetCurrencyCode("IRR")
                    //.SetUniqueId("")
                    //.SetDescription("")
                    .Build();
                BillingService.RequestSettlement(requestWalletSettlementVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetGuildCode("TOILETRIES_GUILD")
                    .SetAmount(100)
                    .SetOtt(ottOutput.Ott)
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetSheba("")
                    //.SetCurrencyCode("")
                    //.SetUniqueId("")
                    //.SetDescription("")
                    .Build();
                BillingService.RequestSettlement(requestGuildSettlementVo,
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetToolCode(ToolCode.SETTLEMENT_TOOL_CARD)
                    .SetToolId("")
                    .SetAmount(0)
                    .SetGuildCode("TOILETRIES_GUILD")
                    .SetOtt(ottOutput.Ott)
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetCurrencyCode("")
                    //.SetUniqueId("")
                    //.SetDescription("")
                    .Build();
                BillingService.RequestSettlement(requestSettlementByToolVo,
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //.SetStatusCode(SettlementStatusCode.SETTLEMENT_DONE)
                    //.SetFromAmount(0)
                    //.SetToAmount(0)
                    //.SetFromDate("")
                    //.SetToDate(DateTime.Now)
                    //.SetUniqueId("")
                    //.SetCurrencyCode("")
                    //.SetId(0)
                    //.SetFirstName("")
                    //.SetLastName("")
                    //.SetToolCode(ToolCode.SETTLEMENT_TOOL_SATNA)
                    //.SetToolId("")
                    .Build();
                BillingService.ListSettlements(listSettlementsVo, response => Listener.GetResult(response, out output));
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
                var output = new ResultSrv<bool>();
                var addAutoSettlementVo = AddAutoSettlementVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetGuildCode(GuildCode)
                    //.SetFirstName("{Put your FirstName}")
                    //.SetLastName("{Put your LastName}")
                    //.SetSheba("{Put your Sheba}")
                    //.SetCurrencyCode("{Put your CurrencyCode}")
                    //.SetInstant({Put your Instant})
                    .Build();
                BillingService.AddAutoSettlement(addAutoSettlementVo, response => Listener.GetResult(response, out output));
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
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetGuildCode(GuildCode)
                    //.SetCurrencyCode("{Put your CurrencyCode}")
                    .Build();
                BillingService.RemoveAutoSettlement(registerUserVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<InvoiceSrv> IssueMultiInvoice()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var ottOutput = GetOtt();
                var mainInvoiceVos = MainInvoiceVo.ConcreteBuilder
                    .SetGuildCode("TOILETRIES_GUILD")
                    .SetInvoiceItemVOs(new List<InvoiceItemVo>
                    {
                        InvoiceItemVo.ConcreteBuilder.SetProductId(0).SetDescription("tst5").SetPrice(100).SetQuantity(2).Build()
                    })
                    //.SetBillNumber("")
                    .SetDescription("main")
                    //.SetMetadata("")
                    .Build();
                  
                var subInvoiceVos = new List<SubInvoiceVo>
                {
                    SubInvoiceVo.ConcreteBuilder
                        .SetBusinessId(3612)
                        .SetGuildCode("TOILETRIES_GUILD")
                        .SetInvoiceItemVOs(new List<InvoiceItemVo>
                        {
                            InvoiceItemVo.ConcreteBuilder.SetProductId(0).SetDescription("tst5").SetPrice(100).SetQuantity(2).Build()
                        })
                        //.SetBillNumber("")
                        .SetDescription("sub")
                        //.SetMetadata("")
                        .Build()
                   
                };
                var customerInvoiceItems = new List<InvoiceItemVo>
                {
                    InvoiceItemVo.ConcreteBuilder.SetProductId(0).SetDescription("tst1").SetPrice(200).SetQuantity(2).Build()
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
                    .SetUserId(1468849)
                    //.SetVerificationNeeded(false)
                    //.SetVoucherHashs(new string[] { })
                    .Build();

                var issueMultiInvoiceVo = IssueMultiInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOtt(ottOutput.Ott)
                    .SetData(multiInvoiceData)
                    .SetDelegationHash(new string[]{"cc"})
                    .SetDelegatorId(new long[]{1234})
                    //.SetForceDelegation(false)
                    .Build();
                BillingService.IssueMultiInvoice(issueMultiInvoiceVo, response => Listener.GetResult(response, out output));
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
                    .SetId(6878196)
                    .SetReduceInvoiceItemVOs(new List<ReduceInvoiceSubItemVo>
                    {
                        ReduceInvoiceSubItemVo.ConcreteBuilder.SetId(3583750).SetDescription("tst15").SetPrice(5)
                            .SetQuantity(1).Build()
                    })
                    .Build();

                var subInvoiceVos = new List<ReduceInvoiceItemVo>
                {
                    ReduceInvoiceItemVo.ConcreteBuilder
                        .SetId(6878197)
                        .SetReduceInvoiceItemVOs(new List<ReduceInvoiceSubItemVo>
                        {
                            ReduceInvoiceSubItemVo.ConcreteBuilder.SetId(3583751).SetDescription("tst15").SetPrice(5)
                                .SetQuantity(1).Build()
                        })
                        .Build()
                };
                var customerInvoiceItems = new List<ReduceInvoiceSubItemVo>
                {
                    ReduceInvoiceSubItemVo.ConcreteBuilder.SetId(6878195).SetDescription("tst155").SetPrice(10).SetQuantity(1)
                        .Build()
                };

                var reduceMultiInvoiceDataVo = ReduceMultiInvoiceDataVo.ConcreteBuilder
                    .SetMainInvoice(mainInvoiceVos)
                    .SetSubInvoices(subInvoiceVos)
                    .SetCustomerInvoiceItemVOs(customerInvoiceItems)
                    //.SetPreferredTaxRate(0)
                    .Build();

                var reduceMultiInvoiceVo = ReduceMultiInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetData(reduceMultiInvoiceDataVo)
                    .Build();
                BillingService.ReduceMultiInvoice(reduceMultiInvoiceVo, response => Listener.GetResult(response, out output));
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
                    .SetId(3549989)
                    .SetReduceInvoiceItemVOs(new List<ReduceInvoiceSubItemVo>
                    {
                        ReduceInvoiceSubItemVo.ConcreteBuilder.SetId(3588066).SetDescription("tst15").SetPrice(50)
                            .SetQuantity(2).Build()
                    })
                    .Build();

                var subInvoiceVos = new List<ReduceInvoiceItemVo>
                {
                    ReduceInvoiceItemVo.ConcreteBuilder
                        .SetId(3549990)
                        .SetReduceInvoiceItemVOs(new List<ReduceInvoiceSubItemVo>
                        {
                            ReduceInvoiceSubItemVo.ConcreteBuilder.SetId(3588067).SetDescription("tst15").SetPrice(50)
                                .SetQuantity(2).Build()
                        })
                        .Build()
                };
                var customerInvoiceItems = new List<ReduceInvoiceSubItemVo>
                {
                    ReduceInvoiceSubItemVo.ConcreteBuilder.SetId(6877893).SetDescription("tst155").SetPrice(100).SetQuantity(2)
                        .Build()
                };

                var reduceMultiInvoiceDataVo = ReduceMultiInvoiceDataVo.ConcreteBuilder
                    .SetMainInvoice(mainInvoiceVos)
                    .SetSubInvoices(subInvoiceVos)
                    .SetCustomerInvoiceItemVOs(customerInvoiceItems)
                    //.SetPreferredTaxRate(0)
                    .Build();

                var reduceMultiInvoiceAndCashoutVo = ReduceMultiInvoiceAndCashoutVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetData(reduceMultiInvoiceDataVo)
                    .SetToolCode(ToolCode.SETTLEMENT_TOOL_CARD)
                    .Build();
                BillingService.ReduceMultiInvoiceAndCashout(reduceMultiInvoiceAndCashoutVo, response => Listener.GetResult(response, out output));
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

        #region Voucher

        public ResultSrv<List<VoucherSrv>> DefineCreditVoucher()
        {
            try
            {
                var output = new ResultSrv<List<VoucherSrv>>();
                var defineCreditVoucherVo = DefineCreditVoucherVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetGuildCode(GuildCode)
                    .SetExpireDate("1398/08/01")
                    .SetVouchersContent(new List<VoucherContentVo>
                    {
                       VoucherContentVo.ConcreteBuilder.SetName("BonTst1").SetAmount(0).SetCount(1).SetDescription("tst").SetHashCodes(new []{"yuotytteve"}).Build(),
                       VoucherContentVo.ConcreteBuilder.SetName("BonTst2").SetAmount(0).SetCount(2).SetDescription("tst").SetHashCodes(new []{"retywttqeve","btyttnmeve"}).Build()
                    })
                    //.SetLimitedConsumerId(3)
                    //.SetCurrencyCode("IRR")
                    .Build();
                BillingService.DefineVoucher(defineCreditVoucherVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<VoucherSrv>> DefineDiscountAmountVoucher()
        {
            try
            {
                var output = new ResultSrv<List<VoucherSrv>>();
                var defineDiscountAmountVoucherVo = DefineDiscountAmountVoucherVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetGuildCode(GuildCode)
                    .SetExpireDate("1398/08/01")
                    .SetVouchersContent(new List<VoucherContentVo>
                    {
                        VoucherContentVo.ConcreteBuilder.SetName("BonTst11").SetAmount(1.1M).SetCount(1).SetDescription("tst").SetHashCodes(new []{"etyrktttef"}).Build(),
                        VoucherContentVo.ConcreteBuilder.SetName("BonTst21").SetAmount(1.1m).SetCount(2).SetDescription("tst").SetHashCodes(new []{"ertyt5ttkef","ertyttkt6ef"}).Build()
                    })
                    //.SetLimitedConsumerId(0)
                    .SetCurrencyCode("IRR")
                    .SetEntityId(new long[]{ 29468 , 29466 })
                    .SetDealerBusinessId(new long[]{3605})
                    .Build();
                BillingService.DefineVoucher(defineDiscountAmountVoucherVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<VoucherSrv>> DefineDiscountPercentageVoucher()
        {
            try
            {
                var output = new ResultSrv<List<VoucherSrv>>();
                var defineDiscountPercentageVoucherVo = DefineDiscountPercentageVoucherVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetGuildCode(GuildCode)
                    .SetExpireDate("1398/08/01")
                    .SetVouchersContent(new List<DiscountVoucherContentVo>
                    {
                        DiscountVoucherContentVo.ConcreteBuilder.SetName("BonTest").SetAmount(0).SetCount(1).SetDescription("tst").SetHashCodes(new []{"bvf6ttktye"}).SetDiscountPercentage(10).Build(),
                        DiscountVoucherContentVo.ConcreteBuilder.SetName("BonTst2").SetAmount(0).SetCount(2).SetDescription("tst").SetHashCodes(new []{"rewqekttyvt6e","bnyttmtekv8e"}).SetDiscountPercentage(20).Build()
                    })
                    .SetType(VoucherType.UnLimited)
                    //.SetLimitedConsumerId(0)
                    //.SetCurrencyCode("")
                    //.SetEntityId(new long[] { 0 })
                    //.SetDealerBusinessId(new long[] { 0 })
                    .Build();
                BillingService.DefineVoucher(defineDiscountPercentageVoucherVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<InvoiceSrv> ApplyVoucher()
        {
            try
            {
                var output = new ResultSrv<InvoiceSrv>();
                var applyVoucherVo = ApplyVoucherVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetInvoiceId(6485293)
                    .SetVoucherHash(new []{ "" })
                    .SetOtt("6ffd18730f2ea512")
                    //.SetPreview(false)
                    .Build();
                BillingService.ApplyVoucher(applyVoucherVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<VoucherSrv>> GetVoucherList()
        {
            try
            {
                var output = new ResultSrv<List<VoucherSrv>>();
                var getVoucherListVo = GetVoucherListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //.SetConsumerId(0)
                    //.SetHashCode("ILNG26MII549")
                    //.SetVoucherName("")
                    //.SetType(VoucherType.UnLimited)
                    //.SetGuildCodes(new []{ "ENGINEERING_GUILD" })
                    //.SetCurrencyCode("")
                    //.SetAmountFrom(0)
                    //.SetAmountTo(0)
                    //.SetDiscountPercentageFrom(0)
                    //.SetDiscountPercentageTo(0)
                    //.SetExpireDateFrom("")
                    //.SetExpireDateTo("")
                    //.SetEntityId(new long[]{0})
                    //.SetConsumeDateFrom("")
                    //.SetConsumeDateTo("")
                    //.SetUsedAmountFrom(0)
                    //.SetUsedAmountTo(0)
                    //.SetActive(false)
                    //.SetUsed(false)
                    .Build();
                BillingService.GetVoucherList(getVoucherListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<VoucherSrv> ActivateVoucher()
        {
            try
            {
                var output = new ResultSrv<VoucherSrv>();
                var activateVoucherVo = DeactivateVoucherVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetVoucherId(261717)
                    .Build();
                BillingService.ActivateVoucher(activateVoucherVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<VoucherSrv> DeactivateVoucher()
        {
            try
            {
                var output = new ResultSrv<VoucherSrv>();
                var deactivateVoucherVo = DeactivateVoucherVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                   .SetVoucherId(261717)
                    .Build();
                BillingService.DeactivateVoucher(deactivateVoucherVo, response => Listener.GetResult(response, out output));
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

        #endregion Voucher

        #region DirectDebit

        public ResultSrv<DirectWithdrawSrv> DefineDirectWithdraw()
        {
            try
            {
                var output = new ResultSrv<DirectWithdrawSrv>();
                var defineDirectWithdrawVo = DefineDirectWithdrawVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetDepositNumber("")
                    .SetMinAmount(10)
                    .SetMaxAmount(5)
                    .SetOnDemand(false)
                    .SetPrivateKeyFromFile(@"")
                    .SetUsername("fdd")
                    .SetWallet("PODLAND_WALLET")
                    .Build();
                BillingService.DefineDirectWithdraw(defineDirectWithdrawVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<DirectWithdrawSrv>> GetDirectWithdrawList()
        {
            try
            {
                var output = new ResultSrv<List<DirectWithdrawSrv>>();
                var directWithdrawListVo =DirectWithdrawListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetWallet("PODLAND_WALLET")
                    .SetOffset(0)
                    .SetSize(10)
                    .Build();
                BillingService.GetDirectWithdrawList(directWithdrawListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<DirectWithdrawSrv> UpdateDirectWithdraw()
        {
            try
            {
                var output = new ResultSrv<DirectWithdrawSrv>();
                var updateDirectWithdrawVo = UpdateDirectWithdrawVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(143)
                    .SetDepositNumber("")
                    .SetMinAmount(10)
                    .SetMaxAmount(5)
                    .SetOnDemand(false)
                    .SetPrivateKeyFromFile(@"")
                    .SetUsername("vgf")
                    .SetWallet("PODLAND_WALLET")
                    .Build();
                BillingService.UpdateDirectWithdraw(updateDirectWithdrawVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<bool> RevokeDirectWithdraw()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var revokeDirectWithdrawVo = RevokeDirectWithdrawVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(143)
                    .Build();
                BillingService.RevokeDirectWithdraw(revokeDirectWithdrawVo, response => Listener.GetResult(response, out output));
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

        #endregion DirectDebit
    }
}
