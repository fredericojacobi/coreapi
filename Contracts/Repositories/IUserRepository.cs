using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> ReadAllUsers();
        
        User ReadUser(Guid id);
        
        Task<User> ReadUserByUserName(string username);
        
        Task<IdentityResult> CreateUser(User user, string password);
        
        Task<IdentityResult> UpdateUser(User user);
        
        bool DeleteUser(User user);
        
        bool DeleteUser(Guid id);
    }
}