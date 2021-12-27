using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ITestService
    {
        IList<Company> GetAll();
    }
}