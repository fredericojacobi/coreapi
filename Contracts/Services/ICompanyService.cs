using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;

namespace Contracts.Services
{
    public interface ICompanyService
    {
        Task<ReturnRequest<CompanyDTO>> GetAllAsync();

        Task<ReturnRequest<CompanyDTO>> GetAsync(Guid id);

        Task<ReturnRequest<CompanyDTO>> PostAsync(CompanyDTO company);
        
        Task<ReturnRequest<CompanyDTO>> PostRandomCompaniesAsync(int quantity);

        Task<ReturnRequest<CompanyDTO>> PutAsync(Guid id, CompanyDTO company);

        Task<ReturnRequest<CompanyDTO>> DeleteAsync(Guid id);
        
    }
}