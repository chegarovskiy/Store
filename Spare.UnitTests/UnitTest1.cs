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
        public void Can_Paginate()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            { 
                new Product {ProductId = 1, Name = "товар1"},
                new Product { ProductId = 2, Name = "товар2"},
                new Product { ProductId = 3, Name = "товар3"},
                new Product { ProductId = 4, Name = "товар4"},
                new Product { ProductId = 5, Name = "товар5"}
                });
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            //act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            //assert
            List<Product> products = result.ToList();
            Assert.IsTrue(products.Count == 2);
            Assert.AreEqual(products[0].Name, "товар4");
            Assert.AreEqual(products[1].Name, "товар5");
        }
    }
}
