using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Location> ReadAllLocations() => ReadAll().ToList();

        public Location ReadLocation(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        public Location CreateLocation(Location location)
        {
            location.CreatedAt = DateTime.Now;
            
            return Create(location);
        }

        public IEnumerable<Location> CreateMultiplesLocations(IEnumerable<Location> locations) => CreateMultiples(locations);

        public Location UpdateLocation(Location location)
        {
            location.ModifiedAt = DateTime.Now;
            return Update(location);
        }

        public bool DeleteLocation(Location location) => Delete(location);

        public bool DeleteLocation(Guid id)
        {
            var entity = ReadLocation(id);
            return entity is not null && DeleteLocation(entity);
        }

        public bool DeleteMultiplesLocation() => DeleteMultiples();
    }
}