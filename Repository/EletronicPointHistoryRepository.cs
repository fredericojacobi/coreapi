using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class EletronicPointHistoryRepository : RepositoryBase<EletronicPointHistory>,
        IEletronicPointHistoryRepository
    {
        public EletronicPointHistoryRepository(AppDbContext context) : base(context)
        {
        }

        public IList<EletronicPointHistory> ReadAllHistories() => ReadAll().ToList();

        public EletronicPointHistory ReadHistory(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        public EletronicPointHistory CreateHistory(EletronicPointHistory eletronicPointHistory) =>
            Create(eletronicPointHistory);

        public EletronicPointHistory UpdateHistory(EletronicPointHistory eletronicPointHistory) =>
            Update(eletronicPointHistory);

        public bool DeleteHistory(EletronicPointHistory eletronicPointHistory) => Delete(eletronicPointHistory);

        public bool DeleteHistory(Guid id) => DeleteHistory(ReadHistory(id));
    }
}