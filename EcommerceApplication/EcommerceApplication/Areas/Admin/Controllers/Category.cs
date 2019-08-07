using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApplication.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class Category : Controller
    {
        private readonly ICategory _categoryRepository;

        public Category(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            _categoryRepository.Insert(category);
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var cat = _categoryRepository.GetById(id);
            if (cat == null)
            {
                throw new Exception("Category doesn't exist");
            }
            return View(cat);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Update(Models.Category cat)
        {
            if (cat == null)
            {
                return RedirectToAction("Error","Home");
            }

            _categoryRepository.Update(cat);
            _categoryRepository.Save();
            return RedirectToAction("Index","Category","Admin");
        }
    }
}