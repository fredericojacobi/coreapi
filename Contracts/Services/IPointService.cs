using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface IPointService
{
    Task<ReturnRequest<PointDTO>> GetAllAsync();

    Task<ReturnRequest<PointDTO>> GetAsync(Guid id);

    Task<ReturnRequest<PointDTO>> PostAsync(PointDTO point);

    Task<ReturnRequest<PointDTO>> PutAsync(Guid id, PointDTO point);

    Task<ReturnRequest<PointDTO>> DeleteAsync(Guid id);
    
}