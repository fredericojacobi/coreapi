using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private IReminderRepository _reminder;

        public IReminderRepository Reminder => _reminder ??= new ReminderRepository(_context);

        public RepositoryWrapper(AppDbContext context) => _context = context;
    }
}