using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Event> ReadAllEvents() => ReadAll().ToList();

        public Event ReadEvent(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        public Event CreateEvent(Event eEvent) =>Create(eEvent); 
            
        public Event UpdateEvent(Event eEvent) => Update(eEvent);

        public bool DeleteEvent(Event eEvent) => Delete(eEvent);

        public bool DeleteEvent(Guid id) => DeleteEvent(ReadEvent(id));
    }
}