using System.Collections.Generic;

namespace POD_AI.Model.ServiceOutput
{
    public class LicensePlateReaderConyentSrv
    {
        public bool HasError { get; set; }
        public int StatusCode { get; set; }
        public List<ResultPlateReader> Result { get; set; }
    }
}