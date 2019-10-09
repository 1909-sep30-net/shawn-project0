using System;
using System.Collections.Generic;
using BusinessLibrary;
using Data;


namespace Project0
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            
            //temp data
            var customerDB = CustomerDataHandler.GetCustomers();
            var productDB = CustomerDataHandler.GetMoreProducts();
            //var stufftoorder = new List<ICartItem>();

            //var ordersomething = new CustomerOrder("2131afca - 7588 - 479e-84f5 - d3a1ff255b40", "001", stufftoorder, productDB);

            //ordersomething.PlaceOrder();

            //begin temp UI
            var UserInput = "MainMenu";
            string User_CurrCustomerId = "";
            string User_CurrLocationId = "";

            while (true)
            {
                if (UserInput == "MainMenu")
                {
                    Console.WriteLine("Enter a command : ");
                    Console.WriteLine("O => Start new order");
                    Console.WriteLine("A => Add new customer");
                    Console.WriteLine("C => View customer history");
                    Console.WriteLine("S => View store history");

                    UserInput = Console.ReadLine().ToLower();

                }
                else if (UserInput == "a") 
                {
                    Console.WriteLine("Add new customer...");
                    Console.WriteLine("Enter first name of new customer :");
                    var User_NameFirst = Console.ReadLine();

                    Console.WriteLine("Enter last name of new customer :");
                    var User_NameLast = Console.ReadLine();

                    Customer NewCustomer = (Customer)Factory.CreateCustomer();
                    NewCustomer.NameFirst = User_NameFirst;
                    NewCustomer.NameLast = User_NameLast;

                    customerDB.Add(NewCustomer.CustomerId, NewCustomer);

                    CustomerDataHandler.SaveCustomers(customerDB);
                    Console.WriteLine($"Customer has been created with id of : {NewCustomer.CustomerId}");
                    UserInput = "MainMenu";
                }
                else if (UserInput == "c")
                {
                    Console.WriteLine("customer history...");
                }
                else if (UserInput == "s")
                {
                    Console.WriteLine("store history...");
                }
                else if (UserInput == "o")
                {
                    if (User_CurrCustomerId == "")
                    {
                        Console.WriteLine("Enter CustomerId : ");
                        User_CurrCustomerId = Console.ReadLine();
                                                
                    }

                    if (!ValidationHandler.CheckCustomerId(User_CurrCustomerId, customerDB))//!customerDB.ContainsKey(User_CurrCustomerId))
                    {
                        User_CurrCustomerId = "";
                        UserInput = "o";
                        Console.WriteLine("Invalid Customer Id.");
                    }
                    else
                    {
                        if (User_CurrLocationId == "")
                        {
                            Console.WriteLine("Enter LocationId : ");
                            User_CurrLocationId = Console.ReadLine();
                        }

                        if (ValidationHandler.CheckLocationId(User_CurrLocationId, productDB))
                        {

                            Console.WriteLine("A => Add product");
                            Console.WriteLine("R => Remove product");
                            Console.WriteLine("V => View current order");
                            Console.WriteLine("P => Place order");
                            Console.WriteLine("XCX => Cancel order");
                            UserInput = Console.ReadLine().ToLower();
                        } else
                        {
                            Console.WriteLine("Invalid Location Id");
                            User_CurrLocationId = "";
                            UserInput = "o";
                        }
                    }

                    if (UserInput == "a")
                    {

                        Console.WriteLine("Enter ProductId : ");
                        var User_CurrProductId = Console.ReadLine();

                        if (ValidationHandler.CheckProductId(User_CurrProductId, productDB[User_CurrLocationId]))
                        {
                            Console.WriteLine("Enter Quantity : ");
                            int User_Quantity = Convert.ToInt32(Console.ReadLine());
                            customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.AddItem(customerDB[User_CurrCustomerId].CustomerCart.Products, productDB[User_CurrLocationId][User_CurrProductId], User_Quantity);
                        } 
                        else
                        {
                            Console.WriteLine("Invalid Product Id");
                            UserInput = "a";
                        } 
                    }
                    else if (UserInput == "r")
                    {
                        Console.WriteLine("Enter ProductId : ");
                        var User_CurrProductId = Console.ReadLine();

                        if (productDB[User_CurrLocationId].ContainsKey(User_CurrProductId))
                        {
                            Console.WriteLine("Enter Quantity : ");
                            int User_Quantity = Convert.ToInt32(Console.ReadLine());
                            customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.RemoveItem(customerDB[User_CurrCustomerId].CustomerCart.Products, productDB[User_CurrLocationId][User_CurrProductId], User_Quantity);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Product Id");
                            UserInput = "a";
                        }
                    }
                    else if (UserInput == "v")
                    {
                        customerDB[User_CurrCustomerId].CustomerCart.InvetoryItems();
                    }
                    else if (UserInput == "p")
                    {
                        //SaveProducts(Dictionary<string, Dictionary<string, Product>> productDb)
                        var PlaceOrder = new CustomerOrder(User_CurrCustomerId, User_CurrLocationId, customerDB[User_CurrCustomerId].CustomerCart.Products, productDB);
                        CustomerDataHandler.SaveProducts(PlaceOrder.UpdateLocationStock());

                        //put history loggers here



                        Console.WriteLine("OrderPlaced");
                        User_CurrCustomerId = "";
                        User_CurrLocationId = "";
                        UserInput = "MainMenu";
                    }
                    else if (UserInput == "xcx")
                    {
                        UserInput = "MainMenu";
                        customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.RemoveAllItems(customerDB[User_CurrCustomerId].CustomerCart.Products);
                        
                    }

                    //return to order menu
                    if (UserInput != "MainMenu")
                    {
                        UserInput = "o";
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Option");
                    UserInput = Console.ReadLine();
                }
            }
        }



    }
}

