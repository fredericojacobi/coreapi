using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Contracts.Repositories;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Event> ReadAllEvents()
        {
            var entities = ReadAll().ToList();
            return entities.Any() ? entities : null;
        }

        public Event ReadEvent(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        public Event CreateEvent(Event eEvent)
        {
            eEvent.CreatedAt = DateTime.Now;
            return Create(eEvent);
        }

        public Event UpdateEvent(Event eEvent)
        {
            eEvent.ModifiedAt = DateTime.Now;
            return Update(eEvent);
        }

        public bool DeleteEvent(Event eEvent) => Delete(eEvent);

        public bool DeleteEvent(Guid id)
        {
            var entity = ReadEvent(id);
            return entity is not null && DeleteEvent(entity);
        }
    }
}