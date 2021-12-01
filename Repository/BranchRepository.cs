using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Branch> ReadAllBranches() => ReadAll().ToList();

        public Branch ReadBranch(Guid id) => ReadByCondition(r => r.Id.Equals(id)).FirstOrDefault();

        public Branch CreateBranch(Branch branch) => Create(branch);

        public Branch UpdateBranch(Branch branch) => Update(branch);

        public bool DeleteBranch(Branch branch) => Delete(branch);

        public bool DeleteBranch(Guid id) => DeleteBranch(ReadBranch(id));
    }
}