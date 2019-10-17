using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library.Models;

namespace Project0.Library.Interfaces
{
    public interface IOrdersRepository : IDisposable
    {
        // Add Get GetAll

        public IEnumerable<Library.Models.Orders> GetAllOrders();

        public Library.Models.Orders GetSingleOrder(Guid orderId);

        public void PlaceOrder(Library.Models.Orders orders);
    }
}
