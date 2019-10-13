using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.DataAccess.Entities
{
    public class OrderHistory
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? LocationId { get; set; }
        public string LocationName { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int? Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderHistory(Guid orderId, Guid customerId, string firstName, string lastName, int? locationId, string locationName, Guid productId, string productName, string productDesc, int? quantity, DateTime orderDate)
        {
            OrderId = orderId;
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            LocationId = locationId;
            LocationName = locationName;
            ProductId = productId;
            ProductName = productName;
            ProductDesc = productDesc;
            Quantity = quantity;
            OrderDate = orderDate;
        }
    }
}
