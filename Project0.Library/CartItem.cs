using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class CartItem : ICartItem
    {
        public int ProductQuantinty { get; set; }
        public IProduct Product { get; set; }
    }
}
