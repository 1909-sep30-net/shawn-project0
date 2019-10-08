using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public static class Factory
    {
        public static ICustomer CreateCustomer()
        {
            return new Customer();
        }

        public static ICart CreateCart()
        {
            return new Cart();
        }

        public static IProduct CreateProduct()
        {
            return new Product();
        }

        public static ICartItem CreateCartItem()
        {
            return new CartItem();
        }

    }

}
