using Contracts;
using Entities.Context;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private IReminderRepository _reminder;
        private IUserRepository _user;
        private IEletronicPointHistoryRepository _eletronicPointHistory;

        public IReminderRepository Reminder => _reminder ??= new ReminderRepository(_context);

        public IUserRepository User => _user ??= new UserRepository(_context);

        public IEletronicPointHistoryRepository EletronicPointHistory => _eletronicPointHistory ??= new EletronicPointHistoryRepository(_context);

        public RepositoryWrapper(AppDbContext context) => _context = context;
    }
}