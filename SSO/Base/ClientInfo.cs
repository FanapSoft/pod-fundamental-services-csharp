using System.Collections.Generic;

namespace POD_SSO.Base
{
    public class ClientInfo
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public List<KeyValuePair<string, string>> Validate()
        {
            var message = "The ClientInfo field is required.";
            var hasErrorFields = new List<KeyValuePair<string, string>>();
            if(string.IsNullOrEmpty(ClientId)) hasErrorFields.Add(new KeyValuePair<string, string>(nameof(ClientId), message));
            if(string.IsNullOrEmpty(ClientSecret)) hasErrorFields.Add(new KeyValuePair<string, string>(nameof(ClientSecret), message));
            return hasErrorFields;
        }
    }
}
