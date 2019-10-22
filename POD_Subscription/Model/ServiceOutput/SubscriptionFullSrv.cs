
namespace POD_Subscription.Model.ServiceOutput
{
    public class SubscriptionFullSrv
    {
        public long Id { get; set; }
        public long FromDate { get; set; }
        public long ToDate { get; set; }
        public long CreationDate { get; set; }
        public SubscriptionPlanSrv Plan { get; set; }
        public long UsageCount { get; set; }
        public decimal UsedAmount { get; set; }
        public UserSrv Subscriber { get; set; }
    }
}
