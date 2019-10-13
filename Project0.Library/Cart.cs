using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library;
using Project0.DataAccess.Entities;


namespace Project0.Library
{
    public class Cart
    {
        public List<OrderItems> Products { get; set; }
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderDate { get; set; }
        public IUpdateCart UpdateCart { get; set; }

        public Cart()
        {
            OrderId = Guid.NewGuid();
            Products = new List<OrderItems>();
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

        public bool Order()
        {
            return true;
        }

    }
}
