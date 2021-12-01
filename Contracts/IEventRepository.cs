using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        IList<Event> ReadAllEvents();
        
        Event ReadEvent(Guid id);
        
        Event CreateEvent(Event eEvent);
        
        Event UpdateEvent(Event eEvent);
        
        bool DeleteEvent(Event eEvent);
        
        bool DeleteEvent(Guid id);
    }
}