using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Contracts.Repositories;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EletronicPointHistoryRepository : RepositoryBase<EletronicPointHistory>,
        IEletronicPointHistoryRepository
    {
        public EletronicPointHistoryRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<EletronicPointHistory> ReadAllHistories() => ReadAll().ToList();

        public EletronicPointHistory ReadHistory(Guid id) =>
            ReadByCondition(x => x.Id.Equals(id))
                .Include(x => x.User)
                .Include(x => x.Point)
                .FirstOrDefault();

        public IEnumerable<EletronicPointHistory> ReadHistoryByUserId(Guid userId) =>
            ReadByCondition(x => x.UserId.Equals(userId))
                .Include(x => x.User)
                .Include(x => x.Point)
                .ToList();

        public EletronicPointHistory CreateHistory(EletronicPointHistory eletronicPointHistory)
        {
            eletronicPointHistory.CreatedAt = DateTime.Now;
            return Create(eletronicPointHistory);
        }

        public EletronicPointHistory UpdateHistory(EletronicPointHistory eletronicPointHistory)
        {
            eletronicPointHistory.ModifiedAt = DateTime.Now;
            return Update(eletronicPointHistory);
        }

        public bool DeleteHistory(EletronicPointHistory eletronicPointHistory) => Delete(eletronicPointHistory);

        public bool DeleteHistory(Guid id)
        {
            var entity = ReadHistory(id);
            return entity is not null && DeleteHistory(entity);
        }
    }
}