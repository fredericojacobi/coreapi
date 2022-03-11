using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IPointRepository : IRepositoryBase<Point>
    {
        Task<IEnumerable<Point>> ReadAllPointsAsync();

        Task<Point> ReadPointAsync(Guid id);

        Task<Point> CreatePointAsync(Point point);

        Task<Point> UpdatePointAsync(Point point);

        Task<bool> DeletePointAsync(Point point);

        Task<bool> DeletePointAsync(Guid id);
        
    }
}