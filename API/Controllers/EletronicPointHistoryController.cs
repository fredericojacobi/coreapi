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
        public async Task<ActionResult> GetAllHistories() => _service.UserPointHistory.GetAll().ObjectResult;

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] Guid id) => _service.UserPointHistory.Get(id).ObjectResult;
        // _logger.LogError(
        // $"{DateTime.Now} - {nameof(Get)} : EletronicPointHistory with id {id} hasn't been found in db.");

        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetByUserId([FromRoute] Guid userId) =>
            _service.UserPointHistory.GetDailyUserPointHistory(userId).ObjectResult;
        // _logger.LogError($"{DateTime.Now} - {nameof(GetByUserId)} : This user hasn't point histories.");

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EletronicPointHistoryDTO model) =>
            _service.UserPointHistory.Post(model).ObjectResult;

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] EletronicPointHistoryDTO model) =>
            _service.UserPointHistory.Put(id, model).ObjectResult;
        // _logger.LogError($"{DateTime.Now} - {nameof(Put)} : EletronicPointHistory hasn't been created");

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id) =>
            _service.UserPointHistory.Delete(id).ObjectResult;
        // _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : EletronicPointHistory hasn't been removed");
    }
}