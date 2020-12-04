using POD_Base_Service.Base.Enum;

namespace POD_Base_Service.Base
{
    internal static class ServiceCallProducts
    {
        internal static long GetGuildList => Config.ServerType == ServerType.SandBox ? 39329 : 29833;
        internal static long GetCurrencyList => Config.ServerType == ServerType.SandBox ? 39378 : 29992;
        internal static long GetOtt => Config.ServerType == ServerType.SandBox ? 39311 : 29816;
        internal static long AddTagTreeCategory => Config.ServerType == ServerType.SandBox ? 39356 : 29860;
        internal static long GetTagTreeCategoryList => Config.ServerType == ServerType.SandBox ? 39357 : 29861;
        internal static long UpdateTagTreeCategory => Config.ServerType == ServerType.SandBox ? 39358 : 29862;
        internal static long AddTagTree => Config.ServerType == ServerType.SandBox ? 39359 : 29863;
        internal static long GetTagTreeList => Config.ServerType == ServerType.SandBox ? 39360 : 29864;
        internal static long UpdateTagTree => Config.ServerType == ServerType.SandBox ? 39361 : 29865;
    }
}
