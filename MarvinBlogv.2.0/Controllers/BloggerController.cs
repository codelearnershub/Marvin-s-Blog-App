using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MarvinBlogv._2._0.Controllers
{
    public class BloggerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IPostCategoryService _postCategoryService;

        public BloggerController(IUserService userService, IPostService postService, ICategoryService categoryService, IPostCategoryService postCategoryService)
        {
            _userService = userService;
            _postService = postService;
            _categoryService = categoryService;
            _postCategoryService = postCategoryService;
        }

        [Authorize(Roles = "blogger")]
        public IActionResult Index(int postId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            User user = _userService.FindUserById(userId);

            ViewBag.name = user.FullName;

            ViewBag.createdBy = user.Email;

            IEnumerable<Post> posts = _postService.GetAllPosts(postId);

            return View(posts);
        }
    }
}
