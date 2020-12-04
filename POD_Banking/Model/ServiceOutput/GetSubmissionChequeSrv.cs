
namespace POD_Banking.Model.ServiceOutput
{
    public class GetSubmissionChequeSrv
    {
        public string Date { get; set; }
        public string Number { get; set; }
        public string Amount { get; set; }
        public string IssuerBank { get; set; }
        public string IssuerBankCode { get; set; }
        public string SubmitionDate { get; set; }
        public string TransferMoneyBillNumber { get; set; }
        public string Status { get; set; }
        public string TypeCode { get; set; }
    }
}
