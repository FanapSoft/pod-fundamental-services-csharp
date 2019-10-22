using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Product.Model.ServiceOutput
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
        public bool Hide { get; set; }
        public bool Enable { get; set; }
        public bool CanLike { get; set; }
        public long NumOfDisLikes { get; set; }
        public double Latitude { get; set; }
        public UserSrv UserSrv { get; set; }
        public bool CanComment { get; set; }
        public double Longitude { get; set; }
        public string Metadata { get; set; }
        public long NumOfComments { get; set; }
        public long Timestamp { get; set; }
        public int Version { get; set; }
        public UserPostInfoSrv UserPostInfo { get; set; }
        public long NumOfFavorites { get; set; }
        public long Id { get; set; }
        public long TimelineId { get; set; }
        public long EntityId { get; set; }
        public long NumOfLikes { get; set; }
        public List<string> Tags { get; set; }
        public List<string> TagTrees { get; set; }
        public BusinessSoftSrv Business { get; set; }
    }
}
