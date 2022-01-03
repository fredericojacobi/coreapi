using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IEventUserRepository : IRepositoryBase<EventUser>
    {
        IEnumerable<EventUser> ReadAllEventUsers();

        IEnumerable<EventUser> ReadEventByUserId(Guid id);

        IEnumerable<EventUser> ReadEventByEventId(Guid id);

        EventUser ReadEventUser(Guid id);

        EventUser CreateEventUser(EventUser eventUser);

        EventUser UpdateEventUser(EventUser eventUser);

        bool DeleteEventUser(EventUser eventUser);

        bool DeleteEventUser(Guid id);
        
    }
}