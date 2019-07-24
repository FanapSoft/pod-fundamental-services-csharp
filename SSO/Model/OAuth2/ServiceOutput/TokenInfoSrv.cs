namespace POD_SSO.Model.OAuth2.ServiceOutput
{
    public class TokenInfoSrv
    {
        public string Active { get; set; }
        public string Client_Id { get; set; }
        public string Device_Uid { get; set; }
        public int Exp { get; set; }
        public string Scope { get; set; }      
        public string Sub { get; set; }
    }
}
