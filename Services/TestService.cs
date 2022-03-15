using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Models;

namespace Services
{
    public class TestService : ITestService
    {
        private readonly IRepositoryWrapper _repository;

        public TestService(IRepositoryWrapper repository) => _repository = repository;

        public async Task<IEnumerable<Company>> GetAllAsync() => await _repository.Company.ReadAllCompaniesAsync();
    }
}