using System.Collections.Generic;

namespace POD_UserOperation.Base
{
    public static class PodParameterName
    {
        public static Dictionary<string, string> ParametersName = new Dictionary<string, string>
        {
            {"Token", "_token_"},
            {"TokenIssuer", "_token_issuer_"},
            {"ClientId", "client_id"},
            {"ClientSecret", "client_secret"},
            {"FirstName", "firstName"},
            {"LastName", "lastName"},
            {"NickName", "nickName"},
            {"Email", "email"},
            {"PhoneNumber", "phoneNumber"},
            {"CellphoneNumber", "cellphoneNumber"},
            {"NationalCode", "nationalCode"},
            {"Gender", "gender"},
            {"Address", "address"},
            {"BirthDate", "birthDate"},
            {"Country", "country"},
            {"State", "state"},
            {"City", "city"},
            {"PostalCode", "postalcode"},
            {"Sheba", "sheba"},
            {"ProfileImage", "profileImage"},
            {"ClientMetadata", "client_metadata"},
            {"BirthState", "birthState"},
            {"IdentificationNumber", "identificationNumber"},
            {"FatherName", "fatherName"},
        };

        public static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}
