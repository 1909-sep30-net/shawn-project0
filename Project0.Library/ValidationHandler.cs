using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public static class ValidationHandler
    {

        public static bool CheckLocationId(string userInput, Dictionary<string, Dictionary<string, Product>> LocationDb)
        {
            if(LocationDb.ContainsKey(userInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckProductId(string userInput, Dictionary<string, Product> ProductDb)
        {
            if (ProductDb.ContainsKey(userInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckCustomerId(string userInput, Dictionary<string, Customer> CustomerDb)
        {
            if (CustomerDb.ContainsKey(userInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
