
namespace POD_SSO.Model.OTP.ServiceOutput
{
    public class OAuthClientSrv
    {
        public string Client_Id { get; set; }
        public string ApiToken { get; set; }
        public string Redirect_Uri { get; set; }
        public string Scope { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public long UserId { get; set; }
        public string LoginUrl { get; set; }
        public string SupportNumber { get; set; }
        public bool CaptchaEnabled { get; set; }
        public bool SignUpEnabled { get; set; }
        public string[] Roles { get; set; }
    }
}
