using POD_Base_Service.Model.ServiceOutput;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class CustomerAmountSrv
    {
        public decimal Amount { get; set; }
        public CurrencySrv CurrencySrv { get; set; }
        public bool IsAutoSettle { get; set; }
        public string Wallet { get; set; }
        public string WalletName { get; set; }
        public bool Active { get; set; }
        public string UniqueId { get; set; }
        public bool Block { get; set; }
    }
}
