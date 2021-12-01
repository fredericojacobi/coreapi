using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {

        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Company> ReadAllCompanies() => ReadAll().ToList();

        public Company ReadCompany(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        public Company CreateCompany(Company company) => Create(company);

        public Company UpdateCompany(Company company) => Update(company);

        public bool DeleteCompany(Company company) => Delete(company);

        public bool DeleteCompany(Guid id) => DeleteCompany(ReadCompany(id));
        
    }
}