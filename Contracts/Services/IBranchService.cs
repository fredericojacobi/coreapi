using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface IBranchService
{
    Task<ReturnRequest<BranchDTO>> GetAllAsync();

    Task<ReturnRequest<BranchDTO>> GetAsync(Guid id);

    Task<ReturnRequest<BranchDTO>> GetByCompanyIdAsync(Guid id);

    Task<ReturnRequest<BranchDTO>> PostAsync(BranchDTO branchDTO);

    Task<ReturnRequest<BranchDTO>> PutAsync(Guid id, BranchDTO branchDTO);

    Task<ReturnRequest<BranchDTO>> DeleteAsync(Guid id);
    
}