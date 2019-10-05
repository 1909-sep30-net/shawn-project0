using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Product
    {
        int ProductId;
        int StockQuantity;

        Product(int productId, int stockQuantity)
        {
            this.ProductId = productId;
            this.StockQuantity = stockQuantity;
        }
    }
}
