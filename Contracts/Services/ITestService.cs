using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Services
{
    public interface ITestService
    {
        IEnumerable<Company> GetAll();
    }
}