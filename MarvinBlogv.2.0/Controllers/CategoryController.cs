using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
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
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly BlogDbContext _db;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, BlogDbContext db)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryService.GetAllCategories();

            return View(categories);
        }

        [Authorize]
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

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id) 
        {
            var post = _categoryService.FindById(id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
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
