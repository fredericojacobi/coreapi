using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<User> GetAllUsers() => FindAll().OrderBy(u => u.Id).Include(u => u.Reminders).ToList();

        public User GetUserById(long id) => FindByCondition(u => u.Id.Equals(id)).Include(u => u.Reminders).FirstOrDefault();

        public User GetUserByUsername(string username) =>
            FindByCondition(u => u.Username.ToLower().Equals(username.ToLower())).Include(u => u.Reminders).FirstOrDefault();

        public User UpdatePassword(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}