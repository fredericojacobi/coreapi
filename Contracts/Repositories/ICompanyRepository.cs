using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<IEnumerable<Company>> ReadAllCompaniesAsync();

        Task<Company> ReadCompanyAsync(Guid id);

        Task<Company> CreateCompanyAsync(Company company);
        
        Task<IEnumerable<Company>> CreateRandomCompaniesAsync(int quantity);

        Task<Company> UpdateCompanyAsync(Company company);

        Task<bool> DeleteCompanyAsync(Company company);

        Task<bool> DeleteCompanyAsync(Guid id);
    }
}