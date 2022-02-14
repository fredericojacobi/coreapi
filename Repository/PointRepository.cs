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

        public async Task<IEnumerable<Point>> ReadAllPoints() => await Task.FromResult<IEnumerable<Point>>(ReadAll()
                .Include(x => x.Branch)
                .ToList());

        public async Task<Point> ReadPoint(Guid id) => await Task.FromResult(ReadByCondition(x => x.Id.Equals(id))
            .Include(x => x.Branch)
            .FirstOrDefault());

        public async Task<Point> CreatePoint(Point point)
        {
            point.CreatedAt = DateTime.Now;
            return await Task.FromResult(Create(point));
        }

        public async Task<Point> UpdatePoint(Point point)
        {
            point.ModifiedAt = DateTime.Now;
            return await Task.FromResult(Update(point));
        }

        public async Task<bool> DeletePoint(Point point) => await Task.FromResult(Delete(point));

        public async Task<bool> DeletePoint(Guid id)
        {
            var entity = await ReadPoint(id);
            return await DeletePoint(entity);
        }
    }
}