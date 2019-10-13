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

        //Retrieval Methods
        // Validation - Customer
        public static bool ValidateCustomerId(string userInput)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            
            var Results = db.Customers.Where(n => n.CustomerId.ToString().Contains(userInput));
            if (Results.Count() == 1)
            {
                return true;
            }
            return false;
        }


        //Retrieval Methods
        // Validation - ProductID
        public static bool ValidateProductId(string userInput)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);


            var Results = db.Products.Where(n => n.ProductId.ToString().Contains(userInput));
            if (Results.Count() == 1)
            {
                return true;
            }
            return false;
        }

        //Retrieval Methods
        // Validation - LocationId
        public static bool ValidateLocationId(string userInput)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            int intuserInput;
            if (!int.TryParse(userInput, out intuserInput))
            {
                return false;
            }

            var Results = db.Locations.Where(n => n.LocationId == intuserInput);
            if (Results.Count() == 1)
            {
                return true;
            }
            return false;
        }

        //Retrieval Methods
        // Validation - LocationId
        public static bool ValidateOrderId(string userInput)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
            Guid guidUserInput;

            if ( !Guid.TryParse(userInput, out guidUserInput) )
            {
                return false;
            }
            var Results = db.Orders.Where(n => n.OrderId.Equals(guidUserInput));
            if (Results.Count() == 1)
            {
                return true;
            }
            return false;
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

        public Customers GetASingleCustomer(string userId)
        {
            Console.WriteLine("\tSearching by Id...");
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
            IEnumerable<Customers> customers = db.Customers.Where(n => n.CustomerId.ToString().Contains(userId));
            return SingleCustomerHandler(customers);
        }

        public Customers GetASingleCustomer(string firstName, string lastName)
        {
            Console.WriteLine("\tSearching by Name...");
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
            IEnumerable<Customers> customers = db.Customers.Where(n => n.FirstName.Contains(firstName) && n.LastName.Contains(lastName));
            Console.WriteLine($"\t{customers.Count()} records found.");
            return SingleCustomerHandler(customers);
        }

        public Customers SingleCustomerHandler(IEnumerable<Customers> customerQuery)
        {
            var CustomerResult = new Customers();
            foreach (var customer in customerQuery)
            {
                CustomerResult.CustomerId = customer.CustomerId;
                CustomerResult.FirstName = customer.FirstName;
                CustomerResult.LastName = customer.LastName;
            }

            return CustomerResult;
        }

        // Retrieval Methods
        // Store Invetory
        public IQueryable<LocationAndStockDesc> GetLocationStock(int locationid)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var Invetory = from ls in db.LocationStock
                           where ls.LocationId == locationid
                           join pd in db.Products
                           on ls.ProductId equals pd.ProductId
                           join lc in db.Locations
                           on ls.LocationId equals lc.LocationId
                           select new LocationAndStockDesc( ls.LocationId, lc.LocationName, ls.ProductId, pd.ProductName, pd.ProductDesc, ls.Quantity );

            return Invetory;
        }

        // See if there is enough of a product in stock at a location
        public static IQueryable<LocationStock> ValidateStock(int locationId, string productId, int quantity, int? cartQuantity)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var Results = from ls in db.LocationStock
                          where ls.LocationId == locationId && ls.ProductId.ToString().Equals(productId)
                          where ls.Quantity >= (quantity + cartQuantity)
            select ls;

            return Results;

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
                            select new OrderHistory(o.OrderId, o.CustomerId, cd.FirstName, cd.LastName, o.LocationId, ld.LocationName, od.ProductId, pd.ProductName, pd.ProductDesc, od.Quantity, o.OrderDate);
            return AllOrders;
        }

        // Retrieval Methods
        // Get all History of custmer
        public IEnumerable<Orders> GetOrderHistory(string customerId)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var AllOrders = from o in db.Orders
                            where (o.CustomerId.ToString() == customerId)
                            select o;
                            
            return AllOrders;
        }

        //Retrieval
        // Get all History of store

        public IEnumerable<Orders> GetOrderHistory(int? locationId)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var AllOrders = from o in db.Orders
                            where (o.LocationId == locationId)
                            select o;
            return AllOrders;
        }

        
        // Place an order
         // Update
         // Update Location Stock
        public bool UpdateLocationStock(Guid productId, int? locationId, int? quantity)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            

            var CurrentItem = from ls in db.LocationStock
                              where ((ls.ProductId.Equals(productId)) && (ls.LocationId == locationId))
                              select ls;
            if (CurrentItem.Count() != 1)
            {
                Console.WriteLine("Item Count too low");
                return false;
            }
            
            CurrentItem.First().Quantity -= (int)quantity;
            db.SaveChanges();
            return true;
        }

        //Create
        //Create Order
        public bool CreateOrder(Guid orderId, Guid customerId, int? LocationId, DateTime orderDate)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var NewOrder = new Orders();
            NewOrder.OrderId = orderId;
            NewOrder.CustomerId = customerId;
            NewOrder.LocationId = LocationId;
            NewOrder.OrderDate = orderDate;

            db.Orders.Add(NewOrder);
            db.SaveChanges();
            return true;
        }

        //Create
        // Create Order Items
        public bool CreateOrderItems(List<OrderItems> products)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            foreach (var item in products)
            {
                var NewOrderItem = new OrderItems();
                NewOrderItem.OrderId = item.OrderId;
                NewOrderItem.ProductId = item.ProductId;
                NewOrderItem.Quantity = item.Quantity;

                db.OrderItems.Add(NewOrderItem);
            }

            return true;
        }


    }
}
