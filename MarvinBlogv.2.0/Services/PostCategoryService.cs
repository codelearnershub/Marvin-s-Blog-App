using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;

namespace MarvinBlogv._2._0.Services
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly PostService _postService;
        private readonly CategoryService _categoryService;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, PostService postService, CategoryService categoryService)
        {
            _postCategoryRepository = postCategoryRepository;
            _postService = postService;
            _categoryService = categoryService;
        }

        public PostCategory AddPostCategory(int id, DateTime createdAt, int postId, int categoryId)
        {
            PostCategory postCategory = new PostCategory
            {
                Id = id,
                CreatedAt = DateTime.Now,
                Post = _postService.FindById(postId),
                Category = _categoryService.FindById(categoryId)
            };
            return _postCategoryRepository.AddPostCategory(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public PostCategory FindPostCategory(int id)
        {
            return _postCategoryRepository.FindPostCategory(id);
        }

        public PostCategory UpdatePostCategory(int id, DateTime createdAt, int postId, int categoryId)
        {
            var postCategory = _postCategoryRepository.FindPostCategory(id);

            postCategory.CreatedAt = DateTime.Now;

            postCategory.Post = _postService.FindById(postId);

            postCategory.Category = _categoryService.FindById(categoryId);

            return _postCategoryRepository.UpdatePostCategory(postCategory);
        }
    }
}
