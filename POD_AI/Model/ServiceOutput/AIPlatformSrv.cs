using Newtonsoft.Json;

namespace POD_AI.Model.ServiceOutput
{
    public class AIPlatformSrv<T>
    {
        private object data;
        public object Data
        {
            get => data;
            set
            {
                data = JsonConvert.DeserializeObject<T>(value.ToString());
            }
        }
        public bool HasError { get; set; }
        public long StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Request { get; set; }
    }
}
