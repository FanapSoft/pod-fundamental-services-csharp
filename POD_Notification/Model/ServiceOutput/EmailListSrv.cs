
namespace POD_Notification.Model.ServiceOutput
{
    public class EmailListSrv
    {
        public string FromAddress { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public string MessageId { get; set; }
        public string SendTime { get; set; }
        public bool Scheduled { get; set; }
    }
}
