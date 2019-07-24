
namespace POD_Dealing.Model.ServiceOutput
{
    public class UserBusinessInfoSrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int SubscriptionCount { get; set; }
        public bool Subscribed { get; set; }
        public RateSrv Rate { get; set; }
        public ImageInfoSrv ImageInfo { get; set; }
        public string Image { get; set; }
        public bool Favorite { get; set; }
    }
}
