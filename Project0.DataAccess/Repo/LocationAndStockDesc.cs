using System;
using System.Collections;

namespace Project0.DataAccess.Entities
{
    public class LocationAndStockDesc
    {

        public int? LocationId { get; set; }
        public string LocationName { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int Quantity { get; set; }

        public LocationAndStockDesc(int? locationId, string locationName, Guid productId, string productName, string productDesc, int quantity)
        {
            this.LocationId = locationId;
            this.LocationName = locationName;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.ProductName = productName;
            this.ProductDesc = productDesc;
        }
    }
}
