using POD_Base_Service.Model.ServiceOutput;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class TransferCreditSrv
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public CurrencySrv Currency { get; set; }
        public string Wallet { get; set; }
        public string Description { get; set; }
        public string UniqueId { get; set; }
    }
}
