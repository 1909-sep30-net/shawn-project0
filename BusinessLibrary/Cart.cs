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
                        MessageHandler.SuccessfulAddition(product, quantity);
                    } else
                    {
                        MessageHandler.LowStockError(product, cartItem.ProductQuantinty);
                    }
                    return;
                }
            }
                // If item is not in cart, prepare a cart item and add it to products list
                if (quantity <= product.StockQuantity)
                {
                    ICartItem NewCartItem = Factory.CreateCartItem();
                    NewCartItem.Product = product;
                    NewCartItem.ProductQuantinty = quantity;
                    Products.Add(NewCartItem);
                    MessageHandler.SuccessfulAddition(product, quantity);
                }
                else
                {
                    MessageHandler.LowStockError(product, quantity);
                }
        }

        public void RemoveItem(IProduct product, int quantity)
        {
            foreach (var cartItem in Products)
            {
                if (product.ProductId == cartItem.Product.ProductId)
                {
                    // If removal of items is greater than 0, change quantity
                    if (cartItem.ProductQuantinty - quantity > 0)
                    {
                        cartItem.ProductQuantinty -= quantity;
                        MessageHandler.SuccessfulRemove(product, quantity);
                    }
                    // If removal of items is 0 or less, remove the cart item
                    else
                    {
                        Products.Remove(cartItem);
                        MessageHandler.SuccessfulRemove(product);
                    }

                    return;
                }
            }
        }

        public void InvetoryItems()
        {

            MessageHandler.ItemsInCart(Products);

        }

    }
}
