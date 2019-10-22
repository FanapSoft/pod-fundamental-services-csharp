
namespace POD_Notification.Model.ServiceOutput
{
    public class SmsStatusReportSrv
    {
        public int MessageStatus { get; set; }
        public long Receiver { get; set; }
        public string Time { get; set; }
        public string AppId { get; set; }
    }
}
