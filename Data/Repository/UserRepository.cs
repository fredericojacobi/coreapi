using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.DTO;

namespace Data.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) => _context = context;

        public List<User> Get() => _context.Users.ToList();
        
        public User Get(long id) => _context.Users.FirstOrDefault(x =>
            x.Id.Equals(id));

        public async Task<User> Post(UserDTO model)
        {
            var user = new User
            {
                Name = model.Name,
                Username = model.Username,
                Password = model.Password,
                Role = model.Role
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            await _context.Entry(user).ReloadAsync();
            return user;
        }

        public User Login(UserDTO model) => _context.Users.FirstOrDefault(x =>
            x.Username.Equals(model.Username) && x.Password.Equals(model.Password));
    }
}