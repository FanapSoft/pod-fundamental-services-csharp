using System.Collections.Generic;

namespace POD_Avand.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"Token", "_token_"},
            {"ApiToken", "token"},
            {"TokenIssuer", "_token_issuer_"},
            {"ScVoucherHash", "scVoucherHash"},
            {"ScApiKey", "scApiKey"},
            {"Size", "size"},
            {"Offset", "offset"},
            {"Id", "id"},
            {"BillNumber", "billNumber"},
            {"UniqueNumber", "uniqueNumber"},
            {"TrackerId", "trackerId"},
            {"FromDate", "fromDate"},
            {"ToDate", "toDate"},
            {"IsCanceled", "isCanceled"},
            {"IsPayed", "isPayed"},
            {"IsClosed", "isClosed"},
            {"IsWaiting", "isWaiting"},
            {"GuildCode", "guildCode"},
            {"ReferenceNumber", "referenceNumber"},
            {"UserId", "userId"},
            {"IssuerId", "issuerId"},
            {"Query", "query"},
            {"FirstId", "firstId"},
            {"LastId", "lastId"},
            {"EntityIdList", "entityIdList"},
            {"RedirectUri", "redirectUri"},
            {"BusinessId", "businessId"},
            {"Price", "price"},
            {"InvoiceId", "invoiceId"},
        };
    }
}
