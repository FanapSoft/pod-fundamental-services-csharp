using System;

namespace POD_Notification.Model.ServiceOutput
{
    public class ValidationSmsSrv
    {
        public long MessageId { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public string Sender { get; set; }
        public string Receptor { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }
    }
}
