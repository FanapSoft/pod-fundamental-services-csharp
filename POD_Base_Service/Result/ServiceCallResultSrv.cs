using System.Collections.Generic;
using Newtonsoft.Json;
using POD_Base_Service.Base;

namespace POD_Base_Service.Result
{
    public class ServiceCallResultSrv<T>
    {
        private object result;
        public object Result
        {
            get => result;
            set
            {
                if (value.ToString().TryParse(out var xmlDocument))
                {
                    var innerText = xmlDocument.InnerText;
                    result = JsonConvert.DeserializeObject<T>(innerText);
                }
                else
                {
                    result = JsonConvert.DeserializeObject<T>(value.ToString());
                }
            } 
        }
        public int StatusCode { get; set; }
        public Dictionary<string, string> Header { get; set; }
    }
}
