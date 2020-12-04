using System;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class CardToCardPoolLogSrv
    {
        public string Message{get; set;}
        public bool Success{get; set;}
        public DateTime Date{get; set;}
        public string ErrorCode{get; set;}
    }
}
