using System.Data.Common;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(AppDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /*
            [HttpPost]
            [Route("signup")]
            [AllowAnonymous]
            public async Task<ActionResult<UserDTO>> SignUp([FromBody] UserDTO model)
            {
                try
                {
                    var user = _repo
                    if (user == null)
                        return UnprocessableEntity(new { message = "One or more fields are missing" });
                    return Content(JsonConvert.SerializeObject(user));
                }
                catch (DbException e)
                {
                    return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
                }
            }
    */
        //TODO: retornar dados do usuario ao cadastrar
        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Signup([FromBody] UserDTO model)
        {
            try
            {
                var user = new IdentityUser { UserName = model.Username};
                var result = _userManager.CreateAsync(user, model.Password);
                if (!result.Result.Succeeded) return Ok("nao foi");
                await _signInManager.SignInAsync(user, isPersistent: false);
                // var userid = _signInManager.UserManager.GetUserId();
                return Ok();

                // return NotFound(new { message = "Invalid username or password" });
                // var token = TokenService.GenerateToken(user);
                // user.Password = null;
                // return new
                // {
                // user = user,
                // token = token
                // };
            }
            catch (DbException e)
            {
                return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
            }
        }
/*
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
    */
    }
}