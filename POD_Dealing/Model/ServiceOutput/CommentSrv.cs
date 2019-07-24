
namespace POD_Dealing.Model.ServiceOutput
{
    public class CommentSrv
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long Timestamp { get; set; }
        public UserSrv User { get; set; }
        public bool Confirmed { get; set; }
        public long NumOfLikes { get; set; }
        public long NumOfComments { get; set; }
        public bool Liked { get; set; }
    }
}
