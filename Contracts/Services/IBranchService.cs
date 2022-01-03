using System;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface IBranchService
{
    ReturnRequest<BranchDTO> GetAll();

    ReturnRequest<BranchDTO> Get(Guid id);

    ReturnRequest<BranchDTO> GetByCompanyId(Guid id);

    ReturnRequest<BranchDTO> Post(BranchDTO branchDTO);

    ReturnRequest<BranchDTO> Put(Guid id, BranchDTO branchDTO);

    ReturnRequest<BranchDTO> Delete(Guid id);
    
}