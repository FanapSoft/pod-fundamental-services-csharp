
namespace POD_Billing.Model.ServiceOutput
{
    public class GuildSrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ImageInfoSrv ImageInfo { get; set; }
        public bool Selected { get; set; }
    }
}
