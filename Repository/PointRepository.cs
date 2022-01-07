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
    public class PointRepository : RepositoryBase<Point>, IPointRepository
    {

        public PointRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Point>> ReadAllPoints() => Task.FromResult<IEnumerable<Point>>(ReadAll().Include(x => x.Branch).ToList());

        public Task<Point> ReadPoint(Guid id) => Task.FromResult(ReadByCondition(x => x.Id.Equals(id))
            .Include(x => x.Branch)
            .FirstOrDefault());

        public Task<Point> CreatePoint(Point point)
        {
            point.CreatedAt = DateTime.Now;
            return Task.FromResult(Create(point));
        }

        public Task<Point> UpdatePoint(Point point)
        {
            point.ModifiedAt = DateTime.Now;
            return Task.FromResult(Update(point));
        }

        public Task<bool> DeletePoint(Point point) => Task.FromResult(Delete(point));

        public async Task<bool> DeletePoint(Guid id)
        {
            var entity = await ReadPoint(id);
            return await DeletePoint(entity);
        }
    }
}