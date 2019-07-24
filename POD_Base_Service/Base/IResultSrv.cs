namespace POD_Base_Service.Base
{
    public interface IResultSrv
    {
        bool HasError { get; set; }
        long MessageId { get; set; }
        string ReferenceNumber { get; set; }
        int ErrorCode { get; set; }
        string Message { get; set; }
        long Count { get; set; }
        string Ott { get; set; }
    }
}
