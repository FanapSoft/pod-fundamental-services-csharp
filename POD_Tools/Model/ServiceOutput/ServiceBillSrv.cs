using System;

namespace POD_Tools.Model.ServiceOutput
{
    public class ServiceBillSrv
    {
        public long Id { get; set; }
        public string BillId { get; set; }
        public string PaymentId { get; set; }
        public double Price { get; set; }
        public string UtilityCompanyName { get; set; }
        public string SubUtilityCompanyName { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime FailedDate { get; set; }
        public int ReferenceNumber { get; set; }
        public string Status { get; set; }
        public long InvoiceId { get; set; }
        public long SettlementRequestId { get; set; }
        public UserSrv UserSrv { get; set; }
    }
}
