using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IEletronicPointHistoryRepository : IRepositoryBase<EletronicPointHistory>
    {
        Task<IEnumerable<EletronicPointHistory>> ReadAllHistoriesAsync();
        
        Task<EletronicPointHistory> ReadHistoryAsync(Guid id);

        Task<IEnumerable<EletronicPointHistory>> ReadHistoryByUserIdAsync(Guid userId);
            
        Task<EletronicPointHistory> CreateHistoryAsync(EletronicPointHistory eletronicPointHistory);
        
        Task<EletronicPointHistory> UpdateHistoryAsync(EletronicPointHistory eletronicPointHistory);
        
        Task<bool> DeleteHistoryAsync(EletronicPointHistory eletronicPointHistory);
        
        Task<bool> DeleteHistoryAsync(Guid id);
    }
}