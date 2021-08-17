namespace MarvinBlogv._2._0.Models
{
    public class Follower : BaseEntity
    {
        public User FollowerId { get; set; }
        public User FollowingId { get; set; }
    }
}
