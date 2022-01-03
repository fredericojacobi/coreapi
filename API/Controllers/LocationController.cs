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
        public async Task<ActionResult> GetAll() => _service.Location.GetAll().ObjectResult;

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) => _service.Location.Get(id).ObjectResult;

        [HttpPost]
        public async Task<ActionResult> Post(LocationDTO model) => _service.Location.Post(model).ObjectResult;

        [RequestSizeLimit(9000000000000000000)]
        [HttpPost("multiple")]
        public async Task<ActionResult> Post(IEnumerable<LocationDTO> models) => _service.Location.PostMultiple(models).ObjectResult;

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] LocationDTO model) => _service.Location.Put(id, model).ObjectResult;

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) => _service.Location.Delete(id).ObjectResult;

        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAll() => _service.Location.DeleteAll().ObjectResult;
    }
}