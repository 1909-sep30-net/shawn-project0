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
                    match = true;
                    if (cartItem.ProductQuantinty + quantity <= product.StockQuantity) 
                    {
                        cartItem.ProductQuantinty += quantity;
                        
                    } else
                    {
                        MessageHandler.QuantityError(product.ProductName, product.StockQuantity, cartItem.ProductQuantinty);
                    }
                    
                }

            }

            if (match == true)
            {
                match = false;
            } else
            {
                // If item is not in cart, prepare a cart item and add it to products list

                if (quantity <= product.StockQuantity)
                {
                    ICartItem NewCartItem = Factory.CreateCartItem();
                    NewCartItem.Product = product;
                    NewCartItem.ProductQuantinty = quantity;
                    Products.Add(NewCartItem);
                }
                else
                {
                    MessageHandler.QuantityError(product.ProductName, product.StockQuantity, quantity);
                }
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
