using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repositories;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Location>> ReadAllLocationsAsync() => await ReadAllAsync();

        public async Task<Location> ReadLocationAsync(Guid id)
        {
            var location = await ReadByConditionAsync(x => x.Id.Equals(id));
            return location.FirstOrDefault();
        }

        public async Task<Location> CreateLocationAsync(Location location)
        {
            location.CreatedAt = DateTime.Now;
            location.ModifiedAt = DateTime.Now;
            return await CreateAsync(location);
        }

        public async Task<IEnumerable<Location>> CreateMultipleLocationsAsync(IEnumerable<Location> locations) =>
            await CreateMultipleAsync(locations);

        public async Task<Location> UpdateLocationAsync(Location location)
        {
            location.ModifiedAt = DateTime.Now;
            return await UpdateAsync(location.Id, location);
        }

        public async Task<bool> DeleteLocationAsync(Location location) => await DeleteAsync(location);

        public async Task<bool> DeleteLocationAsync(Guid id)
        {
            var entity = await ReadLocationAsync(id);
            return entity is not null && await DeleteLocationAsync(entity);
        }

        public async Task<bool> DeleteMultipleLocationAsync(int quantity) => await DeleteMultipleAsync(quantity);
    }
}