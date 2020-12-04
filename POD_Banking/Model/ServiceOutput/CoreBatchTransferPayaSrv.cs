
namespace POD_Banking.Model.ServiceOutput
{
    public class CoreBatchTransferPayaSrv
    {
        public string ReferenceNumber { get; set; }
        public string DestinationBankName { get; set; }
        public string State { get; set; }
        public string Amount { get; set; }
        public string BeneficiaryFullName { get; set; }
        public string Description { get; set; }
        public string DestShebaNumber { get; set; }
        public string BillNumber { get; set; }
    }
}
