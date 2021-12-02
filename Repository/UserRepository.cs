using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts;
using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private UserManager<User> _userManager;

        public UserRepository(AppDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public IList<User> ReadAllUsers() => ReadAll().OrderBy(x => x.Id).ToList();

        public User ReadUser(Guid id) => ReadByCondition(x => x.Id.Equals(id))
            .Include(x => x.Branch)
            .Include(x => x.Reminders)
            .Include(x => x.EventUsers)
            .Include(x => x.EletronicPointHistories)
            .FirstOrDefault();
        
        public async Task<User> CreateUser(User user, string password)
        {
            user.CreatedAt = DateTime.Now;
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded ? _userManager.FindByNameAsync(user.UserName).Result : null;
        }

        public async Task<User> UpdateUser(User user)
        {
            user.ModifiedAt = DateTime.Now;
            await _userManager.UpdateAsync(user);
            var id = _userManager.GetUserIdAsync(user).Result;
            return ReadUser(new Guid(id));
        }

        public bool DeleteUser(User user) => Delete(user);

        public bool DeleteUser(Guid id) => DeleteUser(ReadUser(id));
    }
}