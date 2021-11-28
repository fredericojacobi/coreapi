using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public IList<User> ReadAllUsers() => ReadAll().OrderBy(x => x.Id).ToList();

        public User ReadUser(Guid id) => ReadByCondition(x => x.Id.Equals(id)).FirstOrDefault();

        public User CreateUser(User user) => Create(user);

        public User UpdateUser(User user) => Update(user);

        public bool DeleteUser(User user) => Delete(user);

        public bool DeleteUser(Guid id) => DeleteUser(ReadUser(id));
    }
}