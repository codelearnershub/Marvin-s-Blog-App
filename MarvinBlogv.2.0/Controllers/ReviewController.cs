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
        private readonly IReviewService _reviewService;

        public ReviewController(IUserService userService, IReviewService reviewService)
        {
            _userService = userService;
            _reviewService = reviewService;
        }

        [Authorize(Roles = "blogger")]
        public IActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public IActionResult Create() 
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Create(CreateReviewViewModel model) 
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            _reviewService.AddReview(model.Id, model.CreatedAt, userId, model.Reaction, model.PostId, model.Comment);
            return View();
        }
    }
}
