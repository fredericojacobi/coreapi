using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IReminderRepository : IRepositoryBase<Reminder>
    {
        List<Reminder> ReadAllReminders();
        
        Reminder ReadReminderById(Guid id);

        List<Reminder> ReadRemindersByUserId(Guid userId);
        
        Reminder CreateReminder(Reminder reminder);
        
        Reminder UpdateReminder(Reminder reminder);
        
        bool DeleteReminder(Reminder reminder);
    }
}