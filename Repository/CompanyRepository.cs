using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
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

        public IList<Company> ReadAllCompanies() => ReadAll().ToList();

        public Company ReadCompany(Guid id) => ReadByCondition(x => x.Id.Equals(id))
            .Include(x => x.Branches)
            .FirstOrDefault();

        public Company CreateCompany(Company company)
        {
            company.CreatedAt = DateTime.Now;
            return Create(company);
        }

        public IList<Company> CreateRandomCompanies(int quantity)
        {
            var companies = new List<Company>();
            for (var i = 0; i < quantity; i++)
            {
                companies.Add(CreateCompany(new Company {Name = Generic.Functions.Random.Name(15)}));
            }

            return companies;
        }

        public Company UpdateCompany(Company company)
        {
            company.ModifiedAt = DateTime.Now;
            return Update(company);
        }

        public bool DeleteCompany(Company company) => Delete(company);

        public bool DeleteCompany(Guid id) => DeleteCompany(ReadCompany(id));
        
    }
}