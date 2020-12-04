
using POD_Base_Service.Base.Enum;

namespace POD_Base_Service.Base
{
    public static class BaseUrl
    {
        public static string SsoAddress = "https://accounts.pod.ir";

        public static string PlatformAddress = "https://api.pod.ir/srv/core";

        public static string PrivateCallAddress = "https://pay.pod.ir";

        public static string FileServerAddress = "https://core.pod.ir";

        public static string ServiceCallAddress = Config.ServerType == ServerType.SandBox
            ? "http://sandbox.pod.ir/srv/sc/nzh/doServiceCall/"
            : "https://api.pod.ir/srv/sc/nzh/doServiceCall";
    }
}
