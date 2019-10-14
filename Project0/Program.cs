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
            Console.WriteLine(FiggleFonts.SubZero.Render("Project Zero"));
            Console.WriteLine("----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- -----");
            Console.WriteLine("\t");
            Console.WriteLine(FiggleFonts.Short.Render("     Banana Store Kiosk"));
            Console.WriteLine("\t");
            Console.WriteLine("\tBanana Store Kiosk");

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
                    Console.Write("\t");
                    UserInput = Console.ReadLine().ToLower();
                }
                else if (UserInput == "a")
                {
                    Console.WriteLine("\tAdding a new customer...");
                    Console.Write("\tEnter first name of new customer :");
                    User_FirstName = Console.ReadLine();

                    Console.Write("\tEnter last name of new customer :");
                    User_LastName = Console.ReadLine();

                    var NewCustomer = new DataConnection().CreateCustomer(User_FirstName, User_LastName);


                    if (!(string.IsNullOrEmpty(NewCustomer.FirstName) && string.IsNullOrEmpty(NewCustomer.LastName)))
                    {
                        Console.Clear();
                        Console.WriteLine("\t----- New Customer Report -----");
                        Console.WriteLine($"\tName: {NewCustomer.FirstName} {NewCustomer.LastName}");
                        Console.WriteLine($"\tCustomer Id: {NewCustomer.CustomerId}");
                        Console.WriteLine("\t----------");
                    }
                    else
                    {
                        Console.WriteLine("\tCreation Error! Please try again and if the problem persists, contact a supervisor.");
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
                    Console.WriteLine("\t---- Search for a customer -----");
                    Console.Write("\tEnter first name of customer :");
                    User_FirstName = Console.ReadLine();

                    Console.Write("\tEnter last name of customer :");
                    User_LastName = Console.ReadLine();

                    var SearchResults = new DataConnection().GetASingleCustomer(User_FirstName, User_LastName);

                    if (!(string.IsNullOrEmpty(SearchResults.FirstName) && string.IsNullOrEmpty(SearchResults.LastName)))
                    {
                        Console.Clear();
                        Console.WriteLine("\t----- Found Customer Report -----");
                        Console.WriteLine($"\tName: {SearchResults.FirstName} {SearchResults.LastName}");
                        Console.WriteLine($"\tCustomer Id: {SearchResults.CustomerId}");
                        Console.WriteLine("\t----------");
                        Console.WriteLine("\tX => Copy Customer Id to clipboard and return to main menu");
                        Console.WriteLine("\tAny other key => Return to mainmenu with out copy");
                        Console.Write("\t");
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
                        Console.WriteLine("\tCustomer does not exist in the database. Please try again and if the problem persists, contact a supervisor.");
                        UserInput = "n";
                        User_FirstName = "";
                        User_LastName = "";
                    }

                }
                else if (UserInput == "c")
                {
                    Console.WriteLine("\t----- Customer history -----");


                    if (User_CurrCustomerId == "")
                    {
                        Console.Write("\tEnter CustomerId : ");
                        User_CurrCustomerId = Console.ReadLine();
                    }

                    if (!DataConnection.ValidateCustomerId(User_CurrCustomerId))
                    {
                        User_CurrCustomerId = "";
                        UserInput = "c";
                        Console.WriteLine("\tInvalid Customer Id.");
                    }
                    else
                    {
                        Console.WriteLine("\tGetting history...");
                        Console.Clear();
                        var CompleteHistory = new DataConnection().GetOrderHistory(User_CurrCustomerId);
                        var TargetedHistory = CompleteHistory.GroupBy(o => o.OrderId).Select(o => o.First());

                        Console.WriteLine("\t----- Customer Order History -----");
                        try
                        {
                            //Console.WriteLine($"\t{TargetedHistory.First().FirstName} {TargetedHistory.First().LastName}");
                            foreach (var order in TargetedHistory)
                            {
                                Console.WriteLine("\t========================");
                                Console.WriteLine($"\t   Order Id : {order.OrderId}");
                                Console.WriteLine($"\t Order Date : {order.OrderDate}");
                                Console.WriteLine("\t========================");
                            }

                            Console.WriteLine("\t----- Order History Menu -----");
                            Console.WriteLine("\tD => See order details");
                            Console.WriteLine("\tM => Return to main menu");
                            Console.Write("\t ");
                            UserInput = Console.ReadLine().ToLower();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine("\tThere are no orders for this customer yet.");
                            Console.WriteLine("\t----------");
                            UserInput = "m";
                        }
                        if (UserInput == "m")
                        {

                            User_CurrCustomerId = "";
                            UserInput = "MainMenu";

                        }
                        else
                        {
                            var User_OrderId = "";

                            while (!DataConnection.ValidateOrderId(User_OrderId))
                            {
                                Console.WriteLine("\tPlease enter a valid order id : ");
                                Console.Write("\t ");
                                User_OrderId = Console.ReadLine().ToLower();
                            }

                            var OrderDetails = new DataConnection().GetSingleOrder(User_OrderId);
                            Console.WriteLine("\t----- Individual Order Details -----");
                            Console.WriteLine($"\tCustomer Name : {OrderDetails.First().FirstName} {OrderDetails.First().LastName}");
                            Console.WriteLine($"\t  Customer Id : {OrderDetails.First().CustomerId}");
                            Console.WriteLine($"\tLocation Name :{OrderDetails.First().LocationName}");
                            Console.WriteLine($"\t   Location Id: {OrderDetails.First().LocationId}");
                            foreach (var item in OrderDetails)
                            {
                                Console.WriteLine("\t----------");
                                Console.WriteLine($"\tProduct name : {item.ProductName}");
                                Console.WriteLine($"\t Description : {item.ProductDesc}");
                                Console.WriteLine($"\t  Product Id : {item.ProductId}");
                                Console.WriteLine($"\t    Quantity : {item.Quantity}");
                                Console.WriteLine("\t----------");
                            }
                            Console.WriteLine($"\t----------");
                            User_CurrCustomerId = "";
                            User_CurrLocationId = "";
                            UserInput = "MainMenu";
                        }
                    }

                }
                else if (UserInput == "s")
                {
                    Console.WriteLine("\t----- Location Order History -----");
                    Console.Write("\tEnter LocationId : ");

                    User_CurrLocationId = Console.ReadLine();
                    if (!DataConnection.ValidateLocationId(User_CurrLocationId))
                    {
                        Console.WriteLine("\tInvalid Location Id, Please try again, if the promblem persists talk with a supervisor.");
                        User_CurrLocationId = "";
                        UserInput = "s";
                    }
                    else
                    {

                        Console.WriteLine("\tGetting location order history...");
                        Console.Clear();
                        var CompleteHistory = new DataConnection().GetOrderHistory((int?)int.Parse(User_CurrLocationId));
                        var TargetedHistory = CompleteHistory.GroupBy(o => o.OrderId).Select(o => o.First());

                        Console.WriteLine("\t----- History of all orders -----");
                        //Console.WriteLine($"\t   Location : {TargetedHistory.First().LocationName}");
                        Console.WriteLine($"\tLocation Id : {TargetedHistory.First().LocationId}");
                        foreach (var order in TargetedHistory)
                        {
                            Console.WriteLine("\t========================");
                            Console.WriteLine($"\t   Order Id : {order.OrderId}");
                            Console.WriteLine($"\t Order Date : {order.OrderDate}");
                            Console.WriteLine("\t========================");
                        }
                        User_CurrCustomerId = "";
                        User_CurrLocationId = "";
                        Console.WriteLine("\t----- Order History Menu -----");
                        Console.WriteLine("\tD => See order details");
                        Console.WriteLine("\tM => Return to main menu");
                        Console.Write("\t ");
                        UserInput = Console.ReadLine().ToLower();
                    }

                    if (UserInput == "m")
                    {
                        UserInput = "MainMenu";
                    }
                    else
                    {
                        var User_OrderId = "";

                        while (!DataConnection.ValidateOrderId(User_OrderId))
                        {
                            Console.WriteLine("\tPlease enter a valid order id : ");
                            Console.Write("\t ");
                            User_OrderId = Console.ReadLine().ToLower();
                        }

                        var OrderDetails = new DataConnection().GetSingleOrder(User_OrderId);
                        Console.WriteLine("\t----- Individual Order Details -----");
                        Console.WriteLine($"\tCustomer Name : {OrderDetails.First().FirstName} {OrderDetails.First().LastName}");
                        Console.WriteLine($"\t  Customer Id : {OrderDetails.First().CustomerId}");
                        Console.WriteLine($"\tLocation Name :{OrderDetails.First().LocationName}");
                        Console.WriteLine($"\t   Location Id: {OrderDetails.First().LocationId}");
                        foreach (var item in OrderDetails)
                        {
                            Console.WriteLine("\t----------");
                            Console.WriteLine($"\tProduct name : {item.ProductName}");
                            Console.WriteLine($"\t Description : {item.ProductDesc}");
                            Console.WriteLine($"\t  Product Id : {item.ProductId}");
                            Console.WriteLine($"\t    Quantity : {item.Quantity}");
                            Console.WriteLine("\t----------");
                        }
                        Console.WriteLine($"\t----------");
                        User_CurrCustomerId = "";
                        User_CurrLocationId = "";
                        UserInput = "MainMenu";

                    }
                }
                else if (UserInput == "o")
                {

                    while (!DataConnection.ValidateCustomerId(User_CurrCustomerId))
                    {
                        Console.Write("\tPlease enter a valid CustomerId : ");
                        User_CurrCustomerId = Console.ReadLine();
                    };
                    CurrentCart.CustomerId = Guid.Parse(User_CurrCustomerId);

                    while (!DataConnection.ValidateLocationId(User_CurrLocationId))
                    {
                        Console.Write("\tPlease enter a valid LocationId : ");
                        User_CurrLocationId = Console.ReadLine();
                    };
                    CurrentCart.LocationId = (int?)int.Parse(User_CurrLocationId);

                    var User_CurrProductId = "";
                    var User_ProductQuantity = "";
                    int intUser_ProductQuantity;


                    Console.WriteLine("\t----- Order Menu -----");
                    Console.WriteLine("\tA => Add product to cart");
                    Console.WriteLine("\tR => Remove product from cart");
                    Console.WriteLine("\tV => View current cart");
                    Console.WriteLine($"\tI => View current location invetory");
                    Console.WriteLine("\tP => Place everything in cart on order");
                    Console.WriteLine("\tXCX => Cancel entire order");
                    Console.Write("\t");
                    UserInput = Console.ReadLine().ToLower();

                    if (UserInput == "i")
                    {

                        var LocationInvetory = new DataConnection().GetLocationStock(int.Parse(User_CurrLocationId));

                        Console.WriteLine("\t----- Location Stock Report -----");
                        Console.WriteLine($"\tLocation Name : {LocationInvetory.First().LocationName}");
                        Console.WriteLine($"\t  Location Id : {LocationInvetory.First().LocationId}");
                        foreach (var order in LocationInvetory)
                        {
                            Console.WriteLine("\t========================");
                            Console.WriteLine($"\tProduct Id : {order.ProductId}");
                            Console.WriteLine($"\t   Product : {order.ProductName}");
                            Console.WriteLine($"\t      Desc : {order.ProductDesc}");
                            Console.WriteLine($"\t  Quantity : {order.Quantity}");
                            Console.WriteLine("\t========================");
                        }
                        UserInput = "o";


                    }
                    else if (UserInput == "a")
                    {

                        do
                        {
                            Console.Write("\tPlease enter a valid ProductId : ");
                            User_CurrProductId = Console.ReadLine();
                        } while (!DataConnection.ValidateProductId(User_CurrProductId));

                        do
                        {
                            Console.Write("\tPlease enter a valid quantity : ");
                            User_ProductQuantity = Console.ReadLine();
                        } while (!int.TryParse(User_ProductQuantity, out intUser_ProductQuantity));

                        if (DataConnection.ValidateStock(int.Parse(User_CurrLocationId), User_CurrProductId, intUser_ProductQuantity, CurrentCart.InvetoryItems(Guid.Parse(User_CurrProductId))))
                        {

                            CurrentCart.Add(new OrderItems()
                            {
                                OrderId = CurrentCart.OrderId,
                                ProductId = Guid.Parse(User_CurrProductId),
                                Quantity = intUser_ProductQuantity
                            });
                            Console.WriteLine("\tProduct added to cart...");
                            UserInput = "o";

                            User_CurrProductId = "";
                            User_ProductQuantity = "";
                            intUser_ProductQuantity = 0;
                        }
                        else
                        {
                            Console.WriteLine($"\tThe location you have selected does not have {User_ProductQuantity} of that item.");
                            Console.WriteLine("\tTry a different location or reselect the product and choose less.");
                            UserInput = "o";
                        }

                    }
                    else if (UserInput == "r")
                    {
                        while (!DataConnection.ValidateProductId(User_CurrProductId))
                        {
                            Console.Write("\tPlease enter a valid product Id : ");
                            User_CurrProductId = Console.ReadLine();
                        }

                        CurrentCart.Remove(Guid.Parse(User_CurrProductId));

                    }
                    else if (UserInput == "v")
                    {
                        var ItemsInCart = CurrentCart.InvetoryItems();
                        Console.WriteLine("\t----- Current Order Information -----");
                        Console.WriteLine($"\tCustomer Id : {User_CurrCustomerId}");
                        Console.WriteLine($"\tLocation Id : {User_CurrLocationId}");
                        foreach (var order in ItemsInCart)
                        {
                            Console.WriteLine("\t========================");
                            Console.WriteLine($"\t  Product : {order.ProductId}");
                            Console.WriteLine($"\t Quantity : {order.Quantity}");
                            Console.WriteLine("\t========================");
                        }
                        UserInput = "o";
                    }
                    else if (UserInput == "p")
                    {
                        //var OrderCart = new DataConnection()
                        if (CurrentCart.PlaceOrder())
                        {
                            Console.WriteLine("\tCustomer order has been placed.");
                            User_CurrCustomerId = "";
                            User_CurrLocationId = "";
                            UserInput = "MainMenu";
                            CurrentCart = new Cart();
                        }
                        else
                        {
                            Console.WriteLine("\tIf error persists please contact a supervisor.");
                            User_CurrCustomerId = "";
                            User_CurrLocationId = "";
                            UserInput = "MainMenu";
                            CurrentCart = new Cart();
                        }

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
                    Console.Write("Invalid option selected, please try again: ");
                    UserInput = Console.ReadLine();
                }
            }
        }
    }
}