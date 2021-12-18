using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Models;
using Services.Contracts;

namespace Services.Models
{
    public class TestService : ITestService
    {
        private readonly ICompanyRepository _companyRepository;
        
        public TestService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public List<Company> GetAll() => _companyRepository.ReadAllCompanies().ToList();
    }
}