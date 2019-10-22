using System;
using System.Collections.Generic;
using POD_Base_Service;
using RestSharp;
using POD_Billing.Model.ServiceOutput;
using POD_Billing.Model.ValueObject;
using POD_Billing.Base;
using POD_Billing.Model.ServiceOutput.DirectDebit;
using POD_Billing.Model.ServiceOutput.Voucher;
using POD_Billing.Model.ValueObject.DirectDebit;
using POD_Billing.Model.ValueObject.Settlement;
using POD_Billing.Model.ValueObject.Voucher;
using POD_Billing.Model.ServiceOutput.Settlement;
using POD_Billing.Model.ValueObject.Sharing;
using POD_Base_Service.Result;

namespace POD_Billing
{
    public static class BillingService
    {
        public static void IssueInvoice(IssueInvoiceVo issueInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.IssueInvoice, issueInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public static void VerifyInvoice(VerifyInvoiceVo verifyInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.VerifyInvoice, verifyInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public static void CloseInvoice(CloseInvoiceVo closeInvoiceVo, Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CloseInvoice, closeInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public static void VerifyAndCloseInvoice(VerifyAndCloseInvoiceVo verifyAndCloseInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.VerifyAndCloseInvoice, verifyAndCloseInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public static void CancelInvoice(CancelInvoiceVo cancelInvoiceVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CancelInvoice, cancelInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public static void GetInvoiceList(GetInvoiceListVo getInvoiceListVo,
            Action<IRestResponse<ResultSrv<List<InvoiceSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetInvoiceList, getInvoiceListVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<InvoiceSrv>>>(request));
        }

        public static void GetInvoiceListByMetadata(GetInvoiceListByMetadataVo getInvoiceListByMetadataVo,
            Action<IRestResponse<ResultSrv<List<InvoiceSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetInvoiceListByMetadata, getInvoiceListByMetadataVo,
                PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<InvoiceSrv>>>(request));
        }

        public static void GetInvoiceListAsFile(GetInvoiceListAsFileVo getInvoiceListAsFileVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetInvoiceListAsFile, getInvoiceListAsFileVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public static void ReduceInvoice(ReduceInvoiceVo reduceInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ReduceInvoice, reduceInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public static void GetExportList(GetExportListVo getExportListVo,
            Action<IRestResponse<ResultSrv<List<ExportServiceSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetExportList, getExportListVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<ExportServiceSrv>>>(request));
        }

        public static void SendInvoicePaymentSms(SendInvoicePaymentSmsVo sendInvoicePaymentSmsVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.SendInvoicePaymentSms, sendInvoicePaymentSmsVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }
        public static void PayInvoice(PayInvoiceVo payInvoiceVo, Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PayInvoice, payInvoiceVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }
        public static void PayInvoice(PayInvoiceInFutureVo payInvoiceInFutureVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PayInvoiceInFuture, payInvoiceInFutureVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public static void PayInvoice(PayInvoiceByInvoiceVo payInvoiceByInvoiceVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PayInvoiceByInvoice, payInvoiceByInvoiceVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public static void PayInvoice(PayInvoiceByCreditVo payInvoiceByCreditVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PayInvoiceByCredit, payInvoiceByCreditVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }
        public static void PayAnyInvoice(PayInvoiceByCreditVo payInvoiceByCreditVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PayAnyInvoiceByCredit, payInvoiceByCreditVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public static void CreatePreInvoice(CreatePreInvoiceVo createPreInvoiceVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<PrivateCallSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CreatePreInvoice, createPreInvoiceVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<PrivateCallSrv>>>(request));
        }

        public static void GetInvoicePaymentLink(GetInvoicePaymentLinkVo getInvoicePaymentLinkVo,
            Action<IRestResponse<ResultSrv<string>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetInvoicePaymentLink, getInvoicePaymentLinkVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }

        #region Settlement

        public static void RequestSettlement(RequestWalletSettlementVo requestWalletSettlementVo,
            Action<IRestResponse<ResultSrv<SettlementRequestSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.RequestWalletSettlement, requestWalletSettlementVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<SettlementRequestSrv>>(request));
        }

        public static void RequestSettlement(RequestGuildSettlementVo requestGuildSettlementVo,
            Action<IRestResponse<ResultSrv<SettlementRequestSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.RequestGuildSettlement, requestGuildSettlementVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<SettlementRequestSrv>>(request));
        }

        public static void RequestSettlement(RequestSettlementByToolVo requestSettlementByToolVo,
            Action<IRestResponse<ResultSrv<SettlementRequestSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.RequestSettlementByTool, requestSettlementByToolVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<SettlementRequestSrv>>(request));
        }

        public static void ListSettlements(ListSettlementsVo listSettlementsVo,
            Action<IRestResponse<ResultSrv<List<SettlementRequestSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ListSettlements, listSettlementsVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<SettlementRequestSrv>>>(request));
        }

        public static void AddAutoSettlement(AddAutoSettlementVo addAutoSettlementVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.AddAutoSettlement, addAutoSettlementVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public static void RemoveAutoSettlement(RemoveAutoSettlementVo removeAutoSettlementVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.RemoveAutoSettlement, removeAutoSettlementVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }


        #endregion Settlement

        #region Sharing

        public static void IssueMultiInvoice(IssueMultiInvoiceVo issueMultiInvoiceListVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.IssueMultiInvoice, issueMultiInvoiceListVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public static void ReduceMultiInvoice(ReduceMultiInvoiceVo reduceMultiInvoiceVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ReduceMultiInvoice, reduceMultiInvoiceVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public static void ReduceMultiInvoiceAndCashout(ReduceMultiInvoiceAndCashoutVo reduceMultiInvoiceAndCashoutVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ReduceMultiInvoiceAndCashOut,
                reduceMultiInvoiceAndCashoutVo, PodParameterName.ParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        #endregion Sharing

        #region Voucher

        public static void DefineVoucher(DefineCreditVoucherVo defineCreditVoucherVo,
            Action<IRestResponse<ResultSrv<List<VoucherSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DefineCreditVoucher, defineCreditVoucherVo,
                PodParameterName.VoucherParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<VoucherSrv>>>(request));
        }

        public static void DefineVoucher(DefineDiscountAmountVoucherVo defineDiscountAmountVoucherVo,
            Action<IRestResponse<ResultSrv<List<VoucherSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DefineDiscountAmountVoucher,
                defineDiscountAmountVoucherVo, PodParameterName.VoucherParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<VoucherSrv>>>(request));
        }

        public static void DefineVoucher(DefineDiscountPercentageVoucherVo defineDiscountPercentageVoucherVo,
            Action<IRestResponse<ResultSrv<List<VoucherSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DefineDiscountPercentageVoucher,
                defineDiscountPercentageVoucherVo, PodParameterName.VoucherParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<List<VoucherSrv>>>(request));
        }

        public static void ApplyVoucher(ApplyVoucherVo applyVoucherVo,
            Action<IRestResponse<ResultSrv<InvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ApplyVoucher, applyVoucherVo,
                PodParameterName.VoucherParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<InvoiceSrv>>(request));
        }

        public static void GetVoucherList(GetVoucherListVo getVoucherListVo,
            Action<IRestResponse<ResultSrv<List<VoucherSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetVoucherList, getVoucherListVo,
                PodParameterName.VoucherParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<VoucherSrv>>>(request));
        }

        public static void ActivateVoucher(DeactivateVoucherVo deactivateVoucherVo,
            Action<IRestResponse<ResultSrv<VoucherSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ActivateVoucher, deactivateVoucherVo,
                PodParameterName.VoucherParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<VoucherSrv>>(request));
        }

