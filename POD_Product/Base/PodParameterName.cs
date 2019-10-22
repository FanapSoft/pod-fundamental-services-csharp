using System.Collections.Generic;
using System.Linq;

namespace POD_Product.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"Token", "_token_"},
            {"TokenIssuer", "_token_issuer_"},
            {"ScVoucherHash","scVoucherHash" },
            {"ScApiKey", "scApiKey"},
            {"ParentProductId", "parentProductId"},
            {"Name", "name"},
            {"Description", "description"},
            {"UniqueId", "uniqueId"},
            {"CanComment", "canComment"},
            {"CanLike", "canLike"},
            {"Enable", "enable"},
            {"Metadata", "metadata"},
            {"BusinessId", "businessId"},
            {"Unlimited", "unlimited"},
            {"AvailableCount", "availableCount"},
            {"Price", "price"},
            {"Discount", "discount"},
            {"GuildCode", "guildCode"},
            {"AllowUserInvoice", "allowUserInvoice"},
            {"AllowUserPrice", "allowUserPrice"},
            {"CurrencyCode", "currencyCode"},
            {"AttTemplateCode", "attTemplateCode"},
            {"AttCode", "attCode[]"},
            {"AttValue", "attValue[]"},
            {"AttGroup", "attGroup[]"},
            {"GroupId", "groupId"},
            {"Lat", "lat"},
            {"Lng", "lng"},
            {"Tags", "tags"},
            {"Content", "content"},
            {"PreviewImage", "previewImage"},
            {"TagTrees", "tagTrees"},
            {"TagTreeCategoryName", "tagTreeCategoryName"},
            {"PreferredTaxRate", "preferredTaxRate"},
            {"QuantityPrecision", "quantityPrecision"},
            {"BizId", "bizId"},
            {"Data", "data"},
            {"Version", "version"},
            {"EntityId", "entityId"},
            {"Categories", "categories[]"},
            {"ChangePreview", "changePreview"},
            {"Id", "id"},
            {"CategoryCode", "categoryCode"},
            {"AttributeTemplateCode", "attributeTemplateCode"},
            {"AttributeCode", "attributeCode[]"},
            {"AttributeValue", "attributeValue[]"},
            {"OrderByLike", "orderByLike"},
            {"OrderBySale", "orderBySale"},
            {"OrderByPrice", "orderByPrice"},
            {"Scope", "scope"},
            {"AttributeSearchQuery", "attributeSearchQuery"},
            {"Query", "q"},
            {"CategoryCodes", "categoryCodes"},
            {"FirstId", "firstId"},
            {"LastId", "lastId"},
            {"Offset", "offset"},
            {"Size", "size"},
            {"ProductGroupId", "productGroupId"},
            {"OrderByDirection", "orderByDirection"},
            {"OrderByAttributeCode", "orderByAttributeCode"}
        };

        public static string GetPodName(this string key)
        {
            return ParametersName.FirstOrDefault(_ => _.Key.Equals(key)).Value;
        }
    }
}
