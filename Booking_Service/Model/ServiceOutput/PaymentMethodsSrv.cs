using System.Collections.Generic;

namespace Booking_Service.Model.ServiceOutput
{
    public class PaymentMethodsSrv
    {
        public string Api_Version { get; set; }
        public string Lang { get; set; }
        public List<PaymentMethodSrv> Payment_Methods { get; set; }
    }
}
