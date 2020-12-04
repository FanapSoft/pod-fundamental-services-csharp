
namespace POD_Avand.Model.ServiceOutput
{
    public class Output<T>
    {
        public bool HasError { get; set; }
        public string ReferenceId { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public int TotalCount { get; set; }
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public T Result { get; set; }
    }
}
