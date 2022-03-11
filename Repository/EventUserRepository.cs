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
    public class EventUserRepository : RepositoryBase<EventUser>, IEventUserRepository
    {
        public EventUserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EventUser>> ReadAllEventUsersAsync() => await ReadAllAsync();

        public async Task<IEnumerable<EventUser>> ReadAllEventByUserIdAsync(Guid id) =>
            await ReadAllAsync();

        public async Task<IEnumerable<EventUser>> ReadEventByEventIdAsync(Guid id) =>
            await ReadAllAsync();

        public async Task<EventUser> ReadEventUserAsync(Guid id)
        {
            var eventUser = await ReadByConditionAsync(x => x.Id.Equals(id));
            return eventUser.FirstOrDefault();
        }

        public async Task<EventUser> CreateEventUserAsync(EventUser eventUser) => await CreateAsync(eventUser);

        public async Task<EventUser> UpdateEventUserAsync(EventUser eventUser) =>
            await UpdateAsync(eventUser.Id, eventUser);

        public async Task<bool> DeleteEventUserAsync(EventUser eventUser) => await DeleteAsync(eventUser);

        public async Task<bool> DeleteEventUserAsync(Guid id)
        {
            var entity = await ReadEventUserAsync(id);
            return entity is not null && await DeleteEventUserAsync(entity);
        }
    }
}