using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public static class MessageHandler
    {
        public static void QuantityError(string product, int stockQuantity, int customerQuantity)
        {
            Console.WriteLine($"There are only {stockQuantity} of the {product} in stock.");
        }

    }
}
