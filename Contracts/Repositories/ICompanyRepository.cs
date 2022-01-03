using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        IEnumerable<Company> ReadAllCompanies();

        Company ReadCompany(Guid id);

        Company CreateCompany(Company company);
        
        IEnumerable<Company> CreateRandomCompanies(int quantity);

        Company UpdateCompany(Company company);

        bool DeleteCompany(Company company);

        bool DeleteCompany(Guid id);
    }
}