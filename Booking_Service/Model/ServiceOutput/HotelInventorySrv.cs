using System.Collections.Generic;

namespace Booking_Service.Model.ServiceOutput
{
    public class HotelInventorySrv
    {
        public string Id { get; set; }
        public bool Available_For_Booking { get; set; }
        public string Name { get; set; }
        public int Star { get; set; }
        public string Postal_Code { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Desc { get; set; }
        public List<string> Amenities { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public List<InventoryRoomTypeSrv> Room_Types { get; set; }
        public List<ImageSrv> Images { get; set; }
        public List<string> Policies { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
    }
}
