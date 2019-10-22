using System.Collections.Generic;

namespace POD_Neshan.Model.ServiceOutput
{
    public class StepSrv
    {
        public string Name { get; set; }
        public string Instruction { get; set; }
        public DistanceSrv Distance { get; set; }
        public DistanceSrv Duration { get; set; }
        public string Polyline { get; set; }
        public string Maneuver { get; set; }
        public List<double> Start_Location { get; set; }
    }
}
