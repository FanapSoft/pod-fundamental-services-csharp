namespace POD_Billing.Base
{
    internal static class ServiceCallProducts
    {
        internal const long IssueInvoice = 29796;
        internal const long CreatePreInvoice = 30359;
        internal const long GetInvoiceList = 29813;
        internal const long SendInvoicePaymentSms = 29807;
        internal const long GetInvoiceListByMetadata = 29814;
        internal const long GetInvoiceListAsFile = 29817;
        internal const long VerifyInvoice = 29809;
        internal const long CancelInvoice = 29810;
        internal const long ReduceInvoice = 29803;
        internal const long VerifyAndCloseInvoice = 29808;
        internal const long CloseInvoice = 29812;
        internal const long GetInvoicePaymentLink = 29815;
        internal const long PayInvoice = 29799;
        internal const long PayInvoiceByInvoice = 29800;
        internal const long PayInvoiceInFuture = 29802;
        internal const long PayAnyInvoiceByCredit = 29821;
        internal const long PayInvoiceByCredit = 30382;
        internal const long GetExportList = 29818;
        internal const long RequestWalletSettlement = 29986;
        internal const long RequestGuildSettlement = 29987;
        internal const long RequestSettlementByTool = 29988;
        internal const long ListSettlements = 29989;
        internal const long AddAutoSettlement = 29990;
        internal const long RemoveAutoSettlement = 29991;
        internal const long IssueMultiInvoice = 29798;
        internal const long ReduceMultiInvoice = 29805;
        internal const long ReduceMultiInvoiceAndCashOut = 29806;
        internal const long DefineCreditVoucher = 29975;
        internal const long DefineDiscountAmountVoucher = 29976;
        internal const long DefineDiscountPercentageVoucher = 29977;
        internal const long ApplyVoucher = 29811;
        internal const long GetVoucherList = 29979;
        internal const long DeactivateVoucher = 29980;
        internal const long ActivateVoucher = 29981;
        internal const long DefineDirectWithdraw = 29982;
        internal const long DirectWithdrawList = 29983;
        internal const long UpdateDirectWithdraw = 29984;
        internal const long RevokeDirectWithdraw = 29985;
    }
}
