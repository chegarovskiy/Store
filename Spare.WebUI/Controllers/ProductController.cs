using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Store.Domain.Abstract;
using Store.Domain.Entitys;

namespace Spare.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductRepository repository;
        public int pageSize = 2;

        public ProductController (IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            return View(repository.Products.OrderBy(prod=>prod.ProductId).Skip((page - 1)*pageSize).Take(pageSize));
        }
    }
}