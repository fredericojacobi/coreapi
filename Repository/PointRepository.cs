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

        public Point CreatePoint(Point point) => Create(point);

        public Point UpdatePoint(Point point) => Update(point);

        public bool DeletePoint(Point point) => Delete(point);

        public bool DeletePoint(Guid id) => DeletePoint(ReadPoint(id));
        
    }
}