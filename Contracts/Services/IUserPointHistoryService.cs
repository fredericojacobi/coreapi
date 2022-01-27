using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services
{
    public interface IUserPointHistoryService
    {
        Task<ReturnRequest<EletronicPointHistoryDTO>> GetAllAsync();

        Task<ReturnRequest<EletronicPointHistoryDTO>> GetAsync(Guid id);
        
        Task<ReturnRequest<EletronicPointHistoryDTO>> GetDailyUserPointHistoryAsync(Guid userId, DateTime day);

        Task<ReturnRequest<EletronicPointHistoryDTO>> PostAsync(EletronicPointHistoryDTO model);
        
        Task<ReturnRequest<EletronicPointHistoryDTO>> PutAsync(Guid id, EletronicPointHistoryDTO model);
        
        Task<ReturnRequest<EletronicPointHistoryDTO>> DeleteAsync(Guid id);
        
    }
}