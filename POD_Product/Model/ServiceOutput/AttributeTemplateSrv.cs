using System.Collections.Generic;

namespace POD_Product.Model.ServiceOutput
{
    public class AttributeTemplateSrv
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<AttributeSrv> Attributes { get; set; }
    }
}
