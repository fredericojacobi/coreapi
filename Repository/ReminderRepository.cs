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

        public List<Reminder> ReadAllReminders() => ReadAll().OrderBy(r => r.ReminderId).ToList();

        public Reminder ReadReminderById(Guid id) => ReadByCondition(r => r.ReminderId.Equals(id)).FirstOrDefault();

        public List<Reminder> ReadRemindersByUserId(Guid userId) =>
            ReadByCondition(r => r.User.Id.Equals(userId.ToString())).ToList();

        public Reminder CreateReminder(Reminder reminder) => Create(reminder);

        public Reminder UpdateReminder(Reminder reminder) => Update(reminder);

        public bool DeleteReminder(Reminder reminder) => Delete(reminder);
    }
}