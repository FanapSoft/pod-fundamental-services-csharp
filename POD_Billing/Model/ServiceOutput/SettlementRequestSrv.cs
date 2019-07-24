using System.Collections.Generic;

namespace POD_Billing.Model.ServiceOutput
{
    public class SettlementRequestSrv
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public long RequestDate { get; set; }
        public CustomerProfileSrv CustomerProfileSrv { get; set; }
        public BusinessSoftSrv BusinessSoftSrv { get; set; }
        public GuildSrv GuildSrv { get; set; }
        public long SettleDate { get; set; }
        public string Status { get; set; }
        public List<CustomerAmountSrv> CustomerAmountSrvs { get; set; }
        public CurrencySrv Currency { get; set; }
        public string ToolCode { get; set; }
        public string ToolId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ReferenceId { get; set; }
        public List<SettlementLogSrv> SettlementLogSrvs { get; set; }
        public string Wallet { get; set; }
        public string Description { get; set; }
        public string UniqueId { get; set; }
        public bool Instant { get; set; }
        public long SendToBankDate { get; set; }
    }
}
