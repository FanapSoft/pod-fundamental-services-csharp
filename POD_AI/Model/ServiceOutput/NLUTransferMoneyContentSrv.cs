
public class NLUTransferMoneyContentSrv
{
    public string Intent { get; set; }
    public string SubIntent { get; set; }
    public string OriginAccount { get; set; }
    public string DestinationAccount { get; set; }
    public string DestinationAccountHolder { get; set; }
    public decimal Amount { get; set; }
    public string TimeToGo { get; set; } //Timestamp
}
