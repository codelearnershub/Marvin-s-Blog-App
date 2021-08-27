using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _dbContext;

        public PostRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Post AddBlogPost(Post post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return post;
        }

        public void Delete(int id)
        {
            var post = FindById(id);
            {
                if (post != null)
                {
                    _dbContext.Posts.Remove(post);
                    _dbContext.SaveChanges();
                }
            }
        }

        public Post FindById(int? id)
        {
            return _dbContext.Posts.Find(id);
        }

        public User FindByUser(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public List<PostCategory> GetAllPostCategories(int postId)
        {
            return _dbContext.PostCategories.Where(post => post.PostId == postId).ToList();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _dbContext.Posts.ToList();
        }

        public IEnumerable<Review> GetAllPostReviews(int postId)
        {
            return _dbContext.Reviews.Where(review => review.PostId == postId).ToList();
        }

        public Post UpdatePost(Post post)
        {
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
            return post;
        }
    }
}
