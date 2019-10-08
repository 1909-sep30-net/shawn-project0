using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public static class MessageHandler
    {
        public static void LowStockError(string product, int stockQuantity, int customerQuantity)
        {
            Console.WriteLine($"There are only {stockQuantity} of the {product} in stock. No action taken.");
        }

        public static void SuccessfulRemove(string product, int quantity)
        {
            Console.WriteLine($"Successfully removed {quantity} of {product} from order.");
        }

        public static void SuccessfulRemove(string product)
        {
            Console.WriteLine($"Successfully removed all {product} from order.");
        }

        public static void SuccessfulAddition(string product, int quantity)
        {
            Console.WriteLine($"Successfully added {quantity} of {product} to order.");
        }

    }
}
