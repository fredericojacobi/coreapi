using System;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services
{
    public interface IUserPointHistoryService
    {
        ReturnRequest<EletronicPointHistoryDTO> GetAll();

        ReturnRequest<EletronicPointHistoryDTO> Get(Guid id);
        
        ReturnRequest<EletronicPointHistoryDTO> GetDailyUserPointHistory(Guid userId);

        ReturnRequest<EletronicPointHistoryDTO> Post(EletronicPointHistoryDTO model);
        
        ReturnRequest<EletronicPointHistoryDTO> Put(Guid id, EletronicPointHistoryDTO model);
        
        ReturnRequest<EletronicPointHistoryDTO> Delete(Guid id);
        
    }
}