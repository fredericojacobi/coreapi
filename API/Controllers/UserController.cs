using System;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects;
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
        public async Task<ActionResult> GetAllUsers()
        {
            var returnRequest = await _service.User.GetAllAsync();
            return returnRequest.ObjectResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser([FromRoute] Guid id)
        {
            var returnRequest = await _service.User.GetAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] UserDTO model)
        {
            var returnRequest = await _service.User.PostAsync(model);
            return returnRequest.ObjectResult;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserDTO model)
        {
            var returnRequest = await _service.User.PutAsync(id, model);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] Guid id)
        {
            var returnRequest = await _service.User.DeleteAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("all")]
        public ActionResult DeleteAllUsers() => throw new NotImplementedException();
    }
}