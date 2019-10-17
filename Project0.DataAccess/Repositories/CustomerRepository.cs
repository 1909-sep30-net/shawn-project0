using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project0.DataAccess.Entities;
using System.Linq;
using Project0.Library.Interfaces;
using Project0.Library.Models;


namespace Project0.DataAccess.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly project0Context _dbContext;

        public CustomerRepository(project0Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Library.Models.Customers> GetAllCustomers()
        {
            IEnumerable<Entities.Customers> customers = _dbContext.Customers;
            return customers.Select(Mapper.MapAllCustomers);
        }

        public Library.Models.Customers GetSingleCustomer(string customerId)
        {
            Entities.Customers customer = _dbContext.Customers.Where(n => n.CustomerId.ToString().Contains(customerId)).First();
            return Mapper.MapAllCustomers(customer);
        }

        public Library.Models.Customers AddCustomer(string firstName, string lastName)
        {
            Library.Models.Customers NewCustomer = new Library.Models.Customers(firstName, lastName);

            _dbContext.Customers.Add( Mapper.MapAllCustomers(NewCustomer) );
            _dbContext.SaveChanges();

            return NewCustomer;
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }

}
