using System.Collections.Generic;

namespace POD_Subscription.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"Token", "_token_"},
            {"TokenIssuer", "_token_issuer_"},
            {"ScVoucherHash","scVoucherHash" },
            {"ScApiKey", "scApiKey"},
            {"ClientId", "client_id"},
            {"ClientSecret", "client_secret"},
            {"Name", "name"},
            {"Price", "price"},
            {"PeriodTypeCode", "periodTypeCode"},
            {"PeriodTypeCount", "periodTypeCount"},
            {"UsageCountLimit", "usageCountLimit"},
            {"UsageAmountLimit", "usageAmountLimit"},
            {"Type", "type"},
            {"GuildCode", "guildCode"},
            {"PermittedGuildCode", "permittedGuildCode[]"},
            {"PermittedBusinessId", "permittedBusinessId[]"},
            {"PermittedProductId", "permittedProductId[]"},
            {"CurrencyCode", "currencyCode"},
            {"EntityId", "productId"},
            {"TypeCode", "typeCode"},
            {"Enable", "enable"},
            {"Offset", "offset"},
            {"Size", "size"},
            {"FromPrice", "fromPrice"},
            {"ToPrice", "toPrice"},
            {"PeriodTypeCountFrom", "periodTypeCountFrom"},
            {"PeriodTypeCountTo", "periodTypeCountTo"},
            {"Id", "id"},
            {"SubscriptionPlanId", "subscriptionPlanId"},
            {"UserId", "userId"},
            {"SubscriptionId", "subscriptionId"},
            {"Code", "code"},
            {"UsedAmount", "usedAmount"}
        };

        public static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}
