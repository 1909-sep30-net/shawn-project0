using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Customer : ICustomer
    {
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string CustomerId { get; }
        public ICart CustomerCart { get; set; }


        //public List<string> customerInfo = new List<string>();

        public Customer() 
        { 
            CustomerId = Guid.NewGuid().ToString();
            CustomerCart = Factory.CreateCart(this);
        }

    }
}
