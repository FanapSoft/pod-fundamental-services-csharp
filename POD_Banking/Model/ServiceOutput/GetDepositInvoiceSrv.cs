
namespace POD_Banking.Model.ServiceOutput
{
    public class GetDepositInvoiceSrv
    {
        public string TransactionDate { get; set; }
        public string DeptorAmount { get; set; }
        public string Description { get; set; }
        public string DocNumber { get; set; }
        public string ChqNumber { get; set; }
        public string Amount { get; set; }
        public string PaymentId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
    }
}
