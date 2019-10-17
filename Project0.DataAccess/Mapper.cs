using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library.Models;

namespace Project0.DataAccess
{
    public static class Mapper
    {
        public static Entities.Customers MapAllCustomers(Library.Models.Customers customers)
        {
            return new Entities.Customers
            {
                CustomerId = customers.CustomerId,
                FirstName = customers.FirstName,
                LastName = customers.LastName
            };
        }

        public static Library.Models.Customers MapAllCustomers(Entities.Customers customers)
        {
            return new Library.Models.Customers
            {
                CustomerId = customers.CustomerId,
                FirstName = customers.FirstName,
                LastName = customers.LastName
            };
        }

        public static Entities.LocationStock MapLocationStock(Library.Models.LocationStock locationStock)
        {
            return new Entities.LocationStock
            {
                LocationId = locationStock.LocationId,
                ProductId = locationStock.ProductId,
                Quantity = locationStock.Quantity
            };
        }

        public static Library.Models.LocationStock MapLocationStock(Entities.LocationStock locationStock)
        {
            return new Library.Models.LocationStock
            {
                LocationId = locationStock.LocationId,
                ProductId = locationStock.ProductId,
                Quantity = locationStock.Quantity
            };
        }

        public static Entities.Products MapSingleProduct(Library.Models.Products products)
        {
            return new Entities.Products
            {
                ProductId = products.ProductId,
                ProductName = products.ProductName,
                ProductDesc = products.ProductDesc
            };
        }

        public static Library.Models.Products MapSingleProduct(Entities.Products products)
        {
            return new Library.Models.Products
            {
                ProductId = products.ProductId,
                ProductName = products.ProductName,
                ProductDesc = products.ProductDesc
            };
        }



    }
}
