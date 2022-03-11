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
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IServiceWrapper _service;

        public EventController(ILogger<EventController> logger, IServiceWrapper service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var returnRequest = await _service.Event.GetAllAsync();
            return returnRequest.ObjectResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            var returnRequest = await _service.Event.GetAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetAllByUserId([FromRoute] Guid id)
        {
            var returnRequest = await _service.Event.GetAllByUserIdAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EventDTO model)
        {
            var returnRequest = await _service.Event.PostAsync(model);
            return returnRequest.ObjectResult;
        }

        [HttpPost("join")]
        public async Task<ActionResult> Post([FromBody] EventUserDTO model)
        {
            var returnRequest = await _service.Event.PostJoinUserAsync(model);
            return returnRequest.ObjectResult;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] EventDTO model)
        {
            var returnRequest = await _service.Event.PutAsync(id, model);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var returnRequest = await _service.Event.DeleteAsync(id);
            return returnRequest.ObjectResult;
        }
    }
}