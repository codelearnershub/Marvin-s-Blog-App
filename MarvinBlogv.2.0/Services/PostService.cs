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
        public PostService(IUserService userService, IPostRepository postRepository)
        {
            _userService = userService;
            _postRepository = postRepository;
        }

        public Post AddBlogPost(int id, DateTime modifiedOn, DateTime publishedOn, string title, string content, string description, string postURL, int userId, bool status)
        {
            Post post = new Post
            {
                Id = id,
                PublishedOn = DateTime.Now,
                LastModifiedOn = DateTime.Now,
                Title = title.ToUpper(),
                Content = content.ToUpper(),
                Description = description.ToUpper(),
                PostURL = postURL.ToLower(),
                Status = status,        
                User = _userService.FindUserById(userId)
            };

            _postRepository.AddBlogPost(post);

            return post;
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

        public IEnumerable<PostCategory> GetAllPostCategories(int postId)
        {
            var postCategory = _postRepository.GetAllPostCategories(postId);
            return postCategory;
        }

        public IEnumerable<PostImages> GetAllPostImages(int postId)
        {
            var postImages = _postRepository.GetAllPostImages(postId);
            return postImages;
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
                Categories = _postRepository.GetAllPostCategories(postId).ToList(),
                PostImages = _postRepository.GetAllPostImages(postId).ToList(),
                Reviews = _postRepository.GetAllPostReviews(postId).ToList(),
                PostURL = p.PostURL,
                Status = p.Status
            }).ToList();

            return posts;
        }

        public Post UpdatePost(int id, DateTime modifiedOn, DateTime publishedOn, string title, string content, string description, string postURL, int postId, int userId, bool status)
        {
            var post = _postRepository.FindById(id);

            post.LastModifiedOn = DateTime.Now;

            post.CreatedAt = DateTime.Now;

            post.Title = title.ToUpper();

            post.Content = content.ToUpper();

            post.Description = description.ToUpper();

            post.PostURL = postURL.ToLower();

            post.Categories = _postRepository.GetAllPostCategories(postId).ToList();

            post.PostImages = _postRepository.GetAllPostImages(postId).ToList();

            post.Reviews = _postRepository.GetAllPostReviews(postId).ToList();

            return _postRepository.UpdatePost(post);
        }
    }
}
