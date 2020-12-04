using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;

namespace POD_Subscription.Base
{
    internal static class ServiceCallProducts
    {
        internal static long AddSubscriptionPlan => Config.ServerType == ServerType.SandBox ? 39340 : 29844;
        internal static long SubscriptionPlanList => Config.ServerType == ServerType.SandBox ? 39341 : 29845;
        internal static long UpdateSubscriptionPlan => Config.ServerType == ServerType.SandBox ? 39342 : 29846;
        internal static long RequestSubscription => Config.ServerType == ServerType.SandBox ? 39343 : 29847;
        internal static long ConfirmSubscription => Config.ServerType == ServerType.SandBox ? 39344 : 29848;
        internal static long SubscriptionList => Config.ServerType == ServerType.SandBox ? 39345 : 29849;
        internal static long ConsumeSubscription => Config.ServerType == ServerType.SandBox ? 39346 : 29850;
    }
}
