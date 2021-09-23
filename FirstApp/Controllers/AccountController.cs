using System.Data.Common;
using System.Threading.Tasks;
using Data;
using Data.Repository;
using Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Newtonsoft.Json;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context) => _context = context;

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> SignUp([FromBody] UserDTO model)
        {
            try
            {
                var user = new UserRepository(_context).Post(model).Result;
                if (user == null)
                    return UnprocessableEntity(new { message = "One or more fields are missing" });
                return Content(JsonConvert.SerializeObject(user));
            }
            catch (DbException e)
            {
                return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] UserDTO model)
        {
            try
            {
                var user = new UserRepository(_context).Login(model);
                if (user == null)
                    return NotFound(new { message = "Invalid username or password" });
                var token = TokenService.GenerateToken(user);
                user.Password = null;
                return new
                {
                    user = user,
                    token = token
                };
            }
            catch (DbException e)
            {
                return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
            }
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anonymous";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Authenticated - {User.Identity?.Name}";

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Employee";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Manager";
    }
}