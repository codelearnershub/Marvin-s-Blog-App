using MarvinBlogv._2._0.DTO;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using MarvinBlogv._2._0.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Controllers
{
    public class PostController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IPostCategoryService _postCategoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostController(IUserService userService, IPostService postService, ICategoryService categoryService, IPostCategoryService postCategoryService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _postService = postService;
            _categoryService = categoryService;
            _postCategoryService = postCategoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "blogger")]
        [Authorize(Roles = "admin")]
        public IActionResult Index(int postId)
        {

            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            User user = _userService.FindUserById(userId);

            ViewBag.name = user.FullName;

            IEnumerable<Post> posts = _postService.GetAllPosts(postId);

            return View(posts);
        }

        [Authorize(Roles = "blogger")]
        [HttpGet]
        public IActionResult Create()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);
            ViewBag.userId = user.Email;
            ViewBag.id = user.Id;

            CreatePostViewModel vm = new CreatePostViewModel()
            {
                CategorySelectListItem = _categoryService.GetAllCategories().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
            };
            return View(vm);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePostViewModel model)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;
            if (model.Id == 0)
            {
                //Creating
                string upload = webRootPath + WC.PostImagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);
                string filePath = fileName + extension;

                using (var fileStream = new FileStream(Path.Combine(upload, filePath), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                model.FeaturedImageURL = fileName + extension;
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                _postService.AddBlogPost(model.Id, model.CreatedAt, model.Name, model.Title, model.FeaturedImageURL, model.Content, model.PostURL, model.Description, userId, model.Categories, model.CreatedBy);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult IsApproved(int id)
        {
            var posts = _postService.FindById(id);

            _postService.UpdatePost(posts.Id ,posts.CreatedAt, posts.Title, posts.FeaturedImageURL, posts.Content, posts.PostCategories, posts.Description, posts.PostURL, true);
         
            return RedirectToAction("Index", "Admin");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id) 
        {
            var post = _postService.FindById(id);
            if (post == null)
            {
                return NotFound();
            }
           
            return View(post);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(UpdatePostViewModel model) 
        {
            UpdatePostViewModel vm = new UpdatePostViewModel()
            {
                CategorySelectListItem = _categoryService.GetAllCategories().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
            };
            _postService.UpdatePost(model.Id, model.CreatedAt, model.Title, model.FeaturedImageURL, model.Content, model.PostCategories, model.Description, model.PostURL, false);
            return View(vm);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var post = _postService.FindById(id);

            if (post == null)
            {
                return NotFound();
            }

            _postService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
