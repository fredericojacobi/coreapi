using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Services
{
    public interface ITestService
    {
        Task<IEnumerable<Company>> GetAllAsync();
    }
}