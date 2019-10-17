using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project0.DataAccess.Entities;
using System.Linq;
using Project0.Library.Interfaces;
using Project0.Library.Models;

namespace Project0.DataAccess.Repositories
{
    class LocationRepository : ILocationsRepository
    {
        private readonly project0Context _dbContext;

        public LocationRepository(project0Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        Library.Models.Locations ILocationsRepository.GetSingleLocation(int? locationId)
        {
            IQueryable<Entities.Locations> Location =   from ls in _dbContext.Locations
                                                        where ls.LocationId == locationId
                                                        select ls;

            return Location.Select(Mapper.MapSingleLocation).First();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~LocationRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
