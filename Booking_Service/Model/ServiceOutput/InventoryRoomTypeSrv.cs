using System.Collections.Generic;

namespace Booking_Service.Model.ServiceOutput
{
    public class InventoryRoomTypeSrv
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public List<string> Amenities { get; set; }
        public int Capacity { get; set; }
        public int Extra_Capacity { get; set; }
        public List<BedConfigurationSrv> Bed_Configurations { get; set; }
        public List<BedConfigurationSrv> Extra_Bed_Configurations { get; set; }
        public string Smoking_Policy { get; set; }
        public List<ImageSrv> Images { get; set; }
        public List<string> Policies { get; set; }
    }
}
