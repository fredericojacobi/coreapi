using System;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;

namespace Contracts.Services
{
    public interface ICompanyService
    {
        ReturnRequest<CompanyDTO> GetAll();

        ReturnRequest<CompanyDTO> Get(Guid id);

        ReturnRequest<CompanyDTO> Post(CompanyDTO company);
        
        ReturnRequest<IEnumerable<CompanyDTO>> PostRandomCompanies(int quantity);

        ReturnRequest<CompanyDTO> Put(Guid id, CompanyDTO company);

        ReturnRequest<CompanyDTO> Delete(Guid id);
        
    }
}