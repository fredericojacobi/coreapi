using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IEventUserRepository : IRepositoryBase<EventUser>
    {
        Task<IEnumerable<EventUser>> ReadAllEventUsersAsync();

        Task<IEnumerable<EventUser>> ReadAllEventByUserIdAsync(Guid id);

        Task<IEnumerable<EventUser>> ReadEventByEventIdAsync(Guid id);

        Task<EventUser> ReadEventUserAsync(Guid id);

        Task<EventUser> CreateEventUserAsync(EventUser eventUser);

        Task<EventUser> UpdateEventUserAsync(EventUser eventUser);

        Task<bool> DeleteEventUserAsync(EventUser eventUser);

        Task<bool> DeleteEventUserAsync(Guid id);
        
    }
}