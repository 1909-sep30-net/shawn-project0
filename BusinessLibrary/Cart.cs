using System;
using System.Collections.Generic;
using System.Text;
using BusinessLibrary;

namespace BusinessLibrary
{
    public class Cart : ICart
    {
        public List<ICartItem> Products { get; set; }

        public Cart()
        {
            Products = new List<ICartItem>();
        }

        public void AddItem(IProduct product, int quantity)
        {

            
            string SelectedProdId = product.ProductId;
            bool match = false;

            //Checking items in cart for selected item id
            foreach(ICartItem cartItem in Products)
            {
                // If item is in cart, add the currently selected item quanity
                if (SelectedProdId == cartItem.Product.ProductId)
                {
                    cartItem.ProductQuantinty += quantity;                    
                    match = true;
                }

            }
            if (match == true)
            {
                match = false;
            } else
            {
                // If item is not in cart, prepare a cart item and add it to products list
                ICartItem NewItem = Factory.CreateCartItem();
                NewItem.Product = product;
                NewItem.ProductQuantinty = quantity;
                this.Products.Add(NewItem);
            }
        }

        public void RemoveItem(ICartItem product)
        {
            Products.Remove(product);
        }

        public List<ICartItem> InvetoryItems()
        {
            Console.WriteLine("----------");
            foreach (var item in Products)
            {
                Console.WriteLine($"{item.Product.ProductName} {item.ProductQuantinty}");
                //Console.WriteLine($"{item.Product.ProductId}\t\t {item.Product.ProductName}\t\t {item.Product.ProductDesc}\t\t {item.Product.StockQuantity} \t\t {item.ProductQuantinty}");
            }
            Console.WriteLine("----------");
            return Products;
        }

    }
}
