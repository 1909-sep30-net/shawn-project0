using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class CartItem
    {
        public int ProductQuantinty { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public CartItem(Guid orderId, Guid productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductQuantinty = quantity;
        }
    }
}
