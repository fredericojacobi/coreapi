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
    public class PointRepository : RepositoryBase<Point>, IPointRepository
    {

        public PointRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Point> ReadAllPoints() => ReadAll().Include(x => x.Branch).ToList();

        public Point ReadPoint(Guid id) => ReadByCondition(x => x.Id.Equals(id))
            .Include(x => x.Branch)
            .FirstOrDefault();

        public Point CreatePoint(Point point)
        {
            point.CreatedAt = DateTime.Now;
            return Create(point);
        }

        public Point UpdatePoint(Point point)
        {
            point.ModifiedAt = DateTime.Now;
            return Update(point);
        }

        public bool DeletePoint(Point point) => Delete(point);

        public bool DeletePoint(Guid id)
        {
            var entity = ReadPoint(id);
            return entity is not null && DeletePoint(entity);
        }
    }
}