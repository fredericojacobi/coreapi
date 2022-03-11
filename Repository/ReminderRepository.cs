using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class ReminderRepository : RepositoryBase<Reminder>, IReminderRepository
    {
        public ReminderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reminder>> ReadAllRemindersAsync() => await ReadAllAsync();

        public async Task<Reminder> ReadReminderAsync(Guid id)
        {
            var reminder = await ReadByConditionAsync(r => r.Id.Equals(id));
            return reminder.FirstOrDefault();
        }

        public async Task<Reminder> CreateReminderAsync(Reminder reminder)
        {
            reminder.CreatedAt = DateTime.Now;
            var createResult = await CreateAsync(reminder);
            return await ReadReminderAsync(createResult.Id);         
        }
        
        public async Task<Reminder> UpdateReminderAsync(Reminder reminder)
        {
            reminder.ModifiedAt = DateTime.Now;
            return await UpdateAsync(reminder.Id, reminder);
        }

        public async Task<bool> DeleteReminderAsync(Reminder reminder) => await DeleteAsync(reminder);
        
        public async Task<bool> DeleteReminderAsync(Guid id)
        {
            var entity = await ReadReminderAsync(id);
            return entity is not null && await DeleteReminderAsync(entity);
        }
    }
}