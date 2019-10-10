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

        public static ICart CreateCart(ICustomer Owner)
        {
            return new Cart(Owner);
        }

        public static IProduct CreateProduct()
        {
            return new Product();
        }

        public static ICartItem CreateCartItem()
        {
            return new CartItem();
        }

        public static List<ICartItem> CreateCartItemList()
        {
            return new List<ICartItem>();
        }

        public static IUpdateCart CartHandler()
        {
            return new UpdateCart();
        }

        .

    }

}
