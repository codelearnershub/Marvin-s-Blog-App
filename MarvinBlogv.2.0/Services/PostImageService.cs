using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Services
{
    public class PostImageService : IPostImageService
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly PostService _postService;

        public PostImageService(IPostImageRepository postImageRepository, PostService postService)
        {
            _postImageRepository = postImageRepository;
            _postService = postService;
        }

        public PostImages AddPostImage(int id, DateTime createdAt, string imageURL, int postId)
        {
            PostImages postImages = new PostImages
            {
                Id = id,
                CreatedAt = DateTime.Now,
                ImageURL = imageURL.ToUpper(),
                Post = _postService.FindById(postId)
            };

            return _postImageRepository.AddPostImage(postImages);
        }

        public void DeletePostImage(int id)
        {
            _postImageRepository.DeletePostImage(id);
        }

        public PostImages FindPostImage(int? id)
        {
            return _postImageRepository.FindPostImage(id);
        }

        public PostImages UpdatePostImage(int id, DateTime createdAt, string imageURL, int postId)
        {
            var postImages = FindPostImage(id);

            postImages.CreatedAt = DateTime.Now;

            postImages.ImageURL = imageURL;

            postImages.Post = _postService.FindById(postId);

            return _postImageRepository.UpdatePostImage(postImages);
        }
    }
}
