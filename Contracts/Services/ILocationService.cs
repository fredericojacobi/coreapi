using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface ILocationService
{
    Task<ReturnRequest<LocationDTO>> GetAllAsync();

    Task<ReturnRequest<LocationDTO>> GetAsync(Guid id);

    Task<ReturnRequest<LocationDTO>> PostAsync(LocationDTO location);

    Task<ReturnRequest<LocationDTO>> PostMultipleAsync(IEnumerable<LocationDTO> locations);

    Task<ReturnRequest<LocationDTO>> PutAsync(Guid id, LocationDTO location);

    Task<ReturnRequest<LocationDTO>> DeleteAsync(Guid id);
    
    Task<ReturnRequest<LocationDTO>> DeleteAllAsync(int quantity);
    
}