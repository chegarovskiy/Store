using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Spare.WebUI.Models;
using Store.Domain.Entitys;

namespace Spare.WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private readonly IProductRepository _repository;
        public CartController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}