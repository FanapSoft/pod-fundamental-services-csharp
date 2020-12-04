using System;
using System.Collections.Generic;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class CardToCardPoolItemSrv
    {
        public long Id { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; }
        public string DestCardNumber { get; set; }
        public string TrackingId { get; set; }
        public DateTime DoneDate { get; set; }
        public List<CardToCardPoolLogSrv> CardToCardPoolLogList { get; set; }
    }
}
