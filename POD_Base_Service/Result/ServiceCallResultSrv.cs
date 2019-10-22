using System.Collections.Generic;
using Newtonsoft.Json;

namespace POD_Base_Service.Result
{
    public class ServiceCallResultSrv<T>
    {
        private object result;
        public object Result
        {
            get => result;
            set => result = JsonConvert.DeserializeObject<T>(value.ToString());
        }
        public int StatusCode { get; set; }
        public Dictionary<string, string> Header { get; set; }
    }
}
