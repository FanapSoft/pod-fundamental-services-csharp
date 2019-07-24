
namespace POD_Billing.Model.ServiceOutput
{
    public class DealerProductPermissionSrv
    {
        public ProductSrv Product { get; set; }
        public BusinessDealerSrv BusinessDealer { get; set; }
        public bool Enable { get; set; }
    }
}
