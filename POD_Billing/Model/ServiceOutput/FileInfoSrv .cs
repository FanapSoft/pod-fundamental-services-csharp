using System;
using System.Collections.Generic;
using System.Text;

namespace POD_Billing.Model.ServiceOutput
{
    public class FileInfoSrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string HashCode { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
    }
}
