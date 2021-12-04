using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Branch> ReadAllBranches() => ReadAll()
            .Include(x => x.Company)
            .Include(x => x.Location)
            .ToList();

        public Branch ReadBranch(Guid id) => ReadByCondition(r => r.Id.Equals(id))
            .Include(x => x.Company)
            .Include(x => x.Location)
            .Include(x => x.Points)
            .FirstOrDefault();

        public IList<Branch> ReadBranchByCompanyId(Guid id) => ReadByCondition(x => x.CompanyId.Equals(id)).ToList();

        public Branch CreateBranch(Branch branch)
        {
            branch.CreatedAt = DateTime.Now;
            var created = Create(branch);
            return created != null ? ReadBranch(created.Id) : null;
        }

        public Branch UpdateBranch(Branch branch)
        {
            branch.ModifiedAt = DateTime.Now;
            var updated = Update(branch);
            return updated != null ? ReadBranch(updated.Id) : null;
        }

        public bool DeleteBranch(Branch branch) => Delete(branch);

        public bool DeleteBranch(Guid id) => DeleteBranch(ReadBranch(id));
    }
}