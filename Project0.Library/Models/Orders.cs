﻿using System;
using System.Collections.Generic;

namespace Project0.Library.Models
{
    public partial class Orders
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public int? LocationId { get; set; }

        //public virtual Customers Customer { get; set; }
        //public virtual Locations Location { get; set; }
    }
}