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

            Console.WriteLine(FiggleFonts.SubZero.Render("Project Zero"));
            Console.WriteLine(FiggleFonts.FireFontK.Render("The Banana Store Kiosk"));
            Console.WriteLine("\tThe Banana Store Kiosk");

            // Ui init
            var UserInput = "MainMenu";
            string User_CurrCustomerId = "";
            string User_CurrLocationId = "";
            string User_FirstName = "";
            string User_LastName = "";
            Cart CurrentCart = new Cart();

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


                    if (!(string.IsNullOrEmpty(NewCustomer.FirstName) && string.IsNullOrEmpty(NewCustomer.LastName)))
                    {
                        Console.Clear();
                        Console.WriteLine("\tSuccess!!");
                        Console.WriteLine("\tNew Customer Report:");
                        Console.WriteLine($"\tName: {NewCustomer.FirstName} {NewCustomer.LastName}");
                        Console.WriteLine($"\tCustomer Id: {NewCustomer.CustomerId}");
                    }
                    else
                    {
                        Console.WriteLine("Creation Error! Please try again and if the problem persists, contact a supervisor.");
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

                    if (!(string.IsNullOrEmpty(SearchResults.FirstName) && string.IsNullOrEmpty(SearchResults.LastName)))
                    {
                        Console.Clear();
                        Console.WriteLine("\tSuccess!!");
                        Console.WriteLine("\tNew Customer Report:");
                        Console.WriteLine($"\tName: {SearchResults.FirstName} {SearchResults.LastName}");
                        Console.WriteLine($"\tCustomer Id: {SearchResults.CustomerId}");
                        Console.WriteLine("\t----------");
                        Console.WriteLine("X => Copy Customer Id to clipboard and return to main menu");
                        Console.WriteLine("Any other key => Return to mainmenu with out copy");
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
                        Console.WriteLine("Customer does not exist in the database. Please try again and if the problem persists, contact a supervisor.");
                        UserInput = "n";
                        User_FirstName = "";
                        User_LastName = "";
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
                else if (UserInput == "s")
                {
                    Console.WriteLine("Store history...");
                    Console.WriteLine("Enter LocationId : ");

                    User_CurrLocationId = Console.ReadLine();
                    if (!DataConnection.ValidateLocationId(User_CurrLocationId))
                    {
                        Console.WriteLine("Invalid Location Id, Please try again, if the promblem persists talk with a supervisor.");
                        User_CurrLocationId = "";
                        UserInput = "s";
                    }
                    else
                    {

                        Console.WriteLine("Getting history...");
                        Console.Clear();
                        var CompleteHistory = new DataConnection().GetOrderHistory(int.Parse(User_CurrLocationId));
                        var TargetedHistory = CompleteHistory.GroupBy(o => o.OrderId).Select(o => o.First());

                        Console.WriteLine("History of all orders");
                        Console.WriteLine($"{TargetedHistory.First().LocationName}");
                        Console.WriteLine($"Location Id : {TargetedHistory.First().LocationId}");
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
                else if (UserInput == "o")
                {

                    while (!DataConnection.ValidateCustomerId(User_CurrCustomerId))
                    {
                        Console.WriteLine("Enter a valid CustomerId : ");
                        User_CurrCustomerId = Console.ReadLine();
                    };

                    while (!DataConnection.ValidateLocationId(User_CurrLocationId))
                    {
                        Console.WriteLine("Enter a valid LocationId : ");
                        User_CurrLocationId = Console.ReadLine();
                    };


                    var User_CurrProductId = "";
                    var User_ProductQuantity = "";
                    int intUser_ProductQuantity;


                    Console.WriteLine("\t----- Order Menu -----");
                    Console.WriteLine("\tA => Add product");
                    Console.WriteLine("\tR => Remove product");
                    Console.WriteLine("\tV => View current order");
                    Console.WriteLine("\tI => View store invetory");
                    Console.WriteLine("\tP => Place order");
                    Console.WriteLine("\tXCX => Cancel order");
                    UserInput = Console.ReadLine().ToLower();

                    if (UserInput == "i")
                    {

                        var LocationInvetory = new DataConnection().GetLocationStock(int.Parse(User_CurrLocationId));
                        Console.WriteLine(LocationInvetory);

                        Console.WriteLine("Location Stock");
                        Console.WriteLine($"{LocationInvetory.First().LocationName}");
                        Console.WriteLine($"Location Id : {LocationInvetory.First().LocationId}");
                        foreach (var order in LocationInvetory)
                        {
                            Console.WriteLine("========================");
                            Console.WriteLine($"  Product : {order.ProductId}");
                            Console.WriteLine($"     Desc : {order.ProductDesc}");
                            Console.WriteLine($" Quantity : {order.Quantity}");
                            Console.WriteLine("========================");
                        }
                        UserInput = "o";


                    }
                    else if (UserInput == "a")
                    {

                        do
                        {
                            Console.WriteLine("Please enter a valid ProductId : ");
                            User_CurrProductId = Console.ReadLine();
                        } while (!DataConnection.ValidateProductId(User_CurrProductId));

                        do
                        {
                            Console.WriteLine("Please enter a valid quantity : ");
                            User_ProductQuantity = Console.ReadLine();
                        } while (!int.TryParse(User_ProductQuantity, out intUser_ProductQuantity));

                        if (DataConnection.ValidateStock(int.Parse(User_CurrLocationId), User_CurrProductId, intUser_ProductQuantity, CurrentCart.InvetoryItems(Guid.Parse(User_CurrProductId))).Count() > 0)
                        {

                            CurrentCart.Add(new OrderItems()
                            {
                                OrderId = CurrentCart.OrderId,
                                ProductId = Guid.Parse(User_CurrProductId),
                                Quantity = intUser_ProductQuantity
                            });
                            Console.WriteLine("Added to Cart...");
                            UserInput = "o";

                            User_CurrProductId = "";
                            User_ProductQuantity = "";
                            intUser_ProductQuantity = 0;
                        }
                        else
                        {
                            Console.WriteLine($"The location you have selected does not have {User_ProductQuantity} of that item.");
                            Console.WriteLine("Try a different location or reselect the product and choose less.");
                            UserInput = "o";
                        }

                    }

                    else if (UserInput == "r")
                    {
                        while (!DataConnection.ValidateProductId(User_CurrProductId))
                        {
                            Console.WriteLine("Enter ProductId : ");
                            User_CurrProductId = Console.ReadLine();
                        }

                        CurrentCart.Remove(Guid.Parse(User_CurrProductId));


                    }
                    else if (UserInput == "v")
                    {
                        var ItemsInCart = CurrentCart.InvetoryItems();
                        Console.WriteLine("Current Order Information");
                        Console.WriteLine($"Customer Id : {User_CurrCustomerId}");
                        Console.WriteLine($"Location Id : {User_CurrLocationId}");
                        foreach (var order in ItemsInCart)
                        {
                            Console.WriteLine("========================");
                            Console.WriteLine($"  Product : {order.ProductId}");
                            Console.WriteLine($" Quantity : {order.Quantity}");
                            Console.WriteLine("========================");
                        }
                        UserInput = "o";


                    }
                    else if (UserInput == "p")
                    {
                        
                        //var OrderCart = new DataConnection()

                        Console.WriteLine("OrderPlaced");
                        User_CurrCustomerId = "";
                        User_CurrLocationId = "";
                        UserInput = "MainMenu";
                        CurrentCart = new Cart();
                    }
                    else if (UserInput == "xcx")
                    {
                        UserInput = "MainMenu";
                        CurrentCart = new Cart();
                        User_CurrLocationId = "";
                        User_CurrCustomerId = "";
                        User_CurrProductId = "";

                    }

                    

                    //return to order menu
                    if (UserInput != "MainMenu")
                    {
                        UserInput = "o";

                    }
                }
                else
                {
                    Console.WriteLine("Invalid option selected, please try again:");
                    UserInput = Console.ReadLine();
                }
            }
        }
    }
}