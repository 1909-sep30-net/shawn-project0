using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Location
    {
        public string LocationId { get; set; }

        public Dictionary<string, Product> Stock { get; set; }

        public Location(string locationId, Dictionary<string, Product> stock)
        {
            this.LocationId = locationId;
            this.Stock = stock;
        }

        public void GetInvetory()
        {
            MessageHandler.AllStockAtLocation(Stock, LocationId);

        }

    }
}
