using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class TestService : ITestService
    {
        private readonly IRepositoryWrapper _repository;

        public TestService(IRepositoryWrapper repository) => _repository = repository;

        public IList<Company> GetAll() => _repository.Company.ReadAllCompanies().ToList();
    }
}