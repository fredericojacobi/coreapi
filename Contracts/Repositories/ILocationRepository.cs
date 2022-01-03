using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface ILocationRepository : IRepositoryBase<Location>
    {
        IEnumerable<Location> ReadAllLocations();

        Location ReadLocation(Guid id);

        Location CreateLocation(Location location);

        IEnumerable<Location> CreateMultiplesLocations(IEnumerable<Location> locations);
        
        Location UpdateLocation(Location location);

        bool DeleteLocation(Location location);
        
        bool DeleteLocation(Guid id);

        bool DeleteMultiplesLocation();
        
    }
}