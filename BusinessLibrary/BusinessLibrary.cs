using System;
using System.Collections.Generic;

namespace BusinessLibrary
{
    public class Customer
    {
        public string nameFirst;
        public string nameLast;
        public string customerId;

        public List<string> customerInfo = new List<string>();

        public Customer(string nameFirst, string nameLast)
        {
            this.nameFirst = nameFirst;
            this.nameLast = nameLast;
            this.customerId = Guid.NewGuid().ToString();

            this.customerInfo.Add(this.nameFirst);
            this.customerInfo.Add(this.nameLast);
            this.customerInfo.Add(this.customerId);
        }   

        public List<string> GetCustomer()
        {
            return customerInfo;
        }

    }

    public class Store
    {
        int storeId;

        Store(int storeId)
        {
            this.storeId = storeId;
        }


    }

    public class Product
    {
        int productId;
        int stockQuantity;

        Product(int productId, int stockQuantity)
        {
            this.productId = productId;
            this.stockQuantity = stockQuantity;
        }
    }

    public class Order
    {
        int storeId;
        int customerId;
        int productId;
        int orderQuantity;
        //string orderTime;


        Order(int productId, int orderQuantity, int customerId, int storeId)
        {
            this.productId = productId;
            this.orderQuantity = orderQuantity;
            this.customerId = customerId;
            this.storeId = storeId;
            // this.orderTime = 
        }
    }
}
