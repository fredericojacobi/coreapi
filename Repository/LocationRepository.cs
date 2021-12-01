using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {

        public LocationRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Location> ReadAllLocations() => ReadAll().ToList();

        public Location ReadLocation(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        public Location CreateLocation(Location location) => Create(location);

        public Location UpdateLocation(Location location) => Update(location);

        public bool DeleteLocation(Location location) => Delete(location);

        public bool DeleteLocation(Guid id) => DeleteLocation(ReadLocation(id));
        
    }
}