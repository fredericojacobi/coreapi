using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ReminderRepository : RepositoryBase<Reminder>, IReminderRepository
    {
        public ReminderRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Reminder> GetAllReminders() => FindAll().OrderBy(r => r.Id).ToList();

        public Reminder GetReminderById(long id) => FindByCondition(r => r.Id.Equals(id)).FirstOrDefault();

        public Reminder GetReminderByUserId(long userId) => FindByCondition(r => r.UserId.Equals(userId)).FirstOrDefault();
        
    }
}