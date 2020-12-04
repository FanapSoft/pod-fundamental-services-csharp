using System.Collections.Generic;

namespace Booking_Service.Base
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
            {"HotelId", "hotel_id"},
            {"ReferenceId", "reference_id"},
            {"CheckinDate", "checkin_date"},
            {"CheckoutDate", "checkout_date"},
            {"PaymentMethod", "payment_method"},
            {"Customer", "customer"},
            {"FirstName", "first_name"},
            {"LastName", "last_name"},
            {"NationalCode", "national_code"},
            {"PhoneNumber", "phone_number"},
            {"Country", "country"},
            {"Rooms", "rooms"},
            {"TypeId", "type_id"},
            {"Count", "count"},
            {"Party", "party"},
            {"StartDate", "start_date"},
            {"EndDate", "end_date"},
            {"Lang", "lang"},
            {"Currency", "currency"},
            {"UserCountry", "user_country"},
            {"HotelIds", "hotel_ids"},
            {"Authorization", "Authorization"},
        };
        internal static string GetPodName(this string key)
        {
            ParametersName.TryGetValue(key, out var podName);
            return podName;
        }
    }
}

