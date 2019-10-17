using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library.Models;

namespace Project0.Library.Interfaces
{
    public interface IProductsRepository : IDisposable
    {
        Products GetSingleProduct(Guid productId);
    }
}
