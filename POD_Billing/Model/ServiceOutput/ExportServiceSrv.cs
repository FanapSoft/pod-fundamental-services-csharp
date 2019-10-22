using System;

namespace POD_Billing.Model.ServiceOutput
{
    public class ExportServiceSrv
    {
        public long Id { get; set; }
        public string StatusCode { get; set; }
        public DateTime CreationDate { get; set; }
        public FileInfoSrv ResultFile { get; set; }
        public string Service { get; set; }
    }
}
