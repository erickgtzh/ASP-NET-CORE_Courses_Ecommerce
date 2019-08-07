using EcommerceApplication.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class Categories : Controller
    {
        private readonly ICategory _categoryRepository;

        public Categories(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var category = _categoryRepository.GetAll().ToList();
            return View(category);
        }
    }
}
