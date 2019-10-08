using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BusinessLibrary;
using Newtonsoft.Json;

namespace Data
{
    
    // Temporary Data File
    // Data is user generated 
    // Or stored in a data base

    public class CustomerDataHandler
    {
        

        public static Dictionary<string, Customer> GetCustomers()
        {
            //Temporary customer data
            var jsonFilePathCustomers = @"C:\revature\shawn-project0\Data\customersData.json";

            try
            {
                var CustomersDictionary = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(File.ReadAllText(jsonFilePathCustomers));
                return CustomersDictionary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with cust data: " + ex.Message.ToString());
            }
            return null;
            
        }

        public static Dictionary<string, Product> GetProducts()
        {
            //Temporary product data
            var jsonFilePathProducts = @"C:\revature\shawn-project0\Data\productsData.json";

            try
            {
                var ProductsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Product>>(File.ReadAllText(jsonFilePathProducts));
                return ProductsDictionary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with product data: " + ex.Message.ToString());
            }
            return null;

        }
    }



}
