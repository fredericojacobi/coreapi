using System;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
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
        public async Task<ActionResult> GetAll() => _service.Event.GetAll().ObjectResult;

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) => _service.Event.Get(id).ObjectResult;

        [HttpPost]
        public async Task<ActionResult> Post(EventDTO model) => _service.Event.Post(model).ObjectResult;

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] EventDTO model) =>
            _service.Event.Put(id, model).ObjectResult;

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id) => _service.Event.Delete(id).ObjectResult;
    }
}