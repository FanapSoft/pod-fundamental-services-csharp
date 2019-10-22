using System.Collections.Generic;

namespace POD_Neshan.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"Token", "_token_"},
            {"TokenIssuer", "_token_issuer_"},
            {"ScVoucherHash", "scVoucherHash"},
            {"ScApiKey", "scApiKey"},
            {"Term", "term"},
            {"Lat", "lat"},
            {"Lng", "lng"},
            {"Origin", "origin"},
            {"Destination", "destination"},
            {"WayPoints", "wayPoints"},
            {"AvoidTrafficZone", "avoidTrafficZone"},
            {"AvoidOddEvenZone", "avoidOddEvenZone"},
            {"Alternative", "alternative"},
            {"Path", "path"},
            {"Origins", "origins"},
            {"Destinations", "destinations"}
        };

        public static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}
