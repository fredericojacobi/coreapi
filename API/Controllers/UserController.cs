using System;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IServiceWrapper _service;

        public UserController(ILogger<UserController> logger, IServiceWrapper service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAllUsers() => _service.User.GetAll().ObjectResult;

        [HttpGet("{id}")]
        public ActionResult GetUser([FromRoute] Guid id) => _service.User.Get(id).ObjectResult;

        [HttpPost]
        public ActionResult PostUser([FromBody] UserDTO model) => _service.User.Post(model).ObjectResult;

        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute] Guid id, [FromBody] UserDTO model) => _service.User.Put(id, model).ObjectResult;

        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute] Guid id) => _service.User.Delete(id).ObjectResult;

        [HttpDelete("all")]
        public ActionResult DeleteAllUsers() => throw new NotImplementedException();
    }
}