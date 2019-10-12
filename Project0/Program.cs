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
        [STAThread]
        static void Main(string[] args)
        {

            Console.WriteLine(FiggleFonts.SubZero.Render("Project O"));
            Console.WriteLine(FiggleFonts.FireFontK.Render("The Banana Store Kiosk"));
            Console.WriteLine("The Banana Store Kiosk");

            // Ui init
            var UserInput = "MainMenu";
            string User_CurrCustomerId = "";
            string User_CurrLocationId = "";
            string User_FirstName = "";
            string User_LastName = "";

            while (true)
            {
                if (UserInput == "MainMenu")
                {
                    Console.WriteLine("\t----- Main Menu -----");
                    Console.WriteLine("\tEnter a command : ");
                    Console.WriteLine("\tA => Add new customer");
                    Console.WriteLine("\tN => Search for customer by name");
                    Console.WriteLine("\tC => View customer history");
                    Console.WriteLine("\tS => View store history");
                    Console.WriteLine("\tO => Start new order");

                    UserInput = Console.ReadLine().ToLower();
                }
                else if (UserInput == "a")
                {
                    Console.WriteLine("Adding a new customer...");
                    Console.WriteLine("Enter first name of new customer :");
                    User_FirstName = Console.ReadLine();

                    Console.WriteLine("Enter last name of new customer :");
                    User_LastName = Console.ReadLine();

                    var NewCustomer = new DataConnection().CreateCustomer(User_FirstName, User_LastName);


                    if (NewCustomer.CustomerId != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Success!!");
                        Console.WriteLine("New Customer Report:");
                        Console.WriteLine($"Name: {NewCustomer.FirstName} {NewCustomer.LastName}");
                        Console.WriteLine($"Customer Id: {NewCustomer.CustomerId}");
                    }
                    else
                    {
                        Console.WriteLine("Please try again and if the problem persists, contact a supervisor.");
                    }

                    // Ui Init
                    UserInput = "MainMenu";
                    User_CurrCustomerId = "";
                    User_CurrLocationId = "";
                    User_FirstName = "";
                    User_LastName = "";
                }
                else if (UserInput == "n")
                {
                    Console.WriteLine("Search for a customer...");
                    Console.WriteLine("Enter first name of customer :");
                    User_FirstName = Console.ReadLine();

                    Console.WriteLine("Enter last name of customer :");
                    User_LastName = Console.ReadLine();

                    var SearchResults = new DataConnection().GetASingleCustomer(User_FirstName, User_LastName);

                    if (SearchResults.CustomerId != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Success!!");
                        Console.WriteLine("New Customer Report:");
                        Console.WriteLine($"Name: {SearchResults.FirstName} {SearchResults.LastName}");
                        Console.WriteLine($"Customer Id: {SearchResults.CustomerId}");
                        Console.WriteLine("----------");
                        Console.WriteLine("X => Copy Customer Id to clipboard and return to main menu");
                        Console.WriteLine("M => Return to mainmenu");
                        UserInput = Console.ReadLine().ToLower();
                        if (UserInput == "x")
                        {
                                TextCopy.Clipboard.SetText(SearchResults.CustomerId.ToString());
                        }

                        // Ui Init
                        UserInput = "MainMenu";
                        User_CurrCustomerId = "";
                        User_CurrLocationId = "";
                        User_FirstName = "";
                        User_LastName = "";


                    }
                    else
                    {
                        Console.WriteLine("Please try again and if the problem persists, contact a supervisor.");
                    }

                }
                else if (UserInput == "c")
                {
                    Console.WriteLine("Customer history...");


                    if (User_CurrCustomerId == "")
                    {
                        Console.WriteLine("Enter CustomerId : ");
                        User_CurrCustomerId = Console.ReadLine();
                    }

                    if (!DataConnection.ValidateCustomerId(User_CurrCustomerId))
                    {
                        User_CurrCustomerId = "";
                        UserInput = "c";
                        Console.WriteLine("Invalid Customer Id.");
                    }
                    else
                    {
                        Console.WriteLine("Getting history...");
                        Console.Clear();
                        var CompleteHistory = new DataConnection().GetOrderHistory(User_CurrCustomerId);
                        var TargetedHistory = CompleteHistory.GroupBy(o => o.OrderId).Select(o => o.First());

                        Console.WriteLine("History of all orders");
                        Console.WriteLine($"{TargetedHistory.First().FirstName} {TargetedHistory.First().LastName}");
                        foreach (var order in TargetedHistory)
                        {
                                Console.WriteLine("========================");
                                Console.WriteLine($"   Order Id : {order.OrderId}");
                                Console.WriteLine($" Order Date : {order.OrderDate}");
                                Console.WriteLine("========================");
                        }


                        User_CurrCustomerId = "";
                        UserInput = "MainMenu";
                    }

                }
                //else if (UserInput == "s")
                //{
                //    Console.WriteLine("store history...");
                //    Console.WriteLine("Enter LocationId : ");

                //    User_CurrLocationId = Console.ReadLine();
                //    if (!ValidationHandler.CheckLocationId(User_CurrLocationId, productDB))
                //    {
                //        Console.WriteLine("Invalid Location Id");
                //        User_CurrLocationId = "";
                //        UserInput = "s";
                //    }
                //    else
                //    {

                //        var HistoryHandler = Factory.CreateHistoryHandler();
                //        HistoryHandler.Database = orderHistoryDB;
                //        HistoryHandler.TargetId = User_CurrLocationId;
                //        HistoryHandler.RetrievalType = "StoreId";
                //        Console.Clear();
                //        HistoryHandler.GetHistory();

                //        User_CurrLocationId = "";
                //        UserInput = "MainMenu";
                //    }

                //}
                //else if (UserInput == "o")
                //{
                //    if (User_CurrCustomerId == "")
                //    {
                //        Console.WriteLine("Enter CustomerId : ");
                //        User_CurrCustomerId = Console.ReadLine();

                //    }

                //    if (!ValidationHandler.CheckCustomerId(User_CurrCustomerId, customerDB))
                //    {
                //        User_CurrCustomerId = "";
                //        UserInput = "o";
                //        Console.WriteLine("Invalid Customer Id.");
                //    }
                //    else
                //    {
                //        if (User_CurrLocationId == "")
                //        {
                //            Console.WriteLine("Enter LocationId : ");
                //            User_CurrLocationId = Console.ReadLine();
                //        }

                //        if (ValidationHandler.CheckLocationId(User_CurrLocationId, productDB))
                //        {

                //            Console.WriteLine("A => Add product");
                //            Console.WriteLine("R => Remove product");
                //            Console.WriteLine("V => View current order");
                //            Console.WriteLine("I => View store invetory");
                //            Console.WriteLine("P => Place order");
                //            Console.WriteLine("XCX => Cancel order");
                //            UserInput = Console.ReadLine().ToLower();
                //        }
                //        else
                //        {
                //            Console.WriteLine("Invalid Location Id");
                //            User_CurrLocationId = "";
                //            UserInput = "o";
                //        }
                //    }

                //    if (UserInput == "a")
                //    {

                //        Console.WriteLine("Enter ProductId : ");
                //        var User_CurrProductId = Console.ReadLine();

                //        if (ValidationHandler.CheckProductId(User_CurrProductId, productDB[User_CurrLocationId]))
                //        {
                //            Console.WriteLine("Enter Quantity : ");
                //            int User_Quantity = Convert.ToInt32(Console.ReadLine());
                //            customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.AddItem(customerDB[User_CurrCustomerId].CustomerCart.Products, productDB[User_CurrLocationId][User_CurrProductId], User_Quantity);
                //        }
                //        else
                //        {
                //            Console.WriteLine("Invalid Product Id");
                //            UserInput = "a";
                //        }
                //    }
                //    else if (UserInput == "r")
                //    {
                //        Console.WriteLine("Enter ProductId : ");
                //        var User_CurrProductId = Console.ReadLine();

                //        if (productDB[User_CurrLocationId].ContainsKey(User_CurrProductId))
                //        {
                //            Console.WriteLine("Enter Quantity : ");
                //            int User_Quantity = Convert.ToInt32(Console.ReadLine());
                //            customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.RemoveItem(customerDB[User_CurrCustomerId].CustomerCart.Products, productDB[User_CurrLocationId][User_CurrProductId], User_Quantity);
                //        }
                //        else
                //        {
                //            Console.WriteLine("Invalid Product Id");
                //            UserInput = "a";
                //        }
                //    }
                //    else if (UserInput == "v")
                //    {
                //        customerDB[User_CurrCustomerId].CustomerCart.InvetoryItems();
                //    }
                //    else if (UserInput == "i")
                //    {
                //        Console.WriteLine("store invetory...");
                //        //foreach (var cartitem in productDB[User_CurrLocationId])
                //        //{
                //        //    Console.WriteLine(cartitem.Value.ProductName);
                //        //}
                //        locationDB[User_CurrLocationId].GetInvetory();

                //    }
                //    else if (UserInput == "p")
                //    {
                //        //SaveProducts(Dictionary<string, Dictionary<string, Product>> productDb)
                //        var PlaceOrder = new CustomerOrder(User_CurrCustomerId, User_CurrLocationId, customerDB[User_CurrCustomerId].CustomerCart.Products, productDB);
                //        CustomerDataHandler.SaveProducts(PlaceOrder.UpdateLocationStock());

                //        //history log
                //        var OrderLog = new Order(User_CurrCustomerId, User_CurrLocationId, customerDB[User_CurrCustomerId].CustomerCart.Products);
                //        foreach (var order in OrderLog.OrderLog)
                //        {
                //            orderHistoryDB.Add(order.Key, order.Value);
                //        }
                //        CustomerDataHandler.SaveOrderLog(orderHistoryDB);

                //        Console.WriteLine("OrderPlaced");
                //        User_CurrCustomerId = "";
                //        User_CurrLocationId = "";
                //        UserInput = "MainMenu";
                //    }
                //    else if (UserInput == "xcx")
                //    {
                //        UserInput = "MainMenu";
                //        customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.RemoveAllItems(customerDB[User_CurrCustomerId].CustomerCart.Products);
                //        User_CurrLocationId = "";
                //        User_CurrCustomerId = "";
                //    }

                //    //return to order menu
                //    if (UserInput != "MainMenu")
                //    {
                //        UserInput = "o";
                //    }

            
                else
                {
                    Console.WriteLine("Invalid option selected, please try again:");
                    UserInput = Console.ReadLine();
                }
            }
        }
    }
}