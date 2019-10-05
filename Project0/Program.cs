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

            Console.WriteLine($"My customer is {larry.nameFirst} {larry.nameLast} and his customer id is {larry.customerId}.");
            
        }

    }
}

