using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> ReadAllUsersAsync();
        
        Task<User> ReadUserAsync(Guid id);
        
        Task<User> ReadUserByUserNameAsync(string username);
        
        Task<User> CreateUserAsync(User user, string password);
        
        Task<User> UpdateUserAsync(User user);
        
        Task<bool> DeleteUserAsync(User user);
        
        Task<bool> DeleteUserAsync(Guid id);
    }
}