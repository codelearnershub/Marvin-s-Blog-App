using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using MarvinBlogv._2._0.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MarvinBlogv._2._0.Controllers
{
    public class ReviewController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IReviewService _reviewService;

        public ReviewController(IUserService userService, IReviewService reviewService, IPostService postService)
        {
            _userService = userService;
            _reviewService = reviewService;
            _postService = postService;
        }

        [Authorize(Roles = "blogger, admin")]
        public IActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        [Authorize(Roles = "admin, blogger")]
        public IActionResult Create() 
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            return View();
        }

        [System.Web.Mvc.HttpPost]
        [Authorize(Roles = "admin, blogger")]
        public IActionResult GetReviewByPostId(int id) 
        {
            ViewBag.Likes = _reviewService.ReviewCount(id);
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _reviewService.AddReview(userId, true, id);
           
            return RedirectToAction("Index", "Blogger");
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Authorize(Roles = "admin, blogger")]
        public IActionResult AddComment()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Authorize(Roles = "admin, blogger")]
        public IActionResult AddComment(CreateReviewViewModel model)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            _reviewService.AddComment(userId, model.Comment, model.Id);

            return View("Index", "Blogger");
        }

    }
}
