using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Services.Infrastructure;
using Microsoft.AspNetCore.Identity;
using EcommerceApplication.Models;
using EcommerceApplication.Areas.Admin.AdminVM;
using System.IO;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class Products : Controller
    {
        private readonly IProduct _productRepository;
        private readonly ICategory _categoryRepository;
        private readonly UserManager<Customer> _userManager;
        private IHostingEnvironment _environment;

        public Products(IProduct productRepository, ICategory categoryRepository, UserManager<Customer> userManager, IHostingEnvironment environment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var product = _productRepository.GetAll();

            return View(product);
        }

        #region Create Products
        [HttpGet]
        public IActionResult Create()
        {
            var createProduct = new CreateProduct
            {
                Products = new Product(),
                Category = _categoryRepository.GetAll().ToList()
            };
            return View(createProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProduct productVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Create Image

            if ((productVM.Products.ProductImage != null) && (productVM.Products.ProductImage.Length > 0))
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");

                using (var fileStream = new FileStream(Path.Combine(uploads, productVM.Products.ProductImage.FileName), FileMode.Create))
                {
                    productVM.Products.ProductImage.CopyTo(fileStream);
                }
                productVM.Products.ProductImagePath = productVM.Products.ProductImage.FileName.ToString();
            }



            _productRepository.Insert(productVM.Products);

            try
            {
                _productRepository.Save();
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}