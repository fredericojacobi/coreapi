using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IBranchRepository : IRepositoryBase<Branch>
    {
        IEnumerable<Branch> ReadAllBranches();

        Branch ReadBranch(Guid id);

        IEnumerable<Branch> ReadBranchByCompanyId(Guid id);
        
        Branch CreateBranch(Branch branch);
        
        Branch UpdateBranch(Branch branch);
        
        bool DeleteBranch(Branch branch);
        
        bool DeleteBranch(Guid id);
    }
}