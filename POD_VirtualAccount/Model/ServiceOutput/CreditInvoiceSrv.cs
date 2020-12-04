using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class CreditInvoiceSrv
    {
        public long Id { get; set; }
        public long DeliveryDate { get; set; }
        public List<CreditInvoiceItemSrv> CreditInvoiceItems { get; set; }
        public bool Canceled { get; set; }
        public CurrencySrv Currency { get; set; }
        public string Description { get; set; }
        public long IssuanceDate { get; set; }
        public string IssuancePersianDate { get; set; }
        public long BillNumber { get; set; }
        public UserSrv User { get; set; }
        public long Serial { get; set; }
        public bool Payed { get; set; }
    }
}
