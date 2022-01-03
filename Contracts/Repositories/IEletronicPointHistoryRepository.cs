using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IEletronicPointHistoryRepository : IRepositoryBase<EletronicPointHistory>
    {
        IEnumerable<EletronicPointHistory> ReadAllHistories();
        
        EletronicPointHistory ReadHistory(Guid id);

        IEnumerable<EletronicPointHistory> ReadHistoryByUserId(Guid userId);
            
        EletronicPointHistory CreateHistory(EletronicPointHistory eletronicPointHistory);
        
        EletronicPointHistory UpdateHistory(EletronicPointHistory eletronicPointHistory);
        
        bool DeleteHistory(EletronicPointHistory eletronicPointHistory);
        
        bool DeleteHistory(Guid id);
    }
}