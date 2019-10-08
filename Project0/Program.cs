using System;
using BusinessLibrary;
using Data;

namespace Project0
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            //var larry = new Customer("Larry", "Smith");
            //var walt = new Customer("Walt", "White");

            IProduct bike = Factory.CreateProduct();
            bike.ProductName = "Huffy Bike";
            bike.ProductDesc = "26 inch wheels";
            bike.StockQuantity = 17;

            IProduct bread = Factory.CreateProduct();
            bread.ProductName = "Moms Bannana Bread";
            bread.ProductDesc = "Old Bananas, Fresh Bread";
            bread.StockQuantity = 25;
            


            //Console.WriteLine(selectBread.Product.ProductName);

            //ICustomer bugs = Factory.CreateCustomer();
            //bugs.NameFirst = "Bugs";
            //bugs.NameLast = "Bunny";

            //Console.WriteLine($"Customer is {bugs.NameFirst} {bugs.NameLast} and his customer id is {bugs.CustomerId}.");

            //bugs.CustomerCart.AddItem(bike);
            //bugs.CustomerCart.AddItem(bread);

            //bugs.CustomerCart.InvetoryItems();

            //bugs.CustomerCart.RemoveItem(bread);
            //bugs.CustomerCart.InvetoryItems();

            var customerDB = CustomerDataHandler.GetCustomers();
            string CurrCustomer = "2131afca-7588-479e-84f5-d3a1ff255b40";
            Console.WriteLine($"Customer is {customerDB[CurrCustomer].NameFirst} {customerDB[CurrCustomer].CustomerId}.");
            customerDB[CurrCustomer].CustomerCart.AddItem(bread, 5);
            customerDB["2131afca-7588-479e-84f5-d3a1ff255b40"].CustomerCart.InvetoryItems();

            customerDB[CurrCustomer].CustomerCart.AddItem(bread, 5);
            customerDB["2131afca-7588-479e-84f5-d3a1ff255b40"].CustomerCart.InvetoryItems();



        }

    }
}

