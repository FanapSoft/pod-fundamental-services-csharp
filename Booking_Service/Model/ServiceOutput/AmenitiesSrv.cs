using System;
using System.Collections.Generic;
using System.Text;

namespace Booking_Service.Model.ServiceOutput
{
    public class AmenitiesSrv
    {
        public string Api_Version { get; set; }
        public string Lang { get; set; }
        public List<AmenitySrv> Amenities { get; set; }
    }
}
