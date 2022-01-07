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

        public UserRepository(AppDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public Task<IEnumerable<User>> ReadAllUsers() => Task.FromResult<IEnumerable<User>>(ReadAll().OrderBy(x => x.Id).ToList());

        public async Task<User> ReadUser(Guid id) => await _userManager.FindByIdAsync(id.ToString());

        public async Task<User> ReadUserByUserName(string username) => await _userManager.FindByNameAsync(username);
        
        public async Task<User> CreateUser(User user, string password)
        {
            user.CreatedAt = DateTime.Now;
            var identityResult = await _userManager.CreateAsync(user, password);
            return identityResult.Succeeded ? await ReadUserByUserName(user.UserName) : null;
        }

        public Task<User> UpdateUser(User user)
        {
            user.ModifiedAt = DateTime.Now;
            return Task.FromResult(Update(user));
        }

        public async Task<bool> DeleteUser(User user)
        {
            var identityResult = await _userManager.DeleteAsync(user);
            return identityResult.Succeeded;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await ReadUser(id);
            return await DeleteUser(user);
        }
    }
}