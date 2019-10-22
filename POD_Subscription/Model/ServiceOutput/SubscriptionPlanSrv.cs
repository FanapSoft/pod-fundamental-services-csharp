using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Subscription.Model.ServiceOutput
{
    public class SubscriptionPlanSrv
    {
        public long Id { get; set; }
        public string PeriodTypeCode { get; set; }
        public int PeriodCount { get; set; }
        public long UsageCountLimit { get; set; }
        public long CreationDate { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Enable { get; set; }
        public decimal UsageAmountLimit { get; set; }
        public List<GuildSrv> PermittedGuildList { get; set; }
        public List<BusinessSoftSrv> PermittedBusinessList { get; set; }
        public List<ProductSrv> PermittedProductList { get; set; }
        public bool AllGuildsPermitted { get; set; }
        public bool AllBusinessesPermitted { get; set; }
        public bool AllProductsPermitted { get; set; }
        public CurrencySrv Currency { get; set; }
        public GuildSrv InvoiceGuild { get; set; }
        public string TypeCode { get; set; }
        public ProductSrv Product { get; set; }
    }
}
