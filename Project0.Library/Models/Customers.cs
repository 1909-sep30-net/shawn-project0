using System;
using System.Collections.Generic;

namespace Project0.Library.Models
{
    public partial class Customers
    {
        public Customers()
        {
            //Orders = new HashSet<Orders>();
        }

        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public virtual ICollection<Orders> Orders { get; set; }
    }
}
