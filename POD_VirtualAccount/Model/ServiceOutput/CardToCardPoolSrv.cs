using System;
using System.Collections.Generic;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class CardToCardPoolSrv
    {
        public long Id { get; set; }
        public string StatusCode { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime DoneDateTime { get; set; }
        public bool CanEdit { get; set; }
        public string CauseId { get; set; }
        public string CauseCode { get; set; }
        public string ReferenceNumber { get; set; }
        public string UniqueId { get; set; }
        public List<CardToCardPoolItemSrv> Items { get; set; }
    }
}
