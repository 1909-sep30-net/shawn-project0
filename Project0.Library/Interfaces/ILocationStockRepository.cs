using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library.Interfaces
{
    public interface ILocationStockRepository : IDisposable
    {
        public IEnumerable<Library.Models.LocationStock> GetLocationStock(int? locationId);

        public bool UpdateLocationStock(Guid productId, int? locationId, int? quantity);
    }
}
