using System.Collections.Generic;

namespace Booking_Service.Model.ServiceOutput
{
    public class CitiesSrv
    {
        public string Api_Version { get; set; }
        public string Lang { get; set; }
        public List<CitySrv> Cities { get; set; }
    }
}
