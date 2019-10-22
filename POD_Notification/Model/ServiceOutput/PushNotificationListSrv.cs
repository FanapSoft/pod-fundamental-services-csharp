
namespace POD_Notification.Model.ServiceOutput
{
    public class PushNotificationListSrv
    {
        public string title { get; set; }
        public string text { get; set; }
        public string receivers { get; set; }
        public string messageId { get; set; }
        public long id { get; set; }
        public int messageStatus { get; set; }
        public string sendTime { get; set; }
        public string appId { get; set; }
    }
}
