
namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class CreditInvoiceItemSrv
    {
        public long Id { get; set; }
        public decimal Quantity { get; set; }
        public CreditPackSrv CreditPack { get; set; }
    }
}
