using POD_Base_Service.Model.ServiceOutput;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class AccountBillItemSrv
    {
        public string AccountName { get; set; }
        public long IssuanceDate { get; set; }
        public decimal Amount { get; set; }
        public bool Debtor { get; set; }
        public decimal AfterTxAmount { get; set; }
        public string Description { get; set; }
        public long DocumentId { get; set; }
        public string TxNumber { get; set; }
        public string IssuerName { get; set; }
        public bool Canceled { get; set; }
        public CurrencySrv Currency { get; set; }
        public long InvoiceId { get; set; }
        public string InvoiceBillNumber { get; set; }
        public bool InvoiceClosed { get; set; }
        public bool BillSettled { get; set; }
        public bool Withdrawable { get; set; }
    }
}
