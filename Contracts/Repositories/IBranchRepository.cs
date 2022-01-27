using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IBranchRepository : IRepositoryBase<Branch>
    {
        Task<IEnumerable<Branch>> ReadAllBranchesAsync();

        Task<Branch> ReadBranchAsync(Guid id);

        Task<IEnumerable<Branch>> ReadBranchByCompanyIdAsync(Guid id);
        
        Task<Branch> CreateBranchAsync(Branch branch);
        
        Task<Branch> UpdateBranchAsync(Branch branch);
        
        Task<bool> DeleteBranchAsync(Branch branch);
        
        Task<bool> DeleteBranchAsync(Guid id);
    }
}