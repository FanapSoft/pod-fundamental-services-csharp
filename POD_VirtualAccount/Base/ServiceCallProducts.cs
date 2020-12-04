using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;

namespace POD_VirtualAccount.Base
{
    internal static class ServiceCallProducts
    {
        internal static long IssueCreditInvoiceAndGetHash => Config.ServerType == ServerType.SandBox ? 42584 : 34976;
        internal static long VerifyCreditInvoice => Config.ServerType == ServerType.SandBox ? 42585 : 34977;
        internal static long TransferFromOwnAccounts => Config.ServerType == ServerType.SandBox ? 42586 : 34978;
        internal static long TransferFromOwnAccountsList => Config.ServerType == ServerType.SandBox ? 42587 : 34979;
        internal static long TransferToContact => Config.ServerType == ServerType.SandBox ? 42588 : 34980;
        internal static long TransferToContactList => Config.ServerType == ServerType.SandBox ? 42589 : 34981;
        internal static long Follow => Config.ServerType == ServerType.SandBox ? 42590 : 34982;
        internal static long GetFollowers => Config.ServerType == ServerType.SandBox ? 42591 : 34983;
        internal static long GetBusiness => Config.ServerType == ServerType.SandBox ? 42592 : 34984;
        internal static long TransferToFollower => Config.ServerType == ServerType.SandBox ? 42593 : 34985;
        internal static long TransferToFollowerAndCashout => Config.ServerType == ServerType.SandBox ? 42594 : 34986;
        internal static long TransferToFollowerList => Config.ServerType == ServerType.SandBox ? 42595 : 34987;
        internal static long TransferByInvoice => Config.ServerType == ServerType.SandBox ? 42596 : 34988;
        internal static long ListTransferByInvoice => Config.ServerType == ServerType.SandBox ? 42597 : 34989;
        internal static long GetGuildAccountBill => Config.ServerType == ServerType.SandBox ? 42598 : 34990;
        internal static long GetWalletAccountBill => Config.ServerType == ServerType.SandBox ? 42599 : 34991;
        internal static long GetAccountBillAsFile => Config.ServerType == ServerType.SandBox ? 42600 : 34992;
        internal static long CardToCardList => Config.ServerType == ServerType.SandBox ? 42601 : 34993;
        internal static long UpdateCardToCard => Config.ServerType == ServerType.SandBox ? 42602 : 34994;
    }
}
