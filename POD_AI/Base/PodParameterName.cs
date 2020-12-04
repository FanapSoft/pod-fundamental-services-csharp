using System.Collections.Generic;

namespace POD_AI.Base
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
            {"Image1", "image1"},
            {"Image2", "image2"},
            {"Mode", "mode"},
            {"Text", "text"},
            {"LinkFile", "linkFile"},
            {"Image", "image"},
            {"IsCrop", "isCrop"}
        };
    }
}
