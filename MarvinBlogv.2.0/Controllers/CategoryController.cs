using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using MarvinBlogv._2._0.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static MarvinBlogv._2._0.Models.ViewModel.CategoryViewModel;

namespace MarvinBlogv._2._0.Controllers
{
    [Authorize(Roles = "admin, blogger")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly IPostCategoryService _postCategoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly BlogDbContext _db;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, BlogDbContext db, IPostService postService, IPostCategoryService postCategoryService)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _postService = postService;
            _postCategoryService = postCategoryService;
        }

        [Authorize(Roles = "admin, blogger")]
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryService.GetAllCategories();

            return View(categories);
        }

        [HttpGet]
        [Authorize(Roles = "admin, blogger")]
        public IActionResult GetPostByCategoryId(int id) 
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var postsCategory = _postCategoryService.GetPostByCategoryId(id);
            List<Post> Posts = new List<Post>();
            foreach(var item in postsCategory)
            {
                var post = _postService.FindById(item.PostId);
                Posts.Add(post);
            }

            return View(Posts);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel model)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;
            if (model.Id == 0)
            {
                //Creating
                string upload = webRootPath + WC.ImagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName); 
                string filePath = fileName + extension;

                using (var fileStream = new FileStream(Path.Combine(upload, filePath), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                model.ImageURL = fileName + extension;
               
                _categoryService.AddCategory(model.Id, model.CreatedAt, model.Name, model.ImageURL);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Update(int id) 
        {
            var category = _categoryService.FindById(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public IActionResult Update(UpdateCategoryViewModel model) 
        {
            var objFromDb = _db.Categories.AsNoTracking().FirstOrDefault(u => u.Id == model.Id);
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            if (files.Count > 0)
            {
                string upload = webRootPath + WC.ImagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);
                string filePath = fileName + extension;

                var oldFile = Path.Combine(upload, objFromDb.ImageURL);

                if (System.IO.File.Exists(oldFile))
                {
                    System.IO.File.Delete(oldFile);
                }

                using (var fileStream = new FileStream(Path.Combine(upload, filePath), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                model.ImageURL = fileName + extension;
            }
            else
            {
                model.ImageURL = objFromDb.ImageURL;
            }

            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _categoryService.UpdateCategory(model.Id, model.CreatedAt, model.Name, model.ImageURL);

            return RedirectToAction("Index");
        }
    }
}
