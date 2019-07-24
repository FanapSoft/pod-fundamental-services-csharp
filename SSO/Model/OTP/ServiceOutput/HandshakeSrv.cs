
namespace POD_SSO.Model.OTP.ServiceOutput
{
    public enum KeyFormat
    {
        Xml,
        Pem,
        Base64
    }
    public class HandshakeSrv
    {
        public string KeyId { get; set; }
        public long Expires_In { get; set; }
        public string Algorithm { get; set; }
        public OAuthClientSrv OAuthClient { get; set; }
        public DeviceInfoSrv Device { get; set; }
        public FanapMiniUserSrv User { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string SecretKey { get; set; }
        public KeyFormat KeyFormat { get; set; }
    }
}
