using System.Collections.Generic;

namespace POD_Notification.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"Token", "_token_"},
            {"TokenIssuer", "_token_issuer_"},
            {"ScVoucherHash", "scVoucherHash"},
            {"ScApiKey", "scApiKey"},
            {"ApiToken", "apiToken"},
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
            {"NotificationMessageId", "id"},
            {"MessageId", "id"},
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
            {"ServiceCallParameters", "serviceCallParameters"},
        };
        public static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}
