using AutoMapper;
using Contracts;
using Services.Contracts;

namespace Services.Models
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public ITestService _test;
        public IUserPointHistoryService _userPointHistory;

        public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ITestService Test => _test ??= new TestService(_repository);
        
        public IUserPointHistoryService UserPointHistory => _userPointHistory ??= new UserPointHistoryService(_repository, _mapper);
    }
}