using System;
using Project0.DataAccess.Entities;
using Project0.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Project0.DataAccess
{

    /// <summary>
    /// This class handles DataBase Connection returns.
    /// </summary>
    /// <remarks>
    /// This class needs to be DRY'd, up which is in process on the /repo-pattern branch on github
    /// </remarks>
    public class DataConnection
    {

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private project0Context db;
        private DbContextOptions<project0Context> options;

        /// <summary>
        /// This method was to implemented as a way to use dbContext.
        /// </summary>
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
        /// <summary>
        /// This method creates a customer in the database.
        /// It needs two strings, a first name and last name.
        /// </summary>
        /// <returns>
        /// Customers Object that contains the customer name and id.
        /// </returns>
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
                Console.WriteLine($"There was a database error, please try again and if the error persists, contact a supervisor :\n{ex}");
                logger.Error($"There was a database error while creating a customer :\n{ex}");
                return new Customers();
            }

            return NewCustomer;
        }

        //Retrieval Methods
        // Validation - Customer
        /// <summary>
        /// This method validates a CustomerId against all CustomerIds in the database
        /// </summary>
        /// <returns>
        /// bool - true if valid CustomerId, fase if not valid CustomerId
        /// </returns>
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
        /// <summary>
        /// This method validates a ProductId against all ProductId in the database
        /// </summary>
        /// <returns>
        /// bool - true if valid ProductId, fase if not valid ProductId
        /// </returns>
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
        //Retrieval Methods
        // Validation - ProductID
        /// <summary>
        /// This method validates a LocationId against all LocationId in the database
        /// </summary>
        /// <returns>
        /// bool - true if valid LocationId, fase if not valid LocationId
        /// </returns>
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
        // Validation - OrderId
        /// <summary>
        /// This method validates a OrderId against all OrderId in the database
        /// </summary>
        /// <returns>
        /// bool - true if valid OrderId, fase if not valid OrderId
        /// </returns>
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
        /// <summary>
        /// This method gets a list of all customers in the database
        /// </summary>
        /// <returns>
        /// IEnumerable<Customers>, list of all customers
        /// </returns>
        public IEnumerable<Customers> GetAllCustomers()
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
            IQueryable<Customers> customers = db.Customers;
            return customers;
        }

        /// <summary>
        /// This method returns information for a single user in the db by CustomerId
        /// </summary>
        /// <returns>
        /// Customers object with all the information for a single user
        /// </returns>
        public Customers GetASingleCustomer(string customerId)
        {
            Console.WriteLine("\tSearching by Id...");
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);
            IEnumerable<Customers> customers = db.Customers.Where(n => n.CustomerId.ToString().Contains(customerId));
            return SingleCustomerHandler(customers);
        }

        /// <summary>
        /// This method returns information for a single user in the db by a first and last name search
        /// </summary>
        /// <returns>
        /// Customers object with all the information for a single user
        /// </returns>
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

        /// <summary>
        /// This method handles an IEnumerable list of Customers that contain a single customer.
        /// </summary>
        /// <returns>
        /// Customers object with all the information for a single user
        /// </returns>
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
        /// <summary>
        /// This method returns an invetory of items and all thier information at a given location
        /// </summary>
        /// <returns>
        /// IQueryable of LocationandStockDesc objects
        /// </returns>
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
        /// <summary>
        /// This method checks to see if a given location more than a given amount
        /// The given amount is a sum of the item already in Cart.Products, along with the requesting abount.
        /// </summary>
        /// <returns>
        /// bool - true if there are enough items, false if there are not enough items.
        /// </returns>
        public static bool ValidateStock(int? locationId, string productId, int quantity, int? cartQuantity)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var Results = from ls in db.LocationStock
                          where ls.LocationId == locationId && ls.ProductId.ToString().Equals(productId)
                          where ls.Quantity >= (quantity + cartQuantity)
            select ls;

            return Results.Count() > 0;

        }

        //Retrieval Methods
        // Get details of an order
        /// <summary>
        /// This method will return the order details of a single order.
        /// </summary>
        /// <returns>
        /// IEnumerable of OrderHistory - Details of a single order
        /// </returns>
        public IEnumerable<OrderHistory> GetSingleOrder(string orderId)
        {
            DbContextOptions<project0Context> options = new DbContextOptionsBuilder<project0Context>()
                .UseSqlServer(SecretConfiguration.SecretString)
                .Options;
            var db = new project0Context(options);

            var AllOrders = from o in db.Orders
                            join oi in db.OrderItems on o.OrderId equals oi.OrderId
                            join c in db.Customers on o.CustomerId equals c.CustomerId
                            join l in db.Locations on o.LocationId equals l.LocationId
                            join p in db.Products on oi.ProductId equals p.ProductId
                            where (o.OrderId.ToString() == orderId)
                            select new OrderHistory(o.OrderId, o.CustomerId, c.FirstName, c.LastName, o.LocationId, l.LocationName, p.ProductId, p.ProductName, p.ProductDesc, oi.Quantity, o.OrderDate);
            return AllOrders;
        }

        // Retrieval Methods
        // Get all History of custmer
        /// <summary>
        /// This method will return all orders the customer has ever placed given a CustomerId.
        /// </summary>
        /// <returns>
        /// IEnumerable of Orders
        /// </returns>
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
        /// <summary>
        /// This method will return all orders a location has ever recieved given a LocationId.
        /// </summary>
        /// <returns>
        /// IEnumerable of Orders
        /// </returns>

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
        /// <summary>
        /// This method will return all orders a location has ever recieved given a LocationId.
        /// </summary>
        /// <returns>
        /// IEnumerable of Orders
        /// </returns>
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

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("There was a database error, try again and if the problem persists, contact a supervisor.");
                Console.WriteLine($"Error : {ex}");
                logger.Error($"There was a database error while creating a customer :\n{ex}");
                return false;
            }
            
        }

        //Create
        //Create Order
        /// <summary>
        /// This method will place order in the Orders table in the database,
        /// it only save the OrderId, CustomerId, LocationId and OrderDate
        /// </summary>
        /// <returns>
        /// bool - true if order save was successful, false if order save was not
        /// </returns>
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

            try
            {
                db.SaveChanges();
                return true;
            } catch(DbUpdateException ex)
            {
                Console.WriteLine("Something went wrong when saving to the database, try again and if the error persists contact a supervisor");
                Console.WriteLine($"Error : {ex}");
                logger.Error($"There was a database error while saving to the Orders table :\n{ex}");
                return false;
            }

        }

        //Create
        // Create Order Items
        /// <summary>
        /// This method will place OrderItems into the OrderItems table
        /// It only saves the OrderId, ProductId and quantity.
        /// </summary>
        /// <returns>
        /// bool - true if order save was successful, false if order save was not
        /// </returns>
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

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Something went wrong when saving to the database, try again and if the error persists contact a supervisor");
                Console.WriteLine($"Error : {ex}");
                logger.Error($"There was a database error while saving to the OrderItems table :\n{ex}");
                return false;
            }
        }


    }
}
