namespace MarvinBlogv._2._0.Models
{
    public class Follower : BaseEntity
    {
        public User User { get; set; }
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
    }
}
