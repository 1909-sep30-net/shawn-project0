using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Project0.Library;
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
            var jsonFilePath = @"C:\revature\shawn-project0\Data\customersData.json";

            try
            {
                var CustomersDictionary = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(File.ReadAllText(jsonFilePath));
                return CustomersDictionary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with cust data: " + ex.Message.ToString());
            }
            return null;
            
        }

        public static void SaveCustomers(Dictionary<string, Customer> customerDB)
        {
            //Temporary customer data
            var jsonFilePath = @"C:\revature\shawn-project0\Data\customersData.json";
            string jsonCustomerDb = JsonConvert.SerializeObject(customerDB, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
            
            try
            {
                File.WriteAllText(jsonFilePath, jsonCustomerDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with saving cust data: " + ex.Message.ToString());
            }
        }



        public static Dictionary<string, Dictionary<string, Product>> GetMoreProducts()
        {
            //Temporary product data
            var jsonFilePath = @"C:\revature\shawn-project0\Data\productDataLocation.json";

            try
            {
                var ProductsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Product>>>(File.ReadAllText(jsonFilePath));
                return ProductsDictionary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with product data: " + ex.Message.ToString());
            }
            return null;

        }

        public static void SaveProducts(Dictionary<string, Dictionary<string, Product>> productDb)
        {
            //Temporary customer data
            var jsonFilePath = @"C:\revature\shawn-project0\Data\productDataLocation.json";
            string jsonProductDb = JsonConvert.SerializeObject(productDb, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            try
            {
                File.WriteAllText(jsonFilePath, jsonProductDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with saving product stock data: " + ex.Message.ToString());
            }
        }

        public static void SaveOrderLog(Dictionary<string, Dictionary<string, string>> orderhistory)
        {
            //Temporary customer data
            var jsonFilePath = @"C:\revature\shawn-project0\Data\orderLogIds.json";
            string jsonHistoryDb = JsonConvert.SerializeObject(orderhistory, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            try
            {
                File.WriteAllText(jsonFilePath, jsonHistoryDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with saving order log history data: " + ex.Message.ToString());
            }
        }

        public static Dictionary<string, Dictionary<string, string>> GetOrderLog()
        {
            //Temporary customer data
            var jsonFilePath = @"C:\revature\shawn-project0\Data\orderLogIds.json";
            
            try
            {
                var OrderHistoryLog = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(jsonFilePath));
                return OrderHistoryLog;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with retrieving Order History data: " + ex.Message.ToString());
            }
            return null;

        }

    }



}
