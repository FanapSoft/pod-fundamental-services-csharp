using System.Collections.Generic;

namespace POD_Tools.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string,string> ParametersName = new Dictionary<string, string>
        {
            {"Token","_token_" },
            {"TokenIssuer", "_token_issuer_"},
            {"ScVoucherHash","scVoucherHash" },
            {"ScApiKey", "scApiKey"},
            {"BillId","billId" },
            {"PaymentId","paymentId" },
            {"Id","id" },
            {"FromDate","fromDate" },
            {"ToDate","toDate" },
            {"Offset","offset" },
            {"Size","size" }
        };

        public static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}
