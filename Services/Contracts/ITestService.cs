using System.Collections.Generic;
using Entities.Models;

namespace Services.Contracts
{
    public interface ITestService
    {
        List<Company> GetAll();
    }
}