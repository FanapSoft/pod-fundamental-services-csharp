namespace POD_Base_Service.Result
{
    public class ResponseSrv<T>
    {
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public T Content { get; set; }
        public int TotalCount { get; set; }
        public string LastUpdated { get; set; }
    }
}
