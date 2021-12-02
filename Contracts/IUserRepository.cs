using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IList<User> ReadAllUsers();
        
        User ReadUser(Guid id);
        
        Task<User> CreateUser(User user, string password);
        
        Task<User> UpdateUser(User user);
        
        bool DeleteUser(User user);
        
        bool DeleteUser(Guid id);
    }
}