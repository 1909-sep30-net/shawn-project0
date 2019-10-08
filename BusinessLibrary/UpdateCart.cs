using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{

    /// <summary>
    /// UpdateCart Class holds actions to add or remove items from Cart
    /// AddItem(Products, product, quanity) :
    ///     Products is the entire list of items in cart.
    ///     product is the selected product.
    ///     quantity is the amount of product you want added to the cart.
    /// RemoveItem(Products, product, quanity) :
    ///     Products is the entire list of items in cart.
    ///     product is the selected product.
    ///     quantity is the amount of product you want removed from the cart.
    /// </summary>

    public class UpdateCart : IUpdateCart
    {
        public void AddItem(List<ICartItem> Products, IProduct product, int quantity)
        {
            string SelectedProdId = product.ProductId;
            bool match = false;

            //Checking items in cart for selected item id
            foreach (ICartItem cartItem in Products)
            {
                // If item is in cart, add the currently selected item quanity
                if (SelectedProdId == cartItem.Product.ProductId)
                {
                    match = true;
                    if (cartItem.ProductQuantinty + quantity <= product.StockQuantity)
                    {
                        cartItem.ProductQuantinty += quantity;
                        MessageHandler.SuccessfulAddition(product, quantity);
                    }
                    else
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

        public void RemoveItem(List<ICartItem> Products, IProduct product, int quantity)
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
    }
}
