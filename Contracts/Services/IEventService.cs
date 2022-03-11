using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface IEventService
{
    Task<ReturnRequest<EventDTO>> GetAllAsync();

    Task<ReturnRequest<EventDTO>> GetAsync(Guid id);
    
    Task<ReturnRequest<EventDTO>> GetAllByUserIdAsync(Guid id);
    
    Task<ReturnRequest<EventDTO>> GetByEventIdAsync(Guid id);
    
    Task<ReturnRequest<EventDTO>> PostAsync(EventDTO eventDTO);
    
    Task<ReturnRequest<EventUserDTO>> PostJoinUserAsync(EventUserDTO eventUserDTO);

    Task<ReturnRequest<EventDTO>> PutAsync(Guid id, EventDTO eventDTO);

    Task<ReturnRequest<EventDTO>> DeleteAsync(Guid id);
    
}