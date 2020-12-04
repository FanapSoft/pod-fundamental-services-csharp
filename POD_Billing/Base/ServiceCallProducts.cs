using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;

namespace POD_Billing.Base
{
    internal static class ServiceCallProducts
    {
        internal static long IssueInvoice => Config.ServerType == ServerType.SandBox ? 39291 : 29796;
        internal static long CreatePreInvoice => Config.ServerType == ServerType.SandBox ? 30359 : 30359;
        internal static long GetInvoiceList => Config.ServerType == ServerType.SandBox ? 39308 : 29813;
        internal static long SendInvoicePaymentSms => Config.ServerType == ServerType.SandBox ? 39302 : 29807;
        internal static long GetInvoiceListByMetadata => Config.ServerType == ServerType.SandBox ? 39309 : 29814;
        internal static long GetInvoiceListAsFile => Config.ServerType == ServerType.SandBox ? 39312 : 29817;
        internal static long VerifyInvoice => Config.ServerType == ServerType.SandBox ? 39304 : 29809;
        internal static long CancelInvoice => Config.ServerType == ServerType.SandBox ? 39305 : 29810;
        internal static long ReduceInvoice => Config.ServerType == ServerType.SandBox ? 39298 : 29803;
        internal static long VerifyAndCloseInvoice => Config.ServerType == ServerType.SandBox ? 39303 : 29808;
        internal static long CloseInvoice => Config.ServerType == ServerType.SandBox ? 39307 : 29812;
        internal static long GetInvoicePaymentLink => Config.ServerType == ServerType.SandBox ? 39310 : 29815;
        internal static long PayInvoice => Config.ServerType == ServerType.SandBox ? 39294 : 29799;
        internal static long PayInvoiceByInvoice => Config.ServerType == ServerType.SandBox ? 39295 : 29800;
        internal static long PayInvoiceInFuture => Config.ServerType == ServerType.SandBox ? 39297 : 29802;
        internal static long PayAnyInvoiceByCredit => Config.ServerType == ServerType.SandBox ? 39317 : 29821;
        internal static long PayInvoiceByCredit => Config.ServerType == ServerType.SandBox ? 39316 : 30382;
        internal static long GetExportList => Config.ServerType == ServerType.SandBox ? 39313 : 29818;
        internal static long RequestWalletSettlement => Config.ServerType == ServerType.SandBox ? 39372 : 29986;
        internal static long RequestGuildSettlement => Config.ServerType == ServerType.SandBox ? 39373 : 29987;
        internal static long RequestSettlementByTool => Config.ServerType == ServerType.SandBox ? 39374 : 29988;
        internal static long ListSettlements => Config.ServerType == ServerType.SandBox ? 39375 : 29989;
        internal static long AddAutoSettlement => Config.ServerType == ServerType.SandBox ? 39376 : 29990;
        internal static long RemoveAutoSettlement => Config.ServerType == ServerType.SandBox ? 39377 : 29991;
        internal static long IssueMultiInvoice => Config.ServerType == ServerType.SandBox ? 39293 : 29798;
        internal static long ReduceMultiInvoice => Config.ServerType == ServerType.SandBox ? 39300 : 29805;
        internal static long ReduceMultiInvoiceAndCashOut => Config.ServerType == ServerType.SandBox ? 39301 : 29806;
        internal static long DefineCreditVoucher => Config.ServerType == ServerType.SandBox ? 39362 : 29975;
        internal static long DefineDiscountAmountVoucher => Config.ServerType == ServerType.SandBox ? 39363 : 29976;
        internal static long DefineDiscountPercentageVoucher => Config.ServerType == ServerType.SandBox ? 39364 : 29977;
        internal static long ApplyVoucher => Config.ServerType == ServerType.SandBox ? 39306 : 29811;
        internal static long GetVoucherList => Config.ServerType == ServerType.SandBox ? 39365 : 29979;
        internal static long DeactivateVoucher => Config.ServerType == ServerType.SandBox ? 39366 : 29980;
        internal static long ActivateVoucher => Config.ServerType == ServerType.SandBox ? 39367 : 29981;
        internal static long DefineDirectWithdraw => Config.ServerType == ServerType.SandBox ? 39368 : 29982;
        internal static long DirectWithdrawList => Config.ServerType == ServerType.SandBox ? 39369 : 29983;
        internal static long UpdateDirectWithdraw => Config.ServerType == ServerType.SandBox ? 39370 : 29984;
        internal static long RevokeDirectWithdraw => Config.ServerType == ServerType.SandBox ? 39371 : 29985;
    }
}
