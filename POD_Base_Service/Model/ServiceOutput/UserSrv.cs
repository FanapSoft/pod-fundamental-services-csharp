namespace POD_Base_Service.Model.ServiceOutput
{
    public class UserSrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ImageInfoSrv Image { get; set; }
        public string SsoId { get; set; }
        public int SsoIssuerCode { get; set; }
        public string ProfileImage { get; set; }
    }
}
