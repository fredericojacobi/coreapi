using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IReminderRepository : IRepositoryBase<Reminder>
    {
        Task<IEnumerable<Reminder>> ReadAllRemindersAsync();
        
        Task<Reminder> ReadReminderAsync(Guid id);
        
        Task<Reminder> CreateReminderAsync(Reminder reminder);
        
        Task<Reminder> UpdateReminderAsync(Reminder reminder);
        
        Task<bool> DeleteReminderAsync(Reminder reminder);

        Task<bool> DeleteReminderAsync(Guid id);
    }
}