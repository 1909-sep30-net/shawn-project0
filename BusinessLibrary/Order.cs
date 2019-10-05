using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Order
    {
        int StoreId { get; set; }
        int CustomerId { get; set; }
        int ProductId { get; set; }
        int OrderQuantity { get; set; }
        DateTime OrderTime { get; }


        Order(int productId, int orderQuantity, int customerId, int storeId)
        {
            this.ProductId = productId;
            this.OrderQuantity = orderQuantity;
            this.CustomerId = customerId;
            this.StoreId = storeId;
            this.OrderTime = DateTime.Now;
        }
    }

}
