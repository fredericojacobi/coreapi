using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface ILocationRepository : IRepositoryBase<Location>
    {
        Task<IEnumerable<Location>> ReadAllLocationsAsync();

        Task<Location> ReadLocationAsync(Guid id);

        Task<Location> CreateLocationAsync(Location location);

        Task<IEnumerable<Location>> CreateMultipleLocationsAsync(IEnumerable<Location> locations);
        
        Task<Location> UpdateLocationAsync(Location location);

        Task<bool> DeleteLocationAsync(Location location);
        
        Task<bool> DeleteLocationAsync(Guid id);

        Task<bool> DeleteMultipleLocationAsync(int quantity);
    }
}