using System.Collections.Generic;

namespace POD_Banking.Model.ServiceOutput
{
    public class GetShebaInfoSrv
    {
        public string Sheba { get; set; }
        public string AccountStatus { get; set; }
        public string AccountStatusName { get; set; }
        public List<AccountOwnerSrv> AccountOwners { get; set; }
    }
}
