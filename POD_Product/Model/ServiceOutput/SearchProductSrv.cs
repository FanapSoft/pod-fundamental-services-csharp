using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Product.Model.ServiceOutput
{
    public class SearchProductSrv
    {
        public List<ProductSrv> Products { get; set; }
        public List<GuildSrv> Guilds { get; set; }
    }
}
