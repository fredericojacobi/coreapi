using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IBranchRepository : IRepositoryBase<Branch>
    {
        IList<Branch> ReadAllBranches();

        Branch ReadBranch(Guid id);

        IList<Branch> ReadBranchByCompanyId(Guid id);
        
        Branch CreateBranch(Branch branch);
        
        Branch UpdateBranch(Branch branch);
        
        bool DeleteBranch(Branch branch);
        
        bool DeleteBranch(Guid id);
    }
}