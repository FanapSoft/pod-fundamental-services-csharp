using System.Collections.Generic;

namespace POD_Base_Service.Base
{
    internal static class PodParameterName
    {
        internal static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"Token", "_token_"},
            {"TokenIssuer", "_token_issuer_"},
            {"ScVoucherHash","scVoucherHash" },
            {"ScApiKey", "scApiKey"},
            {"Name", "name"},
            {"Offset", "offset"},
            {"Size", "size"},
            {"Desc", "desc"},
            {"Id", "id"},
            {"Query", "query"},
            {"Enable", "enable"},
            {"CategoryId", "categoryId"},
            {"ParentId", "parentId"},
            {"LevelCount", "levelCount"},
            {"FromLevel", "level"}
        };

        internal static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}

