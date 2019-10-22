
namespace POD_Billing.Model.ServiceOutput.DirectDebit
{
    public class DirectWithdrawSrv
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string DepositNumber { get; set; }
        public string Wallet { get; set; }
        public bool OnDemand { get; set; }
        public long MinAmount { get; set; }
        public long MaxAmount { get; set; }
        public long CreationDate { get; set; }
    }
}
