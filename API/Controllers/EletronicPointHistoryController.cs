using System;
using System.Threading.Tasks;
using Contracts;
using Contracts.Services;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EletronicPointHistoryController : ControllerBase
    {
        private readonly ILogger<EletronicPointHistoryController> _logger;
        private readonly IServiceWrapper _service;

        public EletronicPointHistoryController(ILogger<EletronicPointHistoryController> logger, IServiceWrapper service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHistoriesAsync()
        {
            var returnRequest = await _service.UserPointHistory.GetAllAsync();
            return returnRequest.ObjectResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync([FromRoute] Guid id)
        {
            var returnRequest = await _service.UserPointHistory.GetAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetByUserIdAsync([FromRoute] Guid userId, [FromRoute] DateTime day)
        {
            var returnRequest = await _service.UserPointHistory.GetDailyUserPointHistoryAsync(userId, day);
            return returnRequest.ObjectResult;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] EletronicPointHistoryDTO model)
        {
            var returnRequest = await _service.UserPointHistory.PostAsync(model);
            return returnRequest.ObjectResult;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] EletronicPointHistoryDTO model)
        {
            var returnRequest = await _service.UserPointHistory.PutAsync(id, model);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var returnRequest = await _service.UserPointHistory.DeleteAsync(id);
            return returnRequest.ObjectResult;
        }
    }
}