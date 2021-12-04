using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class PointRepository : RepositoryBase<Point>, IPointRepository
    {

        public PointRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Point> ReadAllPoints() => ReadAll().ToList();

        public Point ReadPoint(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

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

        public bool DeletePoint(Guid id) => DeletePoint(ReadPoint(id));
        
    }
}