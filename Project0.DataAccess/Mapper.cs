using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library.Models;

namespace Project0.DataAccess
{
    public static class Mapper
    {

        public static Library.Models.Customers MapAllCustomers(Entities.Customers customers)
        {
            return new Library.Models.Customers
            {
                CustomerId = customers.CustomerId,
                FirstName = customers.FirstName,
                LastName = customers.LastName
            };
        }


    }
}
