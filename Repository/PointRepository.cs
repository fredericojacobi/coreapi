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

        public async Task<IEnumerable<Point>> ReadAllPointsAsync() => await ReadAllAsync(x => x.Branch);

        public async Task<Point> ReadPointAsync(Guid id)
        {
            var point = await ReadByConditionAsync(x => x.Id.Equals(id), x => x.Branch);
            return point.FirstOrDefault();
        }

        public async Task<Point> CreatePointAsync(Point point)
        {
            point.CreatedAt = DateTime.Now;
            return await CreateAsync(point);
        }

        public async Task<Point> UpdatePointAsync(Point point)
        {
            point.ModifiedAt = DateTime.Now;
            return await UpdateAsync(point.Id, point);
        }

        public async Task<bool> DeletePointAsync(Point point) => await DeleteAsync(point);

        public async Task<bool> DeletePointAsync(Guid id)
        {
            var entity = await ReadPointAsync(id);
            return await DeletePointAsync(entity);
        }
    }
}