using System;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface ILocationService
{
    ReturnRequest<LocationDTO> GetAll();

    ReturnRequest<LocationDTO> Get(Guid id);

    ReturnRequest<LocationDTO> Post(LocationDTO location);

    ReturnRequest<LocationDTO> PostMultiple(IEnumerable<LocationDTO> locations);

    ReturnRequest<LocationDTO> Put(Guid id, LocationDTO location);

    ReturnRequest<LocationDTO> Delete(Guid id);
    
    ReturnRequest<LocationDTO> DeleteAll();
    
}