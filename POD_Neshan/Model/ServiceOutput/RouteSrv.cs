using System.Collections.Generic;

namespace POD_Neshan.Model.ServiceOutput
{
    public class RouteSrv
    {
        public List<LegSrv> Legs { get; set; }
        public OverviewPolylineSrv OverviewPolyline { get; set; }
    }
}
