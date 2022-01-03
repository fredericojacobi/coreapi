using AutoMapper;
using Contracts;
using Contracts.Repositories;
using Contracts.Services;

namespace Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public ITestService _test;
        public IUserPointHistoryService _userPointHistory;
        public ICompanyService _company;
        public ILocationService _location;
        
        public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ITestService Test => _test ??= new TestService(_repository);
        
        public IUserPointHistoryService UserPointHistory => _userPointHistory ??= new UserPointHistoryService(_repository, _mapper);

        public ICompanyService Company => _company ??= new CompanyService(_repository, _mapper);

        public ILocationService Location => _location ??= new LocationService(_repository, _mapper);
    }
}