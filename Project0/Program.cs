using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project0.Library;
using Project0.DataAccess;
using Project0.DataAccess.Entities;
using System.Linq;
using Figgle;

namespace Project0
{
    public class Program
    {


        
      
        static void Main(string[] args)
        {


            Console.WriteLine(FiggleFonts.SubZero.Render("Project O"));
            Console.WriteLine(FiggleFonts.FireFontK.Render("The Banana Store Kiosk"));
            Console.WriteLine("The Banana Store Kiosk");

            ////begin temp UI
            var UserInput = "MainMenu";
            string User_CurrCustomerId = "";
            string User_CurrLocationId = "";

            
                
                

            //while (true)
            //{
            //    if (UserInput == "MainMenu")
            //    {
            //        Console.WriteLine("Enter a command : ");
            //        Console.WriteLine("O => Start new order");
            //        Console.WriteLine("A => Add new customer");
            //        Console.WriteLine("C => View customer history");
            //        Console.WriteLine("S => View store history");

            //        UserInput = Console.ReadLine().ToLower();

            //        //Console.Clear();
            //    }
            //    else if (UserInput == "a")
            //    {
            //        Console.WriteLine("Add new customer...");
            //        Console.WriteLine("Enter first name of new customer :");
            //        var User_NameFirst = Console.ReadLine();

            //        Console.WriteLine("Enter last name of new customer :");
            //        var User_NameLast = Console.ReadLine();

            //        Customer NewCustomer = (Customer)Factory.CreateCustomer();
            //        NewCustomer.NameFirst = User_NameFirst;
            //        NewCustomer.NameLast = User_NameLast;

            //        customerDB.Add(NewCustomer.CustomerId, NewCustomer);

            //        CustomerDataHandler.SaveCustomers(customerDB);
            //        Console.WriteLine($"Customer has been created with id of : {NewCustomer.CustomerId}");
            //        UserInput = "MainMenu";
            //    }
            //    else if (UserInput == "c")
            //    {
            //        Console.WriteLine("customer history...");


            //        if (User_CurrCustomerId == "")
            //        {
            //            Console.WriteLine("Enter CustomerId : ");
            //            User_CurrCustomerId = Console.ReadLine();

            //        }

            //        if (!ValidationHandler.CheckCustomerId(User_CurrCustomerId, customerDB))
            //        {
            //            User_CurrCustomerId = "";
            //            UserInput = "c";
            //            Console.WriteLine("Invalid Customer Id.");
            //        }
            //        else
            //        {


            //            var HistoryHandler = Factory.CreateHistoryHandler();
            //            HistoryHandler.Database = orderHistoryDB;
            //            HistoryHandler.TargetId = User_CurrCustomerId;
            //            HistoryHandler.RetrievalType = "CustomerId";
            //            Console.Clear();
            //            HistoryHandler.GetHistory();

            //            User_CurrCustomerId = "";
            //            UserInput = "MainMenu";
            //        }

            //    }
            //    else if (UserInput == "s")
            //    {
            //        Console.WriteLine("store history...");
            //        Console.WriteLine("Enter LocationId : ");

            //        User_CurrLocationId = Console.ReadLine();
            //        if (!ValidationHandler.CheckLocationId(User_CurrLocationId, productDB))
            //        {
            //            Console.WriteLine("Invalid Location Id");
            //            User_CurrLocationId = "";
            //            UserInput = "s";
            //        }
            //        else
            //        {

            //            var HistoryHandler = Factory.CreateHistoryHandler();
            //            HistoryHandler.Database = orderHistoryDB;
            //            HistoryHandler.TargetId = User_CurrLocationId;
            //            HistoryHandler.RetrievalType = "StoreId";
            //            Console.Clear();
            //            HistoryHandler.GetHistory();

            //            User_CurrLocationId = "";
            //            UserInput = "MainMenu";
            //        }

            //    }
            //    else if (UserInput == "o")
            //    {
            //        if (User_CurrCustomerId == "")
            //        {
            //            Console.WriteLine("Enter CustomerId : ");
            //            User_CurrCustomerId = Console.ReadLine();

            //        }

            //        if (!ValidationHandler.CheckCustomerId(User_CurrCustomerId, customerDB))
            //        {
            //            User_CurrCustomerId = "";
            //            UserInput = "o";
            //            Console.WriteLine("Invalid Customer Id.");
            //        }
            //        else
            //        {
            //            if (User_CurrLocationId == "")
            //            {
            //                Console.WriteLine("Enter LocationId : ");
            //                User_CurrLocationId = Console.ReadLine();
            //            }

            //            if (ValidationHandler.CheckLocationId(User_CurrLocationId, productDB))
            //            {

            //                Console.WriteLine("A => Add product");
            //                Console.WriteLine("R => Remove product");
            //                Console.WriteLine("V => View current order");
            //                Console.WriteLine("I => View store invetory");
            //                Console.WriteLine("P => Place order");
            //                Console.WriteLine("XCX => Cancel order");
            //                UserInput = Console.ReadLine().ToLower();
            //            }
            //            else
            //            {
            //                Console.WriteLine("Invalid Location Id");
            //                User_CurrLocationId = "";
            //                UserInput = "o";
            //            }
            //        }

            //        if (UserInput == "a")
            //        {

            //            Console.WriteLine("Enter ProductId : ");
            //            var User_CurrProductId = Console.ReadLine();

            //            if (ValidationHandler.CheckProductId(User_CurrProductId, productDB[User_CurrLocationId]))
            //            {
            //                Console.WriteLine("Enter Quantity : ");
            //                int User_Quantity = Convert.ToInt32(Console.ReadLine());
            //                customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.AddItem(customerDB[User_CurrCustomerId].CustomerCart.Products, productDB[User_CurrLocationId][User_CurrProductId], User_Quantity);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Invalid Product Id");
            //                UserInput = "a";
            //            }
            //        }
            //        else if (UserInput == "r")
            //        {
            //            Console.WriteLine("Enter ProductId : ");
            //            var User_CurrProductId = Console.ReadLine();

            //            if (productDB[User_CurrLocationId].ContainsKey(User_CurrProductId))
            //            {
            //                Console.WriteLine("Enter Quantity : ");
            //                int User_Quantity = Convert.ToInt32(Console.ReadLine());
            //                customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.RemoveItem(customerDB[User_CurrCustomerId].CustomerCart.Products, productDB[User_CurrLocationId][User_CurrProductId], User_Quantity);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Invalid Product Id");
            //                UserInput = "a";
            //            }
            //        }
            //        else if (UserInput == "v")
            //        {
            //            customerDB[User_CurrCustomerId].CustomerCart.InvetoryItems();
            //        }
            //        else if (UserInput == "i")
            //        {
            //            Console.WriteLine("store invetory...");
            //            //foreach (var cartitem in productDB[User_CurrLocationId])
            //            //{
            //            //    Console.WriteLine(cartitem.Value.ProductName);
            //            //}
            //            locationDB[User_CurrLocationId].GetInvetory();

            //        }
            //        else if (UserInput == "p")
            //        {
            //            //SaveProducts(Dictionary<string, Dictionary<string, Product>> productDb)
            //            var PlaceOrder = new CustomerOrder(User_CurrCustomerId, User_CurrLocationId, customerDB[User_CurrCustomerId].CustomerCart.Products, productDB);
            //            CustomerDataHandler.SaveProducts(PlaceOrder.UpdateLocationStock());

            //            //history log
            //            var OrderLog = new Order(User_CurrCustomerId, User_CurrLocationId, customerDB[User_CurrCustomerId].CustomerCart.Products);
            //            foreach (var order in OrderLog.OrderLog)
            //            {
            //                orderHistoryDB.Add(order.Key, order.Value);
            //            }
            //            CustomerDataHandler.SaveOrderLog(orderHistoryDB);

            //            Console.WriteLine("OrderPlaced");
            //            User_CurrCustomerId = "";
            //            User_CurrLocationId = "";
            //            UserInput = "MainMenu";
            //        }
            //        else if (UserInput == "xcx")
            //        {
            //            UserInput = "MainMenu";
            //            customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.RemoveAllItems(customerDB[User_CurrCustomerId].CustomerCart.Products);
            //            User_CurrLocationId = "";
            //            User_CurrCustomerId = "";
            //        }

            //        //return to order menu
            //        if (UserInput != "MainMenu")
            //        {
            //            UserInput = "o";
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Option");
            //        UserInput = Console.ReadLine();
            //    }
            //}
        }



    }
}

