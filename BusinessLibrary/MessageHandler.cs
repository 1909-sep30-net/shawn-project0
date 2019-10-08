﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public static class MessageHandler
    {
        public static void LowStockError(IProduct product, int customerQuantity)
        {
            Console.WriteLine($"There are only {product.StockQuantity} of the {product.ProductDesc} in stock. No action taken. (Product Id : {product.ProductId}");
        }

        public static void SuccessfulRemove(IProduct product, int quantity)
        {
            Console.WriteLine($"Successfully removed {quantity} of {product.ProductName} from order. (Product Id : {product.ProductId})");
        }

        public static void SuccessfulRemove(IProduct product)
        {
            Console.WriteLine($"Successfully removed all {product.ProductName} from order. (Product Id : {product.ProductId})");
        }

        public static void SuccessfulAddition(IProduct product, int quantity)
        {
            Console.WriteLine($"Successfully added {quantity} of {product.ProductName} to order. (Product Id : {product.ProductId})");
        }

        public static void ItemsInCart(List<ICartItem> cart)
        {
                Console.WriteLine("========================");
            foreach (ICartItem item in cart)
            {
                Console.WriteLine($"Item : {item.Product.ProductName}");
                Console.WriteLine($"Desc : {item.Product.ProductDesc}");
                Console.WriteLine($"IdNo : {item.Product.ProductId}");
                Console.WriteLine($" Qty : {item.ProductQuantinty}");
                Console.WriteLine("========================");
            }
        }

    }
}
