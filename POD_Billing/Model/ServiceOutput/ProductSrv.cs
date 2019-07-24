using System.Collections.Generic;

namespace POD_Billing.Model.ServiceOutput
{
    public class ProductSrv
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> CategoryList { get; set; }
        public ImageInfoSrv PreviewInfo { get; set; }
        public string Preview { get; set; }
        public bool Unlimited { get; set; }
        public decimal AvailableCount { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public RateSrv Rate { get; set; }
        public SaleInfoSrv SaleInfo { get; set; }
        public List<AttributeValueSrv> AttributeValues { get; set; }
        public GuildSrv Guild { get; set; }
        public bool AllowUserInvoice { get; set; }
        public bool AllowUserPrice { get; set; }
        public string TemplateCode { get; set; }
        public List<SubProductSrv> SubProducts { get; set; }
        public ProductGroupSrv ProductGroup { get; set; }
        public string Content { get; set; }
        public CurrencySrv Currency { get; set; }
        public ProductSrv ParentProduct { get; set; }
        public double PreferredTaxRate { get; set; }
    }
}
