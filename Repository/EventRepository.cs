using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Event>> ReadAllEventsAsync() => await ReadAllAsync();

        public async Task<Event> ReadEventAsync(Guid id)
        {
            var events = await ReadByConditionAsync(x => x.Id.Equals(id));
            return events.FirstOrDefault();
        }
        
        public async Task<Event> CreateEventAsync(Event eEvent)
        {
            eEvent.CreatedAt = DateTime.Now;
            return await CreateAsync(eEvent);
        }

        public async Task<Event> UpdateEventAsync(Event eEvent)
        {
            eEvent.ModifiedAt = DateTime.Now;
            return await UpdateAsync(eEvent.Id, eEvent);
        }

        public async Task<bool> DeleteEventAsync(Event eEvent) => await DeleteAsync(eEvent);

        public async Task<bool> DeleteEventAsync(Guid id)
        {
            var entity = await ReadEventAsync(id);
            return entity is not null && await DeleteEventAsync(entity.Id);
        }
    }
}