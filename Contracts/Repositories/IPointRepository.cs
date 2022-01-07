using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IPointRepository : IRepositoryBase<Point>
    {
        Task<IEnumerable<Point>> ReadAllPoints();

        Task<Point> ReadPoint(Guid id);

        Task<Point> CreatePoint(Point point);

        Task<Point> UpdatePoint(Point point);

        Task<bool >DeletePoint(Point point);

        Task<bool >DeletePoint(Guid id);
        
    }
}