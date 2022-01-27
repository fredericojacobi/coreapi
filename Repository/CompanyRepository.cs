using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repositories;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Company>> ReadAllCompaniesAsync() => await ReadAllAsync();

        public async Task<Company> ReadCompanyAsync(Guid id)
        {
            var companies = await ReadByConditionAsync(
                x => x.Id.Equals(id),
                x => x.Branches);
                return companies.FirstOrDefault();
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            company.CreatedAt = DateTime.Now;
            return await CreateAsync(company);
        }

        public async Task<IEnumerable<Company>> CreateRandomCompaniesAsync(int quantity)
        {
            var companies = new List<Company>();
            for (var i = 0; i < quantity; i++)
                companies.Add(await CreateCompanyAsync(new Company {Name = Generic.Functions.Random.Name(15)}));

            return await CreateMultipleAsync(companies);
        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            company.ModifiedAt = DateTime.Now;
            return await UpdateAsync(company.Id, company);
        }

        public async Task<bool> DeleteCompanyAsync(Company company) => await DeleteAsync(company);

        public async Task<bool> DeleteCompanyAsync(Guid id)
        {
            var entity = await ReadCompanyAsync(id);
            return entity is not null && await DeleteCompanyAsync(entity.Id);
        }
    }
}