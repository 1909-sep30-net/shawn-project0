using System;
using Project0.DataAccess.Entities;
using Project0.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Project0.DataAccess
{
    public class DataConnection
    {
        private project0Context db;
        private DbContextOptions<project0Context> options;

        public DataConnection()
        {
            //DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
            //   .UseSqlServer(SecretConfiguration.SecretString)
            //   .Options;
            //using //var db = new project0Context(options);
            //This would not work here with or without the using modifier... why?
        }

        //Create Methods
        //Customers
        public Customers CreateCustomer(string firstName, string lastName)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var NewCustomer = new Customers();
            NewCustomer.FirstName = firstName;
            NewCustomer.LastName = lastName;

            db.Add(NewCustomer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Exceptions:
                //   T:Microsoft.EntityFrameworkCore.DbUpdateException:
                //     An error is encountered while saving to the database.
                Console.WriteLine($"There was a database error :\n{ex}");
                return new Customers();
            }

            return NewCustomer;
        }

        // Retrieveal Methods
        // Customers
        public IEnumerable<Customers> GetAllCustomers()
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
            IQueryable<Customers> customers = db.Customers;
            return customers;
        }

        public IEnumerable<Customers> GetASingleCustomer(string userId)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
                IQueryable<Customers> customers = db.Customers.Where(n => n.CustomerId.ToString().Contains(userId));
                return customers;
        }

        public IEnumerable<Customers> GetASingleCustomer(string firstName, string lastName)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
            IQueryable<Customers> customers = db.Customers.Where(n => n.FirstName.Contains(firstName) && n.LastName.Contains(lastName));
            return customers;
        }

        // Retrieval Methods
        // Store Invetory
        public IEnumerable<LocationAndStockDesc> GetLocationStock(int locationId, string productId)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
            IEnumerable<LocationStock> ProductsAtStore = db.LocationStock.Where(n => n.LocationId == locationId && n.ProductId.ToString().Contains(productId));
            IEnumerable<Products> ProductsDetails = db.Products.Where(n => n.ProductId.ToString().Contains(productId));
            var StockDescriptions = from ld in db.LocationStock
                                    join pd in db.Products on ld.ProductId equals pd.ProductId
                                    join ls in db.Locations on ld.LocationId equals ls.LocationId
                                    select new LocationAndStockDesc(ld.LocationId, ls.LocationName, pd.ProductId, pd.ProductName, pd.ProductDesc, ld.Quantity);

            return StockDescriptions;
        }

        //Retrieval Methods
        // Get details of an order
        public IEnumerable<OrderHistory> GetSingleOrder(string orderId)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var AllOrders = from o in db.Orders
                            where (o.OrderId.ToString() == orderId)
                            join od in db.OrderItems on o.OrderId equals od.OrderId
                            join pd in db.Products on od.ProductId equals pd.ProductId
                            join cd in db.Customers on o.CustomerId equals cd.CustomerId
                            join ld in db.Locations on o.LocationId equals ld.LocationId
                            select new OrderHistory(o.OrderId, o.CustomerId, cd.FirstName, cd.LastName, o.LocationId, ld.LocationName, od.ProductId, pd.ProductName, pd.ProductDesc, od.Quantity);
            return AllOrders;
        }

        // Retrieval Methods
        // Get all History of custmer or store
        public IEnumerable<OrderHistory> GetOrderHistory(string customerId)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var AllOrders = from o in db.Orders
                            where (o.CustomerId.ToString() == customerId)
                            join od in db.OrderItems on o.OrderId equals od.OrderId
                            join pd in db.Products on od.ProductId equals pd.ProductId
                            join cd in db.Customers on o.CustomerId equals cd.CustomerId
                            join ld in db.Locations on o.LocationId equals ld.LocationId
                            select new OrderHistory(o.OrderId, o.CustomerId, cd.FirstName, cd.LastName, o.LocationId, ld.LocationName, od.ProductId, pd.ProductName, pd.ProductDesc, od.Quantity);
            return AllOrders;
        }

        //Retrieval
        // Get all History of customer or store

        public IEnumerable<OrderHistory> GetOrderHistory(int locationId)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var AllOrders = from o in db.Orders
                            where (o.LocationId == locationId) //(n => n.CustomerId == customerId)
                            join od in db.OrderItems on o.OrderId equals od.OrderId
                            join pd in db.Products on od.ProductId equals pd.ProductId
                            join cd in db.Customers on o.CustomerId equals cd.CustomerId
                            join ld in db.Locations on o.LocationId equals ld.LocationId
                            select new OrderHistory(o.OrderId, o.CustomerId, cd.FirstName, cd.LastName, o.LocationId, ld.LocationName, od.ProductId, pd.ProductName, pd.ProductDesc, od.Quantity);
            return AllOrders;
        }




    }
}
