namespace POD_SSO.Model.OTP.ServiceOutput
{
    public class SentVerificationDTOSrv
    {
        public int Expires_In { get; set; }
        public string Identity { get; set; }
        public string Type { get; set; }
        public long User_Id { get; set; }
    }
}
