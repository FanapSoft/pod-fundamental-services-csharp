using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Avand.Model.ServiceOutput
{
    public class InvoiceSrv
    {
        public long Id { get; set; }
        public decimal TotalAmountWithoutDiscount { get; set; }
        public decimal DelegationAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PayableAmount { get; set; }
        public decimal Vat { get; set; }
        public long IssuanceDate { get; set; }
        public long DeliveryDate { get; set; }
        public string BillNumber { get; set; }
        public string IssuancePersianDate { get; set; }
        public string PaymentBillNumber { get; set; }
        public BankGatewaySrv BankGateway { get; set; }
        public string TransactionReferenceId { get; set; }
        public string UniqueNumber { get; set; }
        public long TrackerId { get; set; }
        public long TerminalNumber { get; set; }
        public string Description { get; set; }
        public long PaymentDate { get; set; }
        public bool Payed { get; set; }
        public long Serial { get; set; }
        public bool Canceled { get; set; }
        public long CancelDate { get; set; }
        public BusinessSoftSrv Business { get; set; }
        public List<InvoiceItemSrv> InvoiceItemSrvs { get; set; }
        public GuildSrv GuildSrv { get; set; }
        public AddressSrv AddressSrv { get; set; }
        public UserSrv UserSrv { get; set; }
        public string PhoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public bool Closed { get; set; }
        public bool VerificationNeeded { get; set; }
        public long VerificationDate { get; set; }
        public bool IsWaiting { get; set; }
        public long EditedInvoiceId { get; set; }
        public bool IsEdited { get; set; }
        public string Wallet { get; set; }
        public string Metadata { get; set; }
        public bool IsSubInvoice { get; set; }
        public InvoiceSrv CustomerInvoice { get; set; }
        public List<InvoiceSrv> SubInvoices { get; set; }
        public bool Safe { get; set; }
        public bool PostVoucherEnabled { get; set; }
        public string ReferenceNumber { get; set; }
        public string LastFourDigitOfCardNumber { get; set; }
        public string MaskedCardNumber { get; set; }
        public UserSrv IssuerSrv { get; set; }
        public long WillBePaidAt { get; set; }
        public bool WillBeBlocked { get; set; }
        public long WillBlockedFor { get; set; }
        public bool WillBePaid { get; set; }
        public bool SubInvoice { get; set; }
    }
}
