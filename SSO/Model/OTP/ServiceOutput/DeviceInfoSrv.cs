
namespace POD_SSO.Model.OTP.ServiceOutput
{
    public class DeviceInfoSrv
    {
        public long Id { get; set; }
        public string Agent { get; set; }
        public string Ip { get; set; }
        public string Language { get; set; }
        public string Os { get; set; }
        public string OsVersion { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string DeviceType { get; set; }
        public bool Current { get; set; }
        public long LastAccessTime { get; set; }
        public string Name { get; set; }
        public LocationSrv Location { get; set; }
        public string AppVersion { get; set; }
        public string AppName { get; set; }

    }
}
