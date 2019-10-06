using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Product : IProduct
    {
        public string ProductId { get; set; }
        public int StockQuantity { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid().ToString();


        }
    }


}
