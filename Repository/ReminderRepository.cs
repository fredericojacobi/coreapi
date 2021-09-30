using System;
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

        public Reminder GetReminderById(Guid id) => FindByCondition(r => r.Id.Equals(id)).FirstOrDefault();

        public Reminder GetReminderByUserId(Guid userId) => FindByCondition(r => r.User.Id.Equals(userId)).FirstOrDefault();
        
    }
}