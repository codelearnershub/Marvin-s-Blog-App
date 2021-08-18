namespace MarvinBlogv._2._0.Models
{
    public class Follower : BaseEntity
    {
        public User Followers { get; set; }
        public int FollewerId { get; set; }
        public User Following{ get; set; }
        public int FollowingId { get; set; }
    }
}
