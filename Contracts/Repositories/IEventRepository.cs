using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        IEnumerable<Event> ReadAllEvents();
        
        Event ReadEvent(Guid id);
        
        Event CreateEvent(Event eEvent);
        
        Event UpdateEvent(Event eEvent);
        
        bool DeleteEvent(Event eEvent);
        
        bool DeleteEvent(Guid id);
    }
}