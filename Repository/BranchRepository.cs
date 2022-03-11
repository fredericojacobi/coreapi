using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repositories;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Repository
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Branch>> ReadAllBranchesAsync() => await ReadAllAsync(x => x.Company, x=> x.Location, x=> x.Points);

        public async Task<Branch> ReadBranchAsync(Guid id)
        {
            var branches = await ReadByConditionAsync(
                x => x.Id.Equals(id),
                x => x.Company,
                x => x.Location,
                x => x.Points);
            return branches.FirstOrDefault();
        }

        public async Task<IEnumerable<Branch>> ReadBranchByCompanyIdAsync(Guid id) => await ReadByConditionAsync(x => x.CompanyId.Equals(id));

        public async Task<Branch> CreateBranchAsync(Branch branch)
        {
            branch.CreatedAt = DateTime.Now;
            return await CreateAsync(branch);
        }

        public async Task<Branch> UpdateBranchAsync(Branch branch)
        {
            branch.ModifiedAt = DateTime.Now;
            return await UpdateAsync(branch.Id, branch);
        }

        public async Task<bool> DeleteBranchAsync(Branch branch) => await DeleteAsync(branch);

        public async Task<bool> DeleteBranchAsync(Guid id)
        {
            var entity = await ReadBranchAsync(id);
            return entity is not null && await DeleteBranchAsync(entity);
        }
    }
}