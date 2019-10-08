using System;
using BusinessLibrary;
using Data;

namespace Project0
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            
            //temp data
            var productDB = CustomerDataHandler.GetProducts();
            var customerDB = CustomerDataHandler.GetCustomers();

            //begin temp UI
            var UserInput = "MainMenu";
            string User_CurrCustomerId = "";

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

                    if (!customerDB.ContainsKey(User_CurrCustomerId))
                    {
                        User_CurrCustomerId = "";
                        UserInput = "o";
                        Console.WriteLine("Invalid Customer Id.");
                    }
                    else
                    {

                        Console.WriteLine("A => Add product");
                        Console.WriteLine("R => Remove product");
                        Console.WriteLine("V => View current order");
                        Console.WriteLine("P => Place order");
                        Console.WriteLine("XCX => Cancel order");

                        UserInput = Console.ReadLine().ToLower();
                    }

                    if (UserInput == "a")
                    {
                        Console.WriteLine("Enter ProductId : ");
                        var User_CurrProductId = Console.ReadLine();

                        if (productDB.ContainsKey(User_CurrProductId))
                        {
                            Console.WriteLine("Enter Quantity : ");
                            int User_Quantity = Convert.ToInt32(Console.ReadLine());
                            customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.AddItem(customerDB[User_CurrCustomerId].CustomerCart.Products, productDB[User_CurrProductId], User_Quantity);
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

                        if (productDB.ContainsKey(User_CurrProductId))
                        {
                            Console.WriteLine("Enter Quantity : ");
                            int User_Quantity = Convert.ToInt32(Console.ReadLine());
                            customerDB[User_CurrCustomerId].CustomerCart.UpdateCart.RemoveItem(customerDB[User_CurrCustomerId].CustomerCart.Products, productDB[User_CurrProductId], User_Quantity);
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
                        Console.WriteLine("OrderPlaced");
                        User_CurrCustomerId = "";
                        UserInput = "MainMenu";
                    }
                    else if (UserInput == "xcx")
                    {
                        UserInput = "MainMenu";
                        customerDB[User_CurrCustomerId].CustomerCart.Products.Clear();
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

