using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Store.Domain.Abstract;
using Store.Domain.Entitys;
using Spare.WebUI.Controllers;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Spare.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_PaginatePossitive()
        {
            //ToDo Rename
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            { 
                new Product {Id = 1, Name = "товар1"},
                new Product { Id = 2, Name = "товар2"},
                new Product { Id = 3, Name = "товар3"},
                new Product { Id = 4, Name = "товар4"},
                new Product { Id = 5, Name = "товар5"}
                });
            var controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            //act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            //assert
            List<Product> products = result.ToList();
            Assert.IsTrue(products.Count == 2);
            Assert.AreEqual("товар4", products[0].Name, $"Goods error. Expected: товар4. Real:{products[0].Name}");
            Assert.AreEqual(products[1].Name, "товар5");
        }
    }
}
