using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;

namespace Data.Repository
{
    public class ReminderRepository
    {
        private readonly AppDbContext _context;
        public ReminderRepository(AppDbContext context) => _context = context;

        public List<Reminder> Get() => _context.Reminders.ToList();

        public Reminder Get(long id) => _context.Reminders.Find(id);

        public Reminder InsertOrUpdate(Reminder reminder)
        {
            _context.Entry(reminder).State = reminder.Id == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(reminder).ReloadAsync();
            return reminder;
        }

        public bool Delete(long id)
        {
            var reminder = _context.Reminders.Find(id);
            _context.Reminders.Remove(reminder);
            return _context.SaveChanges() > 0;
        }
    }
}