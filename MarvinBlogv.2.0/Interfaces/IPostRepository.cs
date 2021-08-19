using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IPostRepository
    {
        public Post AddBlogPost(Post post);
        public Post FindById(int? id);
        public User FindByUser(int userId);
        public IEnumerable<PostImages> GetAllPostImages();
        public IEnumerable<PostCategory> GetAllPostCategories();
        public IEnumerable<Post> GetAllPosts();
        public IEnumerable<IReviewRepository> GetAllReviews();
        public Post UpdatePost(Post post);
        public void Delete(int id);
    }
}
