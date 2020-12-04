using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;

namespace POD_Notification.Base
{
    internal static class ServiceCallProducts
    {
        internal static long GetSmsList => Config.ServerType == ServerType.SandBox ? 42402 : 34938;
        internal static long SendSms => Config.ServerType == ServerType.SandBox ? 42403 : 34941;
        internal static long GetValidationSmsStatus => Config.ServerType == ServerType.SandBox ? 42404 : 34931;
        internal static long GetEmailInfo => Config.ServerType == ServerType.SandBox ? 42405 : 34935;
        internal static long GetPushNotificationStatusAll => Config.ServerType == ServerType.SandBox ? 42406 : 34933;
        internal static long GetPushNotificationStatusReceived => Config.ServerType == ServerType.SandBox ? 42415 : 34937;
        internal static long GetPushNotificationStatusSeen => Config.ServerType == ServerType.SandBox ? 42407 : 34939;
        internal static long GetEmailList => Config.ServerType == ServerType.SandBox ? 42409 : 34934;
        internal static long PushNotificationByPeerId => Config.ServerType == ServerType.SandBox ? 42410 : 34936;
        internal static long GetSmsStatus => Config.ServerType == ServerType.SandBox ? 42411 : 34929;
        internal static long SendValidationSms => Config.ServerType == ServerType.SandBox ? 42412 : 34930;
        internal static long SendEmail => Config.ServerType == ServerType.SandBox ? 42413 : 34932;
        internal static long PushNotificationByAppId => Config.ServerType == ServerType.SandBox ? 42414 : 34940;
        internal static long GetPushNotificationList => Config.ServerType == ServerType.SandBox ? 42430 : 34943;
    }
}
