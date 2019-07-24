using System.Collections.Generic;

namespace POD_Billing.Model.ServiceOutput
{
    public class InvoiceItemSrv
    {
        public long Id{ get; set; }
        public ProductSrv ProductSrv{ get; set; }
        public decimal Amount{ get; set; }
        public string Description{ get; set; }
        public decimal Quantity{ get; set; }
        public List<VoucherUsageSrv> VoucherUsageSrvs{ get; set; }
    }
}
