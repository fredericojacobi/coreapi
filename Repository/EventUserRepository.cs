using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Contracts.Repositories;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class EventUserRepository : RepositoryBase<EventUser>, IEventUserRepository
    {

        public EventUserRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<EventUser> ReadAllEventUsers() => ReadAll().ToList();
        
        public IEnumerable<EventUser> ReadEventByUserId(Guid id) => ReadByCondition(x => x.UserId.Equals(id)).ToList();
        
        public IEnumerable<EventUser> ReadEventByEventId(Guid id) => ReadByCondition(x => x.EventId.Equals(id)).ToList();

        public EventUser ReadEventUser(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        public EventUser CreateEventUser(EventUser eventUser) => Create(eventUser);

        public EventUser UpdateEventUser(EventUser eventUser) => Update(eventUser);

        public bool DeleteEventUser(EventUser eventUser) => Delete(eventUser);

        public bool DeleteEventUser(Guid id)
        {
            var entity = ReadEventUser(id);
            return entity is not null && DeleteEventUser(entity);
        }
    }
}