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

        public IEnumerable<User> ReadAllUsers() => ReadAll().OrderBy(x => x.Id).ToList();

        public User ReadUser(Guid id) => ReadByCondition(x => x.Id.Equals(id))
            .Include(x => x.Branch)
            .Include(x => x.Reminders)
            .Include(x => x.EventUsers)
            .Include(x => x.EletronicPointHistories)
            .FirstOrDefault();

        public async Task<User> ReadUserByUserName(string username) => await _userManager.FindByNameAsync(username);
        
        public async Task<IdentityResult> CreateUser(User user, string password)
        {
            user.CreatedAt = DateTime.Now;
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> UpdateUser(User user)
        {
            user.ModifiedAt = DateTime.Now;
            return await _userManager.UpdateAsync(user); 
        }

        public bool DeleteUser(User user) => Delete(user);

        public bool DeleteUser(Guid id)
        {
            var entity = ReadUser(id);
            return entity is not null && DeleteUser(entity);
        }
    }
}