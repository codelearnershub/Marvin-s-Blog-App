using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IFollowerService
    {
        public Follower AddFollower(int id, DateTime statedFollowing, int followeId);
        public void Unfollow(int id);
    }
}
