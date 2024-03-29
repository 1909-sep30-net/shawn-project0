﻿using System;
using System.Collections.Generic;

namespace Project0.DataAccess.Entities
{
    public partial class Locations
    {
        public Locations()
        {
            LocationStock = new HashSet<LocationStock>();
            Orders = new HashSet<Orders>();
        }

        public int? LocationId { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<LocationStock> LocationStock { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
