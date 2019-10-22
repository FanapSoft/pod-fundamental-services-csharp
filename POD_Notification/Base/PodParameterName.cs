using System.Collections.Generic;

namespace POD_Notification.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"Token", "apiToken"},
            {"ServiceName", "serviceName"},
            {"Content", "content"},
            {"Receptor", "receptor"},
            {"Token1", "token"},
            {"Token2", "token2"},
            {"Token3", "token3"},
            {"Template", "template"},
            {"Type", "type"},
            {"MobileNumbers", "mobileNumbers"},
            {"Scheduler", "scheduler"},
            {"Body", "content"},
            {"NotificationMessageId", "content"},
            {"MessageId", "content"},
            {"To", "to"},
            {"ReplyAddress", "replyAddress"},
            {"Subject", "subject"},
            {"Cc", "cc"},
            {"Bcc", "bcc"},
            {"FileHashes", "fileHashes"},
            {"Offset", "offset"},
            {"Size", "size"},
            {"OrderBy", "orderBy"},
            {"Order", "order"},
            {"Filter", "filter"},
            {"FilterValue", "filterValue"},
            {"PeerId", "receiver"},
            {"Title", "title"},
            {"Text", "text"},
            {"ExtraData", "extra"},
            {"AppId", "appId"},
        };
        public static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}
