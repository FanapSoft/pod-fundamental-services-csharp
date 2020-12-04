using System.Collections.Generic;

namespace POD_Notification.Model.ServiceOutput
{
    public class SmsStatusSrv
    {
        public string MessageId { get; set; }
        public string Contect { get; set; }
        public int TotalCount { get; set; }
        public Dictionary<long, SmsStatusReportSrv> Message { get; set; }
    }
}
