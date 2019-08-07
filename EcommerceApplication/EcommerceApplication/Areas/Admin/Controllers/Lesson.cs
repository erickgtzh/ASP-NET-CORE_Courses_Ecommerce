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
    public class Lesson : Controller
    {
        private readonly ILesson _lessonRepository;

        public Lesson(ILesson lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _lessonRepository.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _lessonRepository.Insert(lesson);
            _lessonRepository.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var lesson = _lessonRepository.GetById(id);
            if (lesson == null)
            {
                throw new Exception("Lesson doesn't exist");
            }
            return View(lesson);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(Models.Lesson lesson)
        {
            if (lesson == null)
            {
                return RedirectToAction("Error", "Home");
            }

            _lessonRepository.Update(lesson);
            _lessonRepository.Save();
            return RedirectToAction("Index", "Lesson", "Admin");
        }
    }
}