using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        IList<Company> ReadAllCompanies();

        Company ReadCompany(Guid id);

        Company CreateCompany(Company company);
        
        IList<Company> CreateRandomCompanies(int quantity);

        Company UpdateCompany(Company company);

        bool DeleteCompany(Company company);

        bool DeleteCompany(Guid id);
    }
}