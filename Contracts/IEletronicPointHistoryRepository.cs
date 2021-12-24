using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEletronicPointHistoryRepository : IRepositoryBase<EletronicPointHistory>
    {
        IList<EletronicPointHistory> ReadAllHistories();
        
        EletronicPointHistory ReadHistory(Guid id);

        IList<EletronicPointHistory> ReadHistoryByUserId(Guid userId);
            
        EletronicPointHistory CreateHistory(EletronicPointHistory eletronicPointHistory);
        
        EletronicPointHistory UpdateHistory(EletronicPointHistory eletronicPointHistory);
        
        bool DeleteHistory(EletronicPointHistory eletronicPointHistory);
        
        bool DeleteHistory(Guid id);
    }
}