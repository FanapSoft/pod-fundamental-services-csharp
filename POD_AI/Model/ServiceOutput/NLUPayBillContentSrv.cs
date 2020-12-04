
public class NLUPayBillContentSrv
{
    public string Intent { get; set; }
    public string SubIntent { get; set; }
    public string OriginAccount { get; set; }
    public string BillId { get; set; }
    public string PayId { get; set; }
    public string Beneficiary { get; set; }
    public string MobileNumber { get; set; }
    public bool BarcodeReader { get; set; }
    public int BillType { get; set; }
    public string TimeToGo { get; set; } //timestamp
}
