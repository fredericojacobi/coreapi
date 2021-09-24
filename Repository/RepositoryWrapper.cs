using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        public IUserRepository _user;
        public IReminderRepository _reminder;

        // retorna se for nulo retorna new
        public IUserRepository User => _user ??= new UserRepository(_context);

        public IReminderRepository Reminder => _reminder ??= new ReminderRepository(_context);

        public RepositoryWrapper(AppDbContext context) => _context = context;
    }
}