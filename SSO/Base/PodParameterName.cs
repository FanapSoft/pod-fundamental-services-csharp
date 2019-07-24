using System.Collections.Generic;
using System.Linq;

namespace POD_SSO.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"ClientId", "client_id"},
            {"ClientSecret", "client_secret"},
            {"GrantType", "grant_type"},
            {"Code", "code"},
            {"RefreshToken", "refresh_token"},
            {"ContentType", "Content-Type"},
            {"RedirectUri", "redirect_uri"},
            {"TokenTypeHint", "token_type_hint"},
            {"Token", "token"},
            {"DeviceUid", "device_uid"},
            {"DeviceLat", "device_lat"},
            {"DeviceLon", "device_lon"},
            {"DeviceOs", "device_os"},
            {"DeviceOsVersion", "device_os_version"},
            {"DeviceType", "device_type"},
            {"DeviceName", "device_name"},
            {"ResponseType", "response_type"},
            {"State", "state"},
            {"ReferrerType", "referrerType"},
            {"Referrer", "referrer"},
            {"Otp", "otp"},
            {"Authorization", "Authorization"},
            {"IdentityType", "identityType"},
            {"LoginAsUserId", "loginAsUserId"},
            {"CallbackUri", "callback_uri"},
            {"Scope", "scope"},
            {"CodeChallenge", "code_challenge"},
            {"CodeChallengeMethod", "code_challenge_method"},
            {"Identity", "identity"},
        };
        public static string GetPodName(this string key)
        {
            return ParametersName.FirstOrDefault(_ => _.Key.Equals(key)).Value;
        }
    }
}
