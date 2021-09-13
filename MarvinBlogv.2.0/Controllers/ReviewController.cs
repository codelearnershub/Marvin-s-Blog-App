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
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MarvinBlogv._2._0.Controllers
{
    public class ReviewController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IUserRoleService _userRoleService;
        private readonly IReviewService _reviewService;
        private readonly IFollowerService _followerService;

        public ReviewController(IUserService userService, IReviewService reviewService, IPostService postService, IFollowerService followerService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _reviewService = reviewService;
            _postService = postService;
            _followerService = followerService;
            _userRoleService = userRoleService;
        }

        [Authorize(Roles = "blogger, admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Authorize(Roles = "admin, blogger")]
        public IActionResult Create() 
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin, blogger")]
        public IActionResult GetReviewByPostId(int id) 
        {
            ViewBag.Likes = _reviewService.ReviewCount(id);
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var review = _reviewService.CheckLike(id, userId);
            if (review != null)
            {
                _reviewService.Delete(review.Id);
                return RedirectToAction("Index", "Blogger");
            }
            _reviewService.AddReview(userId, true, id);
           
            return RedirectToAction("Index", "Blogger");
        }

       
        [Authorize(Roles = "admin, blogger")]
        public IActionResult AddComment()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin, blogger")]
        public IActionResult AddComment(CreateReviewViewModel model)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            _reviewService.AddComment(userId, model.Comment, model.Id);

            return View("Index", "Blogger");
        }


        public IActionResult LikeList(int id)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            var roles = _userRoleService.FindUserRole(userId);

            ViewBag.Role = roles[0].Name;


            ViewBag.name = user.FullName;
            ViewBag.PostId = id;
            ViewBag.email = user.Email;
            List<LikeList> likeLists = new List<LikeList>();
            var reviews = _reviewService.FindByPostId(id);
            foreach(var review in reviews)
            {
                var posterRole = _userRoleService.FindUserRole(review.UserId)[0].Name;
                bool following = false;
                if (_followerService.CheckFollow(userId, review.UserId) != null)
                {
                    following = true;
                }
                var likeList = new LikeList
                {
                    FullName = _userService.FindUserById(review.UserId).FullName,
                    UserId = _userService.FindUserById(review.UserId).Id,
                    CreatedAt = review.CreatedAt,
                    PosterRole = posterRole,
                    IsFollowing = following,
                };

                likeLists.Add(likeList);
            }
            return View(likeLists);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult GetReviewList(int id)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var roles = _userRoleService.FindUserRole(userId);

            ViewBag.Role = roles[0].Name;

            var post = _postService.FindById(id);
            ViewBag.UserId = userId;
            List<CommentList> CommentList = new List<CommentList>();
            var comments = _reviewService.GetAllComments(id); ;

            foreach (var comment in comments)
            {
                var posterRole = _userRoleService.FindUserRole(comment.UserId)[0].Name;
                CommentList commentList = new CommentList
                {
                    Id = comment.Id,
                    UserId = comment.UserId,
                    FullName = _userService.FindUserById(comment.UserId).FullName,
                    Comment = comment.Comment,
                    CreatedAt = comment.CreatedAt,
                    PosterRole = posterRole,
                    CommentCount = _reviewService.CommentCount(post.Id),
                };
                CommentList.Add(commentList);
            }

            return View(CommentList);
        }

        public IActionResult DeleteComment(int id) 
        {
            var comment =  _reviewService.FindReviewById(id);
            if(comment == null)
            {
                return NotFound();
            }
            _reviewService.Delete(comment.Id);

            return RedirectToAction("GetReviewList", new { id = comment.PostId });
        }
    }
}
