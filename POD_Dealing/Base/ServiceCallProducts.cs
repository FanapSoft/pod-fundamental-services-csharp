using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;

namespace POD_Dealing.Base
{
    internal static class ServiceCallProducts
    {
        internal static long AddUserAndBusiness => Config.ServerType == ServerType.SandBox ? 39328 : 29832;
        internal static long ListUserCreatedBusiness => Config.ServerType == ServerType.SandBox ? 39330 : 29834;
        internal static long UpdateBusiness => Config.ServerType == ServerType.SandBox ? 39331 : 29835;
        internal static long GetApiTokenForCreatedBusiness => Config.ServerType == ServerType.SandBox ? 39332 : 29836;
        internal static long RateBusiness => Config.ServerType == ServerType.SandBox ? 39333 : 29837;
        internal static long CommentBusiness => Config.ServerType == ServerType.SandBox ? 39334 : 29838;
        internal static long BusinessFavorite => Config.ServerType == ServerType.SandBox ? 39335 : 29839;
        internal static long UserBusinessInfos => Config.ServerType == ServerType.SandBox ? 39336 : 29840;
        internal static long CommentBusinessList => Config.ServerType == ServerType.SandBox ? 39337 : 29841;
        internal static long ConfirmComment => Config.ServerType == ServerType.SandBox ? 39338 : 29842;
        internal static long UnConfirmComment => Config.ServerType == ServerType.SandBox ? 39339 : 29843;
        internal static long AddDealer => Config.ServerType == ServerType.SandBox ? 39323 : 29827;
        internal static long DealerList => Config.ServerType == ServerType.SandBox ? 39324 : 29828;
        internal static long EnableDealer => Config.ServerType == ServerType.SandBox ? 39325 : 29829;
        internal static long DisableDealer => Config.ServerType == ServerType.SandBox ? 39326 : 29830;
        internal static long BusinessDealingList => Config.ServerType == ServerType.SandBox ? 39327 : 29831;
        internal static long AddDealerProductPermission => Config.ServerType == ServerType.SandBox ? 39318 : 29822;
        internal static long DealerProductPermissionList => Config.ServerType == ServerType.SandBox ? 39319 : 29823;
        internal static long DealingProductPermissionList => Config.ServerType == ServerType.SandBox ? 39320 : 29824;
        internal static long DisableDealerProductPermission => Config.ServerType == ServerType.SandBox ? 39321 : 29825;
        internal static long EnableDealerProductPermission => Config.ServerType == ServerType.SandBox ? 39322 : 29826;
    }
}
