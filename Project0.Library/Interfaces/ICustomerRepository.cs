using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library.Models;

namespace Project0.Library.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {

        IEnumerable<Customers> GetAllCustomers();

        Library.Models.Customers GetSingleCustomer(string customerId);

        Library.Models.Customers AddCustomer(string firstName, string lastName);

    }
}
