using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IPointRepository : IRepositoryBase<Point>
    {
        IList<Point> ReadAllPoints();

        Point ReadPoint(Guid id);

        Point CreatePoint(Point point);

        Point UpdatePoint(Point point);

        bool DeletePoint(Point point);

        bool DeletePoint(Guid id);
        
    }
}