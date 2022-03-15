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
    public class ReminderController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<ReminderController> _logger;

        public ReminderController(ILogger<ReminderController> logger, IServiceWrapper service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var returnRequest = await _service.Reminder.GetAllAsync();
            return returnRequest.ObjectResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var returnRequest = await _service.Reminder.GetAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ReminderDTO model)
        {
            var returnRequest = await _service.Reminder.PostAsync(model);
            return returnRequest.ObjectResult;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] ReminderDTO model)
        {
            var returnRequest = await _service.Reminder.PutAsync(id, model);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var returnRequest = await _service.Reminder.DeleteAsync(id);
            return returnRequest.ObjectResult;
        }
    }
}