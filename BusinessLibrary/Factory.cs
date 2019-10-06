using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Factory
    {
        public static ICustomer CreateCustomer()
        {
            return new Customer();
        }

        public static Cart CreateCart()
        {
            return new Cart();
        }

        public static IProduct CreateProduct()
        {
            return new Product();
        }

    }

}
