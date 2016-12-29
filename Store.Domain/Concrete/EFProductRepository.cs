using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Abstract;
using Store.Domain.Entitys;

namespace Store.Domain.Concrete
{
    public class EFProductRepository: IProductRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
          get { return context.Products; }
        }
    }
}
