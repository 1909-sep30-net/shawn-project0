using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Customer
    {
        public string NameFirst { get; }
        public string NameLast { get; }
        public string CustomerId { get; }

        public List<string> customerInfo = new List<string>();

        public Customer(string nameFirst, string nameLast)
        {
            this.NameFirst = nameFirst;
            this.NameLast = nameLast;
            this.CustomerId = Guid.NewGuid().ToString();

            this.customerInfo.Add(this.NameFirst);
            this.customerInfo.Add(this.NameLast);
            this.customerInfo.Add(this.CustomerId);
        }

        public List<string> GetCustomer()
        {
            return customerInfo;
        }

    }
}
