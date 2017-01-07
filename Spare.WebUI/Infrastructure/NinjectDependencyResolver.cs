using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Moq;
using Ninject;

using Store.Domain.Abstract;
using Store.Domain.Concrete;
using Store.Domain.Entitys;

namespace Spare.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

       

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceTypes)
        {
            return kernel.GetAll(serviceTypes);
        }

        private void AddBindings()
        {
            // здесь буду привязки (зависимости)
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product {Name = "шаровая опора", Price = 150},
            //    new Product {Name = "рулевая тяга", Price = 200},
            //    new Product {Name = "рулевой наконечник", Price = 250},
            //    new Product {Name = "сайлентблок рычага", Price = 300}
            //});
            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }

    }
}