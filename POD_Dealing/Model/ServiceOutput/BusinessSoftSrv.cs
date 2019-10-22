
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Dealing.Model.ServiceOutput
{
    public class BusinessSoftSrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ImageInfoSrv ImageInfo { get; set; }
        public string Image { get; set; }
        public int NumOfProducts { get; set; }
        public RateSrv Rate { get; set; }
        public string Sheba { get; set; }
        public string Phone { get; set; }
    }
}
