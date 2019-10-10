using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class CartItem : ICartItem
    {
        public int ProductQuantinty { get; set; }
        public IProduct Product { get; set; }
    }
}
