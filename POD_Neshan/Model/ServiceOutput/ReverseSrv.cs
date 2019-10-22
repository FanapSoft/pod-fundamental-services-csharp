using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Neshan.Model.ServiceOutput
{
    public class ReverseSrv : ResponseSrv
    {
        public string Status { get; set; }
        public string Formatted_Address { get; set; }
        public string Route_Name { get; set; }
        public string Route_Type { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public object Place { get; set; }
        public string Municipality_Zone { get; set; }
        public bool? In_Traffic_Zone { get; set; }
        public bool? In_Odd_Even_Zone { get; set; }
        public List<AddressSrv> Addresses { get; set; }
    }
}
