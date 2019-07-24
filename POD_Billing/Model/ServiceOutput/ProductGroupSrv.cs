using System.Collections.Generic;

namespace POD_Billing.Model.ServiceOutput
{
    public class ProductGroupSrv
    {
        public long Id{ get; set; }
        public List<string> SharedAttributeCodes{ get; set; }
    }
}
