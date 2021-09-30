using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IReminderRepository : IRepositoryBase<Reminder>
    {
        IEnumerable<Reminder> GetAllReminders();
        
        Reminder GetReminderById(Guid id);

        Reminder GetReminderByUserId(Guid userId);
        
    }
}