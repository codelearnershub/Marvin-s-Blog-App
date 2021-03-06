using MarvinBlogv._2._0.Models;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IFollowerRepository
    {
        public Follower AddFollower(Follower follower);
        public Follower FindById(int id);
        public void Unfollow(int id);
    }
}
