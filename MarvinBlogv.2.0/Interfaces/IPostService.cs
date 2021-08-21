using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IPostService
    {
        public Post AddBlogPost(int id, DateTime modifiedOn, DateTime publishedOn, string title, string content, string description, string postURL, int userId, bool status);
        public Post FindById(int? id);
        public User FindByUser(int userId);
        public IEnumerable<PostImages> GetAllPostImages(int postId);
        public IEnumerable<PostCategory> GetAllPostCategories(int postId);
        public IEnumerable<Post> GetAllPosts(int postId);
        public IEnumerable<Review> GetAllPostReviews(int postId);
        public Post UpdatePost(int id, DateTime modifiedOn, DateTime publishedOn, string title, string content, string description, string postURL, int postId, int userId, bool status);
        public void Delete(int id);
    }
}
