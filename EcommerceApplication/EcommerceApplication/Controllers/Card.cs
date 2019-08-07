using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.DataContext;
using EcommerceApplication.Models;
using Microsoft.AspNetCore.Identity;
using EcommerceApplication.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using EcommerceApplication.ViewModels.Card;

namespace EcommerceApplication.Controllers
{
    public class Card : Controller
    {
        private readonly MyContext _db;
        private readonly UserManager<Customer> _userManager;
        private readonly ICartItem _cartItemRepository;

        public Card(MyContext db, UserManager<Customer> userManager, ICartItem cartItemRepository)
        {
            _db = db;
            _userManager = userManager;
            _cartItemRepository = cartItemRepository;
        }

        #region Card Index Page
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var query = from p in _db.CartItem
                        where p.CustomerId == userId
                        group p by new { p.Product.ProductName, p.Product.UnitPrice } into g
                        select new
                        {
                            Name = g.Key.ProductName,
                            Count = g.Count(),
                            Price = g.Key.UnitPrice
                        };

            CardIndexVM cardVM = new CardIndexVM();
            foreach (var item in query)
            {
                CardProductVM cProd = new CardProductVM();

                cProd.ProductName = item.Name;
                cProd.Quantity = item.Count;
                cProd.Price = item.Price;
                cProd.ProductTotal = item.Price * item.Count;
                
                cardVM.CardProductVMList.Add(cProd);
            }
            decimal total = cardVM.CardProductVMList.Sum(c => c.ProductTotal) * cardVM.CardProductVMList.Sum(c => c.Quantity);
            cardVM.CardTotalPrice = total;
            return View(cardVM);
        }
        #endregion

        #region Add to Card
        [HttpPost]
        public IActionResult Add([FromForm] int? id)
        {
            if (id != null)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                CartItem cartItem = new CartItem()
                {
                    CustomerId = userId,
                    AddedDate = DateTime.Now,
                    ProductId = Convert.ToInt32(id)
                };
                _db.CartItem.Add(cartItem);
                _db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Product not found");
                return NotFound();
            }

            return RedirectToAction("Index", "Product");
        }
        #endregion
    }
}