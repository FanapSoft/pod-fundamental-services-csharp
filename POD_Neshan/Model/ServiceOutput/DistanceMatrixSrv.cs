using System.Collections.Generic;

namespace POD_Neshan.Model.ServiceOutput
{
    public class DistanceMatrixSrv : ResponseSrv
    {
        public string Status { get; set; }
        public List<RowSrv> Rows { get; set; }
        public List<string> Origin_Addresses { get; set; }
        public List<string> Destination_Addresses { get; set; }
    }
}
