using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using MarvinBlogv._2._0.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
        public IActionResult Index()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            User user = _userService.FindUserById(userId);

            ViewBag.name = user.FullName;

            return View();
        }

        //[Authorize(Roles = "blogger")]
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        //    User user = _userService.FindUserById(userId);
        //    ViewBag.userId = user.Email;
        //    ViewBag.id = user.Id;
        //    CreatePostViewModel vm = new CreatePostViewModel()
        //    {
        //        CategorySelectListItem = _categoryService.GetAllCategories().Select(c => new SelectListItem
        //        {
        //            Text = c.Name,
        //            Value = c.Id.ToString(),
        //        }),
        //    };
        //    return View(vm);
        //}

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(CreatePostViewModel model)
        //{
        //    int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

        //    _postService.AddBlogPost(model.Id, model.CreatedAt, model.Name,  model.Title, model.FeaturedImageURL, model.Content, model.Description, model.PostURL, userId);

        //    Post post = _postService.FindById(model.Id);

        //    var categories = _postCategoryService.GetAllPostCategories(post.Id);

        //    var category = categories[0].Id;     

        //    return RedirectToAction("Index");
    }
    //}
}
