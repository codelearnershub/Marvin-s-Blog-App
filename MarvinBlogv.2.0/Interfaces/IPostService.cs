using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IPostService
    {
        public void AddBlogPost(int id, DateTime publishedOn, string name, string title, string featuredImageURL, string content, string description, string postURL, int userId);
        public Post FindById(int? id);
        public User FindByUser(int userId);
        public List<PostCategory> GetAllPostCategories(int postId);
        public IEnumerable<Post> GetAllPosts(int postId);
        public IEnumerable<Review> GetAllPostReviews(int postId);
        //public Post UpdatePost(int id, DateTime modifiedOn, DateTime publishedOn, string title,string featuredImageURL, string content, string description, string postURL, int postId, int userId, bool status);
        public void Delete(int id);
    }
}
