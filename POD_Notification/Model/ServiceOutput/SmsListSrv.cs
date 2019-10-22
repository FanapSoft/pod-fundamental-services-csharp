
namespace POD_Notification.Model.ServiceOutput
{
    public class SmsListSrv
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string MobileNumber { get; set; }
        public string MessageId { get; set; }
        public int MessageStatus { get; set; }
        public string SendTime { get; set; }
    }
}
