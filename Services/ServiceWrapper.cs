using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;

namespace Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        
        private ITestService _test;
        private IUserPointHistoryService _userPointHistory;
        private ICompanyService _company;
        private ILocationService _location;
        private IBranchService _branch;
        private IEventService _event;
        private IUserService _user;
        private IPointService _point;
        
        public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ITestService Test => _test ??= new TestService(_repository);
        
        public IUserPointHistoryService UserPointHistory => _userPointHistory ??= new UserPointHistoryService(_repository, _mapper);

        public ICompanyService Company => _company ??= new CompanyService(_repository, _mapper);

        public ILocationService Location => _location ??= new LocationService(_repository, _mapper);

        public IBranchService Branch => _branch ??= new BranchService(_repository, _mapper);

        public IEventService Event => _event ??= new EventService(_repository, _mapper);
        
        public IUserService User => _user ??= new UserService(_repository, _mapper);

        public IPointService Point => _point ??= new PointService(_repository, _mapper);
    }
}