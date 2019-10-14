using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library;
using Project0.DataAccess;
using Project0.DataAccess.Entities;


namespace Project0.Library
{
    public class Cart
    {
        public List<OrderItems> Products { get; set; }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public int? LocationId { get; set; }
        public DateTime OrderDate { get; set; }

        public Cart()
        {
            OrderId = Guid.NewGuid();
            Products = new List<OrderItems>();
            OrderDate = DateTime.Now;
        }

        public List<OrderItems> InvetoryItems()
        {
            return Products;
        }

        public int? InvetoryItems(Guid productId)
        {
            foreach (var item in Products)
            {
                if (item.ProductId.Equals(productId))
                {
                    return item.Quantity;
                }
            }

            return 0;
        }

        public void Add(OrderItems orderItem)
        {
            foreach (var item in Products)
            {
                if (item.ProductId == orderItem.ProductId)
                {
                    item.Quantity += orderItem.Quantity;
                    return;
                }
            }

            Products.Add(orderItem);
        }

        public bool Remove(Guid productId)
        {
            foreach (var item in Products)
            {
                if (item.ProductId.Equals(productId))
                {
                    Products.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public bool PlaceOrder()
        {
            // Check Stock once more
            foreach (var item in Products)
            {
                if (!DataConnection.ValidateStock(LocationId, item.ProductId.ToString(), (int)item.Quantity, 0))
                {
                    Console.WriteLine($"\tSomething went wrong when checking location for product id {item.ProductId}. It appears this location is out of that item now.");
                    return false;
                }
            }
            // Edit location stock
            foreach (var item in Products)
            {  

            var SuccessfulLocationStockUpdate = new DataConnection().UpdateLocationStock(item.ProductId, LocationId, item.Quantity);
            if(!SuccessfulLocationStockUpdate)
            {
                Console.WriteLine($"\tSomething went wrong when updating location stock for item {item.ProductId}");
                return false;
            }
            Console.WriteLine($"\tUpdated location stock for {item.ProductId}");
            }

            // Create order
            var SuccessfulCreateOrder = new DataConnection().CreateOrder(OrderId, CustomerId, LocationId, OrderDate);
            if (!SuccessfulCreateOrder)
            {
                Console.WriteLine($"\tSomething went wrong when placing order with id of {OrderId}");
                return false;
            }
            Console.WriteLine($"\tCreated order with an id of {OrderId}");
            // Create order items
            var SuccessfulCreateOrderItems = new DataConnection().CreateOrderItems(Products);
            if (!SuccessfulCreateOrderItems)
            {
                Console.WriteLine($"\tSomething went wrong when adding items to the order with id of {OrderId}");
                return false;
            }
            return true;
        }

    }
}
