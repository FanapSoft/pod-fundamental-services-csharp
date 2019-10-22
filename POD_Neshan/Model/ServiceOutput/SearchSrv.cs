using System.Collections.Generic;

namespace POD_Neshan.Model.ServiceOutput
{
    public class SearchSrv : ResponseSrv
    {
        public long Count { get; set; }

        public List<ItemSrv> Items { get; set; }
    }
}
