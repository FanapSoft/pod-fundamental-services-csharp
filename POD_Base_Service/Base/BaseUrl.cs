using POD_Base_Service.Base.Enum;

namespace POD_Base_Service.Base
{
    public static class BaseUrl
    {

        public static string SsoAddress = "https://accounts.pod.land";

        public static string PlatformAddress => Config.ServerType == ServerType.SandBox ? "http://sandbox.pod.land/srv/basic-platform" : "https://api.pod.land/srv/core";

        public static string PrivateCallAddress => Config.ServerType == ServerType.SandBox ? "https://sandbox.pod.land:1033" : "https://pay.pod.land";

        public static string FileServerAddress => Config.ServerType == ServerType.SandBox ? "http://sandbox.pod.land:8080" : "https://core.pod.land";
    }
}
