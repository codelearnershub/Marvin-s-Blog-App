using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using MarvinBlogv._2._0.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MarvinBlogv._2._0.Controllers
{
    [Authorize(Roles = "blogger")]
    public class BloggerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IReviewService _reviewService;
        private readonly IPostCategoryService _postCategoryService;

        public BloggerController(IUserService userService, IPostService postService, ICategoryService categoryService, IPostCategoryService postCategoryService, IReviewService reviewService)
        {
            _userService = userService;
            _postService = postService;
            _categoryService = categoryService;
            _postCategoryService = postCategoryService;
            _reviewService = reviewService;
        }

        [Authorize]
        public IActionResult Index(int postId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            User user = _userService.FindUserById(userId);

            ViewBag.name = user.FullName;

            ViewBag.email = user.Email;

            List<ListPostVM> ListPosts = new List<ListPostVM>();
            var posts = _postService.ApprovedPost();

            foreach (var post in posts)
            {
                var postsCategory = _postCategoryService.GetCategoryByPostId(post.Id);

                var categories = new List<Category>();
              
                ListPostVM listPost = new ListPostVM
                {
                    Id = post.Id,
                    PostTitle = post.Title,
                    Content = post.Content,
                    Description = post.Description,
                    PostUrl = post.PostURL,
                    CreatedAt = post.CreatedAt,
                    CreatedBy = post.CreatedBy,
                    ImageUrl = post.FeaturedImageURL,
                    Status = post.Status,
                    PostCategories = post.PostCategories.Select(p => p.Category).ToList(),
                    Like = post.Reviews.Where(r => r.Reaction == true).Count(),
                };

                ListPosts.Add(listPost);
            }

            return View(ListPosts);
        }
    
    }
}
