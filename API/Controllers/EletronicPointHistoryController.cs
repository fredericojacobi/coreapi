using System;
using System.Threading.Tasks;
using Contracts;
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
        public async Task<ActionResult> GetAllHistories()
        {
            var returnRequest = _service.UserPointHistory.GetAll();
            return returnRequest.ObjectResult;
            // _logger.LogError($"{DateTime.Now} - {nameof(GetAllHistories)} : This user hasn't point histories.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var returnRequest = _service.UserPointHistory.Get(id);
            return returnRequest.ObjectResult;
            // _logger.LogError(
            // $"{DateTime.Now} - {nameof(Get)} : EletronicPointHistory with id {id} hasn't been found in db.");
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetByUserId(Guid userId)
        {
            var returnRequest = _service.UserPointHistory.GetDailyUserPointHistory(userId);
            return returnRequest.ObjectResult;
            // _logger.LogError($"{DateTime.Now} - {nameof(GetByUserId)} : This user hasn't point histories.");
        }

        [HttpPost]
        public async Task<ActionResult> Post(EletronicPointHistoryDTO model)
        {
            var returnRequest = _service.UserPointHistory.Post(model);
            return returnRequest.ObjectResult;
            // _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] EletronicPointHistoryDTO model)
        {
            var returnRequest = _service.UserPointHistory.Put(id, model);
            return returnRequest.ObjectResult;
            // _logger.LogError($"{DateTime.Now} - {nameof(Put)} : EletronicPointHistory hasn't been created");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var returnRequest = _service.UserPointHistory.Delete(id);
            return returnRequest.ObjectResult;
            // _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : EletronicPointHistory hasn't been removed");
        }
    }
}