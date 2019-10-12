using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Order
    {
        string OrderId { get; set; }
        string StoreId { get; set; }
        string CustomerId { get; set; }
        Dictionary<string, Dictionary<string,string>> OrderedProducts { get; set; }
        DateTime OrderTime { get; set; }
        public Dictionary<string, string> CartFormattedOrder { get; private set; }
        public Dictionary<string, Dictionary<string, string>> OrderLog { get; set; }

        public Order(string customerId, string storeId, List<ICartItem> products)
        {
            this.OrderId = Guid.NewGuid().ToString();
            this.CustomerId = customerId;
            this.StoreId = storeId;
            this.OrderTime = DateTime.Now;

            //changing StockQuantity to match ProductQuantity;
            foreach ( ICartItem item in products)
            {
                item.Product.StockQuantity = item.ProductQuantinty;
            }

            var CartFormattedOrder = new Dictionary<string, string>();

            foreach (ICartItem item in products)
            {
                CartFormattedOrder.Add("OrderId", OrderId);
                CartFormattedOrder.Add("CustomerId", CustomerId);
                CartFormattedOrder.Add("StoreId", StoreId);
                CartFormattedOrder.Add("ProductId", item.Product.ProductId);
                CartFormattedOrder.Add("ProductName", item.Product.ProductName);
                CartFormattedOrder.Add("ProductDesc", item.Product.ProductDesc);
                CartFormattedOrder.Add("Qty", item.Product.StockQuantity.ToString());
                CartFormattedOrder.Add("OrderTime", OrderTime.ToString());
            }

            this.OrderLog = new Dictionary<string, Dictionary<string, string>>();
            OrderLog.Add(OrderId, CartFormattedOrder);

        }        
    }

}
