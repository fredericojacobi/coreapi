using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IReminderRepository : IRepositoryBase<Reminder>
    {
        IEnumerable<Reminder> ReadAllReminders();
        
        Reminder ReadReminder(Guid id);
        /*
        IEnumerable<Reminder> ReadRemindersByUserId(Guid userId);
        */
        Reminder CreateReminder(Reminder reminder);
        
        Reminder UpdateReminder(Reminder reminder);
        
        bool DeleteReminder(Reminder reminder);

        bool DeleteReminder(Guid id);
    }
}