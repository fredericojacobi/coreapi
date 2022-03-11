using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(AppDbContext context, UserManager<User> userManager) : base(context) =>
            _userManager = userManager;

        public async Task<IEnumerable<User>> ReadAllUsersAsync() => await ReadAllAsync();

        public async Task<User> ReadUserAsync(Guid id) => await _userManager.FindByIdAsync(id.ToString());

        public async Task<User> ReadUserByUserNameAsync(string username) =>
            await _userManager.FindByNameAsync(username);

        public async Task<User> CreateUserAsync(User user, string password)
        {
            user.CreatedAt = DateTime.Now;
            var identityResult = await _userManager.CreateAsync(user, password);
            return identityResult.Succeeded ? await ReadUserByUserNameAsync(user.UserName) : null;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            user.ModifiedAt = DateTime.Now;
            await _userManager.UpdateAsync(user);
            return await ReadUserAsync(user.Id);
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            var identityResult = await _userManager.DeleteAsync(user);
            return identityResult.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await ReadUserAsync(id);
            return await DeleteUserAsync(user);
        }
    }
}