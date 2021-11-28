using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IList<User> ReadAllUsers();
        
        User ReadUser(Guid id);
        
        User CreateUser(User user);
        
        User UpdateUser(User user);
        
        bool DeleteUser(User user);
        
        bool DeleteUser(Guid id);
    }
}