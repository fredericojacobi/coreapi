using System.Collections.Generic;
using Entities.Models;

namespace Services.Contracts
{
    public interface ITestService
    {
        IList<Company> GetAll();
    }
}