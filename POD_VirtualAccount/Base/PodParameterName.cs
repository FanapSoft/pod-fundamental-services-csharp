using System.Collections.Generic;

namespace POD_VirtualAccount.Base
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
            {"RedirectUri", "redirectUri"},
            {"CallUri", "callUri"},
            {"Amount", "amount"},
            {"Offset", "offset"},
            {"Size", "size"},
            {"CanEdit", "canEdit"},
            {"Canceled", "canceled"},
            {"StatusCode", "statusCode"},
            {"CauseCode", "causeCode"},
            {"CauseId", "causeId"},
            {"FromDate", "fromDate"},
            {"ToDate", "toDate"},
            {"FromAmount", "fromAmount"},
            {"ToAmount", "toAmount"},
            {"UniqueId", "uniqueId"},
            {"ReferenceNumber", "referenceNumber"},
            {"BusinessId", "businessId"},
            {"Follow", "follow"},
            {"DateFrom", "dateFrom"},
            {"DateTo", "dateTo"},
            {"Description", "description"},
            {"AmountFrom", "amountFrom"},
            {"AmountTo", "amountTo"},
            {"Block", "block"},
            {"GuildCode", "guildCode"},
            {"CurrencyCode", "currencyCode"},
            {"Debtor", "debtor"},
            {"LastNRows", "lastNRows"},
            {"CallbackUrl", "callbackUrl"},
            {"UserId", "userId"},
            {"BillNumber", "billNumber"},
            {"Wallet", "wallet"},
            {"RedirectUrl", "redirectUrl"},
            {"InvoiceId", "invoiceId"},
            {"ContactId", "contactId"},
            {"ToolCode", "toolCode"},
            {"Id", "id"},
            {"CardNumber", "cardNumber"},
            {"CustomerAmount", "customerAmount"},
        };
    }
}

