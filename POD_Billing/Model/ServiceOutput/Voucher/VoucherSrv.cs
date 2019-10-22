using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Billing.Model.ServiceOutput.Voucher
{
    public class VoucherSrv
    {
        public long Id { get; set; }
        public bool Active { get; set; }
        public BusinessSoftSrv Business { get; set; }
        public GuildSrv Guild { get; set; }
        public UserSrv LimitedConsumer { get; set; }
        public UserSrv Consumer { get; set; }
        public string Hash { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CreditAmount { get; set; }
        public float DiscountPercentage { get; set; }
        public long CreationDate { get; set; }
        public long ExpireDate { get; set; }
        public List<ProductSrv> ProductList { get; set; }
        public bool IsUsed { get; set; }
        public decimal UsedAmount { get; set; }
        public int Type { get; set; }
        public List<VoucherUsageSrv> UsageList { get; set; }

    }
}
