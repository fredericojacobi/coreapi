using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<EletronicPointHistory>> ReadAllHistoriesAsync() => await ReadAllAsync();

        public async Task<EletronicPointHistory> ReadHistoryAsync(Guid id)
        {
            var histories = await ReadByConditionAsync(
                x => x.Id.Equals(id),
                x => x.User,
                x => x.Point);
            return histories.FirstOrDefault();
        }

        public async Task<IEnumerable<EletronicPointHistory>> ReadHistoryByUserIdAsync(Guid userId) =>
            await ReadByConditionAsync(
                x => x.UserId.Equals(userId),
                x => x.User,
                x => x.Point
            );

        public async Task<EletronicPointHistory> CreateHistoryAsync(EletronicPointHistory eletronicPointHistory)
        {
            eletronicPointHistory.CreatedAt = DateTime.Now;
            return await CreateAsync(eletronicPointHistory);
        }

        public async Task<EletronicPointHistory> UpdateHistoryAsync(EletronicPointHistory eletronicPointHistory)
        {
            eletronicPointHistory.ModifiedAt = DateTime.Now;
            return await UpdateAsync(eletronicPointHistory.Id, eletronicPointHistory);
        }

        public Task<bool> DeleteHistoryAsync(EletronicPointHistory eletronicPointHistory) =>
            DeleteAsync(eletronicPointHistory);

        public async Task<bool> DeleteHistoryAsync(Guid id)
        {
            var entity = await ReadHistoryAsync(id);
            return entity is not null && await DeleteHistoryAsync(entity);
        }
    }
}