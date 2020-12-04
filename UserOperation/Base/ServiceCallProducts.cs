using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;

namespace POD_UserOperation.Base
{
    internal static class ServiceCallProducts
    {
        internal static long GetUserProfile => Config.ServerType == ServerType.SandBox ? 39287 : 29792;
        internal static long EditProfileWithConfirmation => Config.ServerType == ServerType.SandBox ? 39289 : 29794;
        internal static long GetListAddress => Config.ServerType == ServerType.SandBox ? 39314 : 29819;
        internal static long ConfirmEditProfile => Config.ServerType == ServerType.SandBox ? 39290 : 29795;
    }
}
