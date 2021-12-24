using System;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;

namespace Services.Contracts
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