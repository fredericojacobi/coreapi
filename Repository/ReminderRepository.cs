using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ReminderRepository : RepositoryBase<Reminder>, IReminderRepository
    {
        public ReminderRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Reminder> ReadAllReminders() => ReadAll().ToList();

        public Reminder ReadReminder(Guid id) => ReadByCondition(r => r.Id.Equals(id))
            .FirstOrDefault();
/*
        public List<Reminder> ReadRemindersByUserId(Guid userId) =>
            ReadByCondition(r => r.User.Id.Equals(userId.ToString())).ToList();
*/
        public Reminder CreateReminder(Reminder reminder)
        {
            reminder.CreatedAt = DateTime.Now;
            var createResult = Create(reminder);
            return ReadReminder(createResult.Id); 
        }

        public Reminder UpdateReminder(Reminder reminder)
        {
            reminder.ModifiedAt = DateTime.Now;
            return Update(reminder);
        }

        public bool DeleteReminder(Reminder reminder) => Delete(reminder);
        
        public bool DeleteReminder(Guid id) => DeleteReminder(ReadReminder(id));
    }
}