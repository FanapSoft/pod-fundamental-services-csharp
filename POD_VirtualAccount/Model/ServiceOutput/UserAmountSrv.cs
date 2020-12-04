using System.Collections.Generic;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class UserAmountSrv
    {
        public List<CustomerAmountSrv> CustomerAmountSrvs { get; set; }
        public List<BusinessAmountSrv> MainBusinessAmountSrvs { get; set; }
        public List<BusinessAmountSrv> BlockedBusinessAmountSrvs { get; set; }
        public List<CustomerAmountSrv> BlockAmountSrvs { get; set; }
    }
}
