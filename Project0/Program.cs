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
            var CurrCustomer = "2131afca-7588-479e-84f5-d3a1ff255b40";
            var bike = "cd9eefc1-70d1-40e7-9de3-d3b4462f3961";
            var bread = "d7a54dbe-5795-4a74-94c2-89e5e1e9e8df";

            customerDB[CurrCustomer].CustomerCart.AddItem(productDB[bread], 8);
            customerDB["2131afca-7588-479e-84f5-d3a1ff255b40"].CustomerCart.InvetoryItems();

            customerDB[CurrCustomer].CustomerCart.RemoveItem(productDB[bread], 20);
            customerDB["2131afca-7588-479e-84f5-d3a1ff255b40"].CustomerCart.InvetoryItems();

            customerDB[CurrCustomer].CustomerCart.AddItem(productDB[bike], 8);
            customerDB["2131afca-7588-479e-84f5-d3a1ff255b40"].CustomerCart.InvetoryItems();

            customerDB[CurrCustomer].CustomerCart.RemoveItem(productDB[bike], 5);
            customerDB["2131afca-7588-479e-84f5-d3a1ff255b40"].CustomerCart.InvetoryItems();

            customerDB[CurrCustomer].CustomerCart.AddItem(productDB[bike], 17);

            customerDB["2131afca-7588-479e-84f5-d3a1ff255b40"].CustomerCart.InvetoryItems();

        }

    }
}

