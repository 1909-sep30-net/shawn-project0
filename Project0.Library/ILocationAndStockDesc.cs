using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public interface ILocationAndStockDesc
    {

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }

    }
}
