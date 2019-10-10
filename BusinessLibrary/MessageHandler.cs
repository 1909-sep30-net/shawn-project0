using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public static class MessageHandler
    {
        public static void LowStockError(IProduct product, int customerQuantity)
        {
            Console.WriteLine($"There are only {product.StockQuantity} of the {product.ProductDesc} in stock. No action taken. (Product Id : {product.ProductId})");
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

        public static void ItemsInCart(List<ICartItem> cart, ICustomer owner)
        {
                Console.WriteLine("========================");
                Console.WriteLine($"Cust : {owner.NameLast}, {owner.NameFirst}");
                Console.WriteLine($"  Id : {owner.CustomerId}");
                Console.WriteLine("----------------------");
            foreach (ICartItem item in cart)
            {
                
                Console.WriteLine($"Item : {item.Product.ProductName}");
                Console.WriteLine($"Desc : {item.Product.ProductDesc}");
                Console.WriteLine($"IdNo : {item.Product.ProductId}");
                Console.WriteLine($" Qty : {item.ProductQuantinty}");
                Console.WriteLine("----------------------");
            }
                Console.WriteLine("========================");
        }

        public static void AllStockAtLocation(Dictionary<string, Product> stock, string store)
        {
            Console.WriteLine("========================");
            Console.WriteLine($"Store location {store}");
            Console.WriteLine($"  Id : {store}");
            Console.WriteLine("----------------------");
            foreach (var item in stock)
            {

                Console.WriteLine($"Item : {item.Value.ProductName}");
                Console.WriteLine($"Desc : {item.Value.ProductDesc}");
                Console.WriteLine($"IdNo : {item.Value.ProductId}");
                Console.WriteLine($" Qty : {item.Value.StockQuantity}");
                Console.WriteLine("----------------------");
            }
            Console.WriteLine("========================");
        }

        public static void ShowOrderHistory(List<Dictionary<string, string>> order, string type, string id)
        {
            Console.WriteLine("History of all orders");
            Console.WriteLine($"{type} : {id}");
            Console.WriteLine("========================");
            foreach (var line in order)
            {
                Console.WriteLine("========================");
                Console.WriteLine($"Customer Id : {line["CustomerId"]}");
                Console.WriteLine($"   Order Id : {line["OrderId"]}");
                Console.WriteLine($"  ProductId : {line["ProductId"]}");
                Console.WriteLine($"ProductName : {line["ProductName"]}");
                Console.WriteLine($"ProductDesc : {line["ProductDesc"]}");
                Console.WriteLine($"Qty ordered : {line["Qty"]}");
                Console.WriteLine($"Location Id : {line["StoreId"]}");
                Console.WriteLine($" Order Date : {line["OrderTime"]}");
                Console.WriteLine("========================");
            }
        }

    }
}
