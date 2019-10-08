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
            var jsonFilePathCustomers = @"C:\revature\shawn-project0\Data\customersData.json";

            try
            {
                var CustomersDictionary = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(File.ReadAllText(jsonFilePathCustomers));
                //Console.WriteLine(CustomersDictionary["2131afca-7588-479e-84f5-d3a1ff255b40"]);
                return CustomersDictionary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong : " + ex.Message.ToString());
            }
            return null;

        }
    }



}
