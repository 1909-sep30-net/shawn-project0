using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Project0.DataAccess.Entities;
using Project0.Library.Interfaces;
using Project0.DataAccess.Repositories;

namespace Project0
{
    public static class Dependencies
    {
        public static ICustomerRepository CreateCustomerRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<project0Context>();
            optionsBuilder.UseSqlServer(SecretConfiguration.SecretString);

            var dbContext = new project0Context(optionsBuilder.Options);

            return new CustomerRepository(dbContext);
        }


    }
}
