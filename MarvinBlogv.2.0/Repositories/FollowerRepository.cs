using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Repositories
{
    public class FollowerRepository : IFollowerRepository
    {
        public readonly BlogDbContext _dbContext;

        public FollowerRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Follower AddFollower(Follower follower)
        {
            _dbContext.Followers.Add(follower);
            _dbContext.SaveChanges();
            return follower;
        }

        public Follower FindById(int id) 
        {
           return _dbContext.Followers.Find(id);
        }
        public void Unfollow(int id)
        {
            var unfollow = FindById(id);
            {
                if (unfollow != null)
                {
                    _dbContext.Followers.Remove(unfollow);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