        public static void DeactivateVoucher(DeactivateVoucherVo deactivateVoucherVo,
            Action<IRestResponse<ResultSrv<VoucherSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DeactivateVoucher, deactivateVoucherVo,
                PodParameterName.VoucherParametersName,
                out var client, out var request);
            callback(client.Execute<ResultSrv<VoucherSrv>>(request));
        }

        #endregion Voucher

        #region DirectDebit

        public static void DefineDirectWithdraw(DefineDirectWithdrawVo defineDirectWithdrawVo,
            Action<IRestResponse<ResultSrv<DirectWithdrawSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DefineDirectWithdraw, defineDirectWithdrawVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<DirectWithdrawSrv>>(request));
        }

        public static void GetDirectWithdrawList(DirectWithdrawListVo directWithdrawListVo,
            Action<IRestResponse<ResultSrv<List<DirectWithdrawSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.DirectWithdrawList, directWithdrawListVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<List<DirectWithdrawSrv>>>(request));
        }

        public static void UpdateDirectWithdraw(UpdateDirectWithdrawVo updateDirectWithdrawVo,
            Action<IRestResponse<ResultSrv<DirectWithdrawSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.UpdateDirectWithdraw, updateDirectWithdrawVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<DirectWithdrawSrv>>(request));
        }

        public static void RevokeDirectWithdraw(RevokeDirectWithdrawVo revokeDirectWithdrawVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.RevokeDirectWithdraw, revokeDirectWithdrawVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        #endregion DirectDebit
    }
}
