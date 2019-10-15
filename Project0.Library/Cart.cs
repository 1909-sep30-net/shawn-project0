using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library;
using Project0.DataAccess;
using Project0.DataAccess.Entities;


namespace Project0.Library
{
    /// <summary>
    /// Cart Class handles a product list to hold items that will be placed on order.
    /// </summary>
    /// <remarks>
    /// This class can add, remove, invetory and place orders on a list of items.
    /// </remarks>
    public class Cart
    {

        /// <summary>
        /// The Cart class properties are all required in order to process a final order
        /// </summary>
        /// <value>List that holds items to be placed on order.</value>
        public List<OrderItems> Products { get; set; }
        /// <value>If user places order, this will be the OrderId for that order.</value>
        public Guid OrderId { get; set; }
        /// <value>CustomerId of customer who the order is being placed for.</value>
        public Guid CustomerId { get; set; }
        /// <value>LocationId of location where the order will be placed at.</value>
        public int? LocationId { get; set; }
        /// <value>Time and Date that the cart was created.</value>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// This Cart class constructor generates an GUID for the OrderId,
        /// a DateTime object for the create date, and instantiates
        /// a new Products list for OrderItems.
        /// </summary>
        public Cart()
        {
            OrderId = Guid.NewGuid();
            Products = new List<OrderItems>();
            OrderDate = DateTime.Now;
        }

        /// <summary>
        /// This method is used to see what items are in the Products List.
        /// </summary>
        /// <returns>List&lt;OrderItems&gt; to represent items in the cart.</returns>
        public List<OrderItems> InvetoryItems()
        {
            return Products;
        }

        /// <summary>
        /// This method is used to see if a particular item is in the Products List.
        /// </summary>
        /// <returns>int? to represent the number of a particular item in the cart.</returns>
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

        /// <summary>
        /// This method is used add an OrderItems object to the cart.
        /// </summary>
        /// <returns>void</returns>
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

        /// <summary>
        /// This method is used remove an OrderItems object to the cart.
        /// </summary>
        /// <returns>bool - true means the item was removed, false means the item was not removed</returns>
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

        /// <summary>
        /// This method is used to place OrderItems in cart on order.
        /// It has 3 parts, rechecking the location stock, depleting the location stock and creating the order in the database.
        /// </summary>
        /// <returns>bool - true means the items were ordered, false means the items were not removed</returns>
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
