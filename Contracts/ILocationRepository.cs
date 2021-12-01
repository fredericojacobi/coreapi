using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ILocationRepository : IRepositoryBase<Location>
    {
        IList<Location> ReadAllLocations();

        Location ReadLocation(Guid id);

        Location CreateLocation(Location location);

        Location UpdateLocation(Location location);

        bool DeleteLocation(Location location);

        bool DeleteLocation(Guid id);
        
    }
}