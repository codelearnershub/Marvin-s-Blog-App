using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.DTO;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using MarvinBlogv._2._0.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly BlogDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostController(IUserService userService, IPostService postService, ICategoryService categoryService, IPostCategoryService postCategoryService, IWebHostEnvironment webHostEnvironment, BlogDbContext db)
        {
            _userService = userService;
            _postService = postService;
            _categoryService = categoryService;
            _postCategoryService = postCategoryService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        [Authorize(Roles = "blogger, admin")]
        public IActionResult Index()
        {

            int UserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            User user = _userService.FindUserById(UserId);

            ViewBag.name = user.FullName;

            ViewBag.createdBy = user.Email;

            IEnumerable<Post> posts = _postService.GetAllPosts();

            return View(posts);
        }

        [Authorize(Roles = "blogger, admin")]
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

                _postService.AddBlogPost(model.Id, model.CreatedAt, model.Name, model.Title, model.FeaturedImageURL, model.Content, model.Description, model.PostURL, userId, model.Categories, model.CreatedBy, model.Status);
            }

            return RedirectToAction("Index", "Blogger");
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
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            UpdatePostViewModel vm = new UpdatePostViewModel()
            {
                CategorySelectListItem = _categoryService.GetAllCategories().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
            };
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
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var objFromDb = _db.Posts.AsNoTracking().FirstOrDefault(u => u.Id == model.Id);
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            if (files.Count > 0)
            {
                string upload = webRootPath + WC.PostImagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);
                string filePath = fileName + extension;

                var oldFile = Path.Combine(upload, objFromDb.FeaturedImageURL);

                if (System.IO.File.Exists(oldFile))
                {
                    System.IO.File.Delete(oldFile);
                }

                using (var fileStream = new FileStream(Path.Combine(upload, filePath), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                model.FeaturedImageURL = fileName + extension;
            }
            else
            {
                model.FeaturedImageURL = objFromDb.FeaturedImageURL;
            }
            _postService.UpdatePost(model.Id, model.CreatedAt, model.Title, model.FeaturedImageURL, model.Content, model.PostCategories, model.Description, model.PostURL, false);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var post = _postService.FindById(id);

            if (post == null)
            {
                return NotFound();
            }

            _postService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile(IFormFile aUploadedFile)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var vImageSavePath = string.Empty;
            string img = "";

            if (aUploadedFile.Length > 0)
            {
                var vFileName = Path.GetFileNameWithoutExtension(aUploadedFile.FileName);
                var vExtension = Path.GetExtension(aUploadedFile.FileName);

                string sImageName = vFileName + "-" + "image";
                img = WC.ContentImagePath + sImageName + vExtension;
                vImageSavePath = Path.Combine(_webHostEnvironment.ContentRootPath + "\\wwwroot\\" + "\\UploadFiles\\" + sImageName + vExtension);
                //vReturnImagePath = "/UploadFiles/" + sImageName + vExtension;
                ViewBag.Msg = vImageSavePath;
                var path = vImageSavePath;

                // Saving Image in Original Mode
                using (var stream = new FileStream(vImageSavePath, FileMode.Create))
                {
                    await aUploadedFile.CopyToAsync(stream);
                }
                var vImageLength = new FileInfo(path).Length;

            }
            //here to add Image Path to You Database,
            TempData["message"] = string.Format("Image was Added Successfully");
            return Json(img);
        }

        [HttpGet]
        public IActionResult GetCategoryByPostId(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var postsCategory = _postCategoryService.GetCategoryByPostId(id);
            List<Category> Categories = new List<Category>();
            foreach (var item in postsCategory)
            {
                var category = _categoryService.FindById(item.CategoryId);
                Categories.Add(category);
            }

            return View(Categories);
        }
    }
}
