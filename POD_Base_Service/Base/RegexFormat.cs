
namespace POD_Base_Service.Base
{
    public static class RegexFormat
    {
        public const string Numeric = @"^\d+$";
        public const string NumericEn = "^[0-9]+$";
        public const string MobileNumber = @"^(0|\+98|0098){1}[9]{1}[\d]{9}$";
        public const string NationalCode = @"^(\d)(?!\1{9}$)\d{9}$";
        public const string Sheba = @"^(\d)(?!\1{23}$)\d{23}$";
        public const string Url = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        public const string ShamsiDateTime = @"[1][3-5][0-9]{2}\/([1-9]|0[1-9]|1[0-2])\/([1-2][0-9]|0[1-9]|3[0-1]|[1-9])( (2[0-3]|[01]?[0-9]):[0-5]?[0-9](:[0-5]?[0-9])?)?";
        public const string ShamsiDate = @"[1][3-5][0-9]{2}\/([1-9]|0[1-9]|1[0-2])\/([1-2][0-9]|0[1-9]|3[0-1]|[1-9])";
        public const string Email = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public const string PostalCode = @"^(?!(\d)\\1{3})[13-9]{4}[1346-9][013-9]{5}$";
        public const string WhiteSpace = @"\s+";
    }
}

