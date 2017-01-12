using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spare.WebUI.Models;
using Store.Domain.Abstract;
using Store.Domain.Entitys;

namespace Spare.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductRepository repository;
        public int pageSize = 4;

        public ProductController (IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products.OrderBy(p=>p.ProductId).Skip((page - 1) * pageSize).Take(pageSize),
                PaigingInfo = new PaigingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Products.Count()
                }
           };
            
            return View(model);
        }

        //public ViewResult List(int page = 1)
        //{
        //    return View(repository.Products.OrderBy(prod=>prod.ProductId).Skip((page - 1)*pageSize).Take(pageSize));
        //}
    }
}