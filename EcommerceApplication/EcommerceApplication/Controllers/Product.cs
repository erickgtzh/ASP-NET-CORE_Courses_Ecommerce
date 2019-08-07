using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Services.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceApplication.Controllers
{
    public class Product : Controller
    {
        private readonly IProduct _productRepository;
        private readonly ICategory _categoryRepository;

        public Product(IProduct productRepository, ICategory categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = _productRepository.GetAll().ToList();
            return View(products);
        }

        public IActionResult ProductDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
                // or  return RedirectToAction("Home", "Error");
            }
            return View(_productRepository.GetById(Convert.ToInt32(id)));
        }
    }
}