using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IReminderRepository : IRepositoryBase<Reminder>
    {
        IList<Reminder> ReadAllReminders();
        
        Reminder ReadReminder(Guid id);
        /*
        List<Reminder> ReadRemindersByUserId(Guid userId);
        */
        Reminder CreateReminder(Reminder reminder);
        
        Reminder UpdateReminder(Reminder reminder);
        
        bool DeleteReminder(Reminder reminder);

        bool DeleteReminder(Guid id);
    }
}