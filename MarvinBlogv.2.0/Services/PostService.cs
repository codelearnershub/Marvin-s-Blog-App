using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Services
{
    public class PostService : IPostService
    {
        private readonly IUserService _userService;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostCategoryRepository _postCategoryRepository;
        public PostService(IUserService userService, IPostRepository postRepository, IPostCategoryRepository postCategoryRepository, ICategoryRepository categoryRepository)
        {
            _userService = userService;
            _postRepository = postRepository;
            _postCategoryRepository = postCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public void AddBlogPost(int id, DateTime publishedOn, string name, string title, string featuredImageURL, string content, string description, string postURL, int userId, string[] categoryIds)
        {
            if(categoryIds.Length != 0)
            {
                var postCategories = new List<PostCategory>() { };
                foreach (var catId in categoryIds)
                {
                    var postCat = new PostCategory
                    {
                        PostId = id,
                        CategoryId = int.Parse(catId),
                    };
                    postCategories.Add(postCat);
                }
                Post post = new()
                {
                    Id = id,
                    PublishedOn = DateTime.Now,
                    Title = title,
                    FeaturedImageURL = featuredImageURL,
                    Content = content.ToUpper(),
                    PostCategories = postCategories,
                    Description = description,
                    PostURL = postURL,
                    UserId = _userService.FindUserById(userId).Id,
                };

                _postRepository.AddBlogPost(post);
            }
            
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public Post FindById(int? id)
        {
            return _postRepository.FindById(id);
        }

        public User FindByUser(int userId)
        {
            return _userService.FindUserById(userId);
        }

        public List<PostCategory> GetAllPostCategories(int postId)
        {
            var postCategory = _postRepository.GetAllPostCategories(postId);
            return postCategory;
        }

        public IEnumerable<Review> GetAllPostReviews(int postId)
        {
            var review = _postRepository.GetAllPostReviews(postId);
            return review;
        }

        public IEnumerable<Post> GetAllPosts(int postId)
        {
            var posts = _postRepository.GetAllPosts().Select(p => new Post
            {
                Id = p.Id,
                CreatedAt = DateTime.Now,
                Title = p.Title.ToUpper(),
                Content = p.Content.ToUpper(),
                Description = p.Description.ToUpper(),
                Reviews = _postRepository.GetAllPostReviews(postId).ToList(),
                PostURL = p.PostURL,
                Status = p.Status
            }).ToList();

            return posts;
        }

        //public Post UpdatePost(int id, DateTime modifiedOn, DateTime publishedOn, string title, string featuredImageURL, string content, string description, string postURL, List<Category> categories, int postId, int userId, bool status)
        //{
        //    var post = _postRepository.FindById(id);

        //    post.LastModifiedOn = DateTime.Now;

        //    post.CreatedAt = DateTime.Now;

        //    post.Title = title.ToUpper();

        //    post.FeaturedImageURL = featuredImageURL.ToLower();

        //    post.Content = content.ToUpper();


        //    post.Description = description.ToUpper();

        //    post.PostURL = postURL.ToLower();

        //    post.Categories = _postCategoryRepository.GetAllPostCategories(postId);

        //    post.Reviews = _postRepository.GetAllPostReviews(postId).ToList();

        //    return _postRepository.UpdatePost(post);
        //}
    }
}
