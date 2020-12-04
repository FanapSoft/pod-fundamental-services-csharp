using System.Collections.Generic;

namespace Booking_Service.Model.ServiceOutput
{
    public class HotelInventoriesSrv
    {
        //public string Api_Version { get; set; }
        public string Lang { get; set; }
        public List<HotelInventorySrv> Hotels { get; set; }
    }
}
