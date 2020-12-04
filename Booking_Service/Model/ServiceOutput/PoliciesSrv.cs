using System.Collections.Generic;

namespace Booking_Service.Model.ServiceOutput
{
    public class PoliciesSrv
    {
        public string Api_Version { get; set; }
        public string Lang { get; set; }
        public List<PolicySrv> Policies { get; set; }
    }
}
