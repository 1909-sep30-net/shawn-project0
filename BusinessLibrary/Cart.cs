using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Cart : ICart
    {
        public List<IProduct> Products { get; set; }

        public Cart()
        {
            Products = new List<IProduct>();
        }

        public void AddItem(IProduct product)
        {
            Products.Add(product);
        }

        public void RemoveItem(IProduct product)
        {
            Products.Remove(product);
        }

        public List<IProduct> InvetoryItems()
        {
            Console.WriteLine("----------");
            foreach (var item in Products)
            {
                Console.WriteLine($"{item.ProductId}\t\t {item.ProductName}\t\t {item.ProductDesc}\t\t {item.StockQuantity}");
            }
            Console.WriteLine("----------");
            return Products;
        }

    }
}
