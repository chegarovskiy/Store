using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.Entitys
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {

         private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; } 
        } 

        // adding new product to cart or exchange it quantity in cart 
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        public double ComputTotalValue()
        {
            return lineCollection.Sum(l => l.Product.Price*l.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }

}