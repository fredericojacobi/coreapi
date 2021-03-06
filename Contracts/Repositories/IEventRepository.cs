using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        Task<IEnumerable<Event>> ReadAllEventsAsync();
        
        Task<Event> ReadEventAsync(Guid id);
        
        Task<Event> CreateEventAsync(Event eEvent);
        
        Task<Event> UpdateEventAsync(Event eEvent);
        
        Task<bool> DeleteEventAsync(Event eEvent);
        
        Task<bool> DeleteEventAsync(Guid id);
    }
}