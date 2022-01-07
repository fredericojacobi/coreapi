using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> ReadAllUsers();
        
        Task<User> ReadUser(Guid id);
        
        Task<User> ReadUserByUserName(string username);
        
        Task<User> CreateUser(User user, string password);
        
        Task<User> UpdateUser(User user);
        
        Task<bool> DeleteUser(User user);
        
        Task<bool> DeleteUser(Guid id);
    }
}