using System.Collections.Generic;

namespace POD_Neshan.Model.ServiceOutput
{
    public class LegSrv
    {
        public string Summary { get; set; }
        public DistanceSrv Distance { get; set; }
        public DistanceSrv Duration { get; set; }
        public List<StepSrv> Steps { get; set; }
    }
}
