using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Order
    {
        string OrderId { get; set; }
        string StoreId { get; set; }
        string CustomerId { get; set; }
        List<ICartItem> Products { get; set; }
        DateTime OrderTime { get; set; }


        Order(string customerId, string storeId, List<ICartItem> products, DateTime orderDate)
        {
            this.OrderId = Guid.NewGuid().ToString();
            this.CustomerId = customerId;
            this.StoreId = storeId;
            this.Products = products;
            this.OrderTime = DateTime.Now;
        }

        public Dictionary<string, string> OrderLogIds = new Dictionary<string, string>();


        public Dictionary<string, string> GenerateOrderLogIds()
        {
            OrderLogIds.Add("OrderId", OrderId);
            OrderLogIds.Add("CustomerId", CustomerId);
            OrderLogIds.Add("StoreId", StoreId);
            OrderLogIds.Add("OrderTime", OrderTime.ToString());
            return OrderLogIds;
        }

        public Dictionary<string, List<ICartItem>> OrderLogProducts = new Dictionary<string, List<ICartItem>>();
        public Dictionary<string, List<ICartItem>> GenerateOrderLogProducts()
        {
            OrderLogProducts.Add(OrderId, Products);
            return OrderLogProducts;
        }
    }

}
