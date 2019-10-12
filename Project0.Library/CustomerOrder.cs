using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class CustomerOrder
    {
        // Customer ID
        // Store ID
        // Customer Cart

        // Place Order
        // Log Order

        string CustomerId { get; set; }
        string LocationId { get; set; }
        List<ICartItem> Products { get; set; }
        Dictionary<string, Dictionary<string, Product>> ProductDb { get; set; }

        public CustomerOrder (string customerId, string locationId, List<ICartItem> products, Dictionary<string, Dictionary<string, Product>> productDb)
        {
            this.CustomerId = customerId;
            this.LocationId = locationId;
            this.Products = products;
            this.ProductDb = productDb;
        }

        public Dictionary<string, Dictionary<string, Product>> UpdateLocationStock()
        {
            foreach (var item in Products)
            {
                var CustomerOrderProductId = item.Product.ProductId;

                foreach (var stockItem in ProductDb[LocationId])
                {
                    if (CustomerOrderProductId == stockItem.Value.ProductId)
                    {
                        stockItem.Value.StockQuantity -= item.ProductQuantinty;
                    }
                }
            }
            return ProductDb;
        }

        public void OrderLogger()
        {
            
        }

    }
}
