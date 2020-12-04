
namespace POD_Banking.Model.ServiceOutput
{
    public class CardToCardListSrv
    {
        public string SourceCardNumber { get; set; }
        public string SourceDepositNumber { get; set; }
        public string DestinationCardNumber { get; set; }
        public string Amount { get; set; }
        public string TransactionDate { get; set; }
        public string RefrenceNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string SourceNote { get; set; }
        public string DestinationNote { get; set; }
        public string IsSuccess { get; set; }
        public string IpgMessageCode { get; set; }
        public string Message { get; set; }
    }
}
