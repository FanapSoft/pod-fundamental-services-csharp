using POD_Base_Service.Model.ServiceOutput;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class BusinessAmountSrv
    {
        public decimal Amount { get; set; }
        public decimal WithdrawableAmount { get; set; }
        public GuildSrv GuildSrv { get; set; }
        public CurrencySrv CurrencySrv { get; set; }
        public bool IsAutoSettle { get; set; }
        public string Number { get; set; }
        public string UniqueId { get; set; }
    }
}
