using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly IServiceWrapper _service;

        public LocationController(ILogger<LocationController> logger, IServiceWrapper service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var returnRequest = await _service.Location.GetAllAsync();
            return returnRequest.ObjectResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            var returnRequest = await _service.Location.GetAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LocationDTO model)
        {
            var returnRequest = await _service.Location.PostAsync(model);
            return returnRequest.ObjectResult;
        }

        [RequestSizeLimit(9000000000000000000)]
        [HttpPost("multiple")]
        public async Task<ActionResult> Post([FromBody] IEnumerable<LocationDTO> models)
        {
            var returnRequest = await _service.Location.PostMultipleAsync(models);
            return returnRequest.ObjectResult;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] LocationDTO model)
        {
            var returnRequest = await _service.Location.PutAsync(id, model);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var returnRequest = await _service.Location.DeleteAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("multiple/{quantity}")]
        public async Task<ActionResult> DeleteAll([FromRoute] int quantity)
        {
            var returnRequest = await _service.Location.DeleteAllAsync(quantity);
            return returnRequest.ObjectResult;
        }
    }
}