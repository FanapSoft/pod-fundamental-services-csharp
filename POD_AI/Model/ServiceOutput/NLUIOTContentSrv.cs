using Newtonsoft.Json;

namespace POD_AI.Model.ServiceOutput
{
    public class NLUIOTContentSrv
    {
        public string Order { get; set; }
        public string Object { get; set; }
        public string Place { get; set; }
        public string Time { get; set; }
        public string Degree { get; set; }
        public string Item_To_Play { get; set; }
        public string Item_To_Play_Type { get; set; }
        public string Location { get; set; }
        public string TimeToGo { get; set; }

        private object mode;
        public object Mode
        {
            get => mode;
            set => mode = JsonConvert.DeserializeObject<IOTMode>(value.ToString());
        }
    }
}