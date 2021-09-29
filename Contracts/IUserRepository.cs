using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public IEnumerable<User> GetAllUsers();

        public User GetUserById(long id);

        public User GetUserByUsername(string username);

        public User UpdatePassword(User user);
    }
}