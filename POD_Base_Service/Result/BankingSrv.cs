
namespace POD_Base_Service.Result
{
    public class BankingSrv<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string MessageCode { get; set; }
    }
}
