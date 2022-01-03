using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private IBranchRepository _branch;
        private ICompanyRepository _company;
        private IEletronicPointHistoryRepository _eletronicPointHistory;
        private IEventRepository _event;
        private ILocationRepository _location;
        private IPointRepository _point;
        private IReminderRepository _reminder;
        private IUserRepository _user;
        private IEventUserRepository _eventUser;
        
        public RepositoryWrapper(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IBranchRepository Branch => _branch ??= new BranchRepository(_context);

        public ICompanyRepository Company => _company ??= new CompanyRepository(_context);
        
        public IEletronicPointHistoryRepository EletronicPointHistory => _eletronicPointHistory ??= new EletronicPointHistoryRepository(_context);
        
        public IEventRepository Event => _event ??= new EventRepository(_context);

        public ILocationRepository Location => _location ??= new LocationRepository(_context);

        public IPointRepository Point => _point ??= new PointRepository(_context);
        
        public IReminderRepository Reminder => _reminder ??= new ReminderRepository(_context);

        public IUserRepository User => _user ??= new UserRepository(_context, _userManager);
        
        public IEventUserRepository EventUser => _eventUser ??= new EventUserRepository(_context);
    }
}