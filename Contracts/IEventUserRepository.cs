using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEventUserRepository : IRepositoryBase<EventUser>
    {
        IList<EventUser> ReadAllEventUsers();

        EventUser ReadEventUser(Guid id);

        EventUser CreateEventUser(EventUser eventUser);

        EventUser UpdateEventUser(EventUser eventUser);

        bool DeleteEventUser(EventUser eventUser);

        bool DeleteEventUser(Guid id);
        
    }
}