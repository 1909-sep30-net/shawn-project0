using System;
using BusinessLibrary;
using Data;

namespace Project0
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            var larry = new Customer("Larry", "Smith");
            var walt = new Customer("Walt", "White");

            Console.WriteLine($"My customer is {larry.NameFirst} {larry.NameLast} and his customer id is {larry.CustomerId}.");
            Console.WriteLine($"My other customer is {walt.NameFirst} {walt.NameLast} and his customer id is {walt.CustomerId}.");
            Console.WriteLine();
        }

    }
}

