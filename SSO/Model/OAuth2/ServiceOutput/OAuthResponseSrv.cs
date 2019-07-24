namespace POD_SSO.Model.OAuth2.ServiceOutput
{
    public class OAuthResponseSrv
    {
        public string Access_Token { get; set; }
        public long Expires_In { get; set; }
        public string Id_Token { get; set; }
        public string Refresh_Token { get; set; }
        public string Scope { get; set; }
        public string Code { get; set; }
        public string Token_Type { get; set; }
    }
}
