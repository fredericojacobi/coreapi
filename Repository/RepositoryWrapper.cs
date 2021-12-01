using Contracts;
using Entities.Context;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private IBranchRepository _branch;
        private ICompanyRepository _company;
        private IEletronicPointHistoryRepository _eletronicPointHistory;
        private IEventRepository _event;
        private ILocationRepository _location;
        private IPointRepository _point;
        private IReminderRepository _reminder;
        private IUserRepository _user;
        
        public IBranchRepository Branch => _branch ??= new BranchRepository(_context);

        public ICompanyRepository Company => _company ??= new CompanyRepository(_context);
        
        public IEletronicPointHistoryRepository EletronicPointHistory => _eletronicPointHistory ??= new EletronicPointHistoryRepository(_context);
        
        public IEventRepository Event => _event ??= new EventRepository(_context);

        public ILocationRepository Location => _location ??= new LocationRepository(_context);

        public IPointRepository Point => _point ??= new PointRepository(_context);
        
        public IReminderRepository Reminder => _reminder ??= new ReminderRepository(_context);

        public IUserRepository User => _user ??= new UserRepository(_context);


        
        
        public RepositoryWrapper(AppDbContext context) => _context = context;
    }
}