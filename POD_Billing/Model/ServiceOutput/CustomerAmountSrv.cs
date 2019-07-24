
namespace POD_Billing.Model.ServiceOutput
{
    public class CustomerAmountSrv
    {
        public double Amount { get; set; }
        public CurrencySrv CurrencySrv { get; set; }
        public bool IsAutoSettle { get; set; }
        public string Wallet { get; set; }
        public string WalletName { get; set; }
        public bool Active { get; set; }
        public string UniqueId { get; set; }
        public bool Block { get; set; }
    }
}
