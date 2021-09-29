using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IReminderRepository : IRepositoryBase<Reminder>
    {
        IEnumerable<Reminder> GetAllReminders();
        
        Reminder GetReminderById(long id);

        Reminder GetReminderByUserId(long userId);
        
    }
}