using System.Collections.Generic;

namespace POD_Dealing.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName= new Dictionary<string, string>
        {
            {"Token", "_token_"},
            {"TokenIssuer", "_token_issuer_"},
            {"ScVoucherHash","scVoucherHash" },
            {"ScApiKey", "scApiKey"},
            {"ClientId", "client_id"},
            {"ClientSecret", "client_secret"},
            {"Username", "username"},
            {"BusinessName", "businessName"},
            {"FirstName", "firstName"},
            {"LastName", "lastName"},
            {"Sheba", "sheba"},
            {"NationalCode", "nationalCode"},
            {"EconomicCode", "economicCode"},
            {"RegistrationNumber", "registrationNumber"},
            {"Email", "email"},
            {"GuildCode", "guildCode[]"},
            {"Cellphone", "cellphone"},
            {"Phone", "phone"},
            {"Fax", "fax"},
            {"PostalCode", "postalCode"},
            {"Country", "country"},
            {"State", "state"},
            {"City", "city"},
            {"Address", "address"},
            {"Description", "description"},
            {"NewsReader", "newsReader"},
            {"LogoImage", "logoImage"},
            {"CoverImage", "coverImage"},
            {"Tags", "tags"},
            {"TagTrees", "tagTrees"},
            {"TagTreeCategoryName", "tagTreeCategoryName"},
            {"Link", "link"},
            {"Lat", "lat"},
            {"AgentFirstName", "agentFirstName"},
            {"AgentLastName", "agentLastName"},
            {"AgentCellphoneNumber", "agentCellphoneNumber"},
            {"AgentNationalCode", "agentNationalCode"},
            {"Name", "name"},
            {"Offset", "offset"},
            {"Size", "size"},
            {"BizId", "bizId"},
            {"Query", "query"},
            {"SsoId", "ssoId"},
            {"ShopName", "shopName"},
            {"ShopNameEn", "shopNameEn"},
            {"Website", "website"},
            {"DateEstablishing", "dateEstablishing"},
            {"ChangeLogo", "changeLogo"},
            {"ChangeCover", "changeCover"},
            {"ChangeAgent", "changeAgent"},
            {"Rate", "rate"},
            {"Text", "text"},
            {"DisFavorite", "disfavorite"},
            {"Id", "id[]"},
            {"FirstId", "firstId"},
            {"LastId", "lastId"},
            {"CommentId", "commentId"},
            {"BusinessId", "businessId"}
        };
        public static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}

