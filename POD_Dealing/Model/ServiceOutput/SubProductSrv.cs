using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Dealing.Model.ServiceOutput
{
    public class SubProductSrv
    {
        public long Id { get; set; }
        public ImageInfoSrv PreviewInfo { get; set; }
        public decimal AvailableCount { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public List<AttributeValueSrv> AttributeValues { get; set; }
    }
}
