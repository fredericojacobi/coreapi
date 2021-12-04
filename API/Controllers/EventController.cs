using System;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
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
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public EventController(ILogger<EventController> logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var repositoryResult = _repository.Event.ReadAllEvents();
                return Ok(_mapper.Map<EventDTO>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAll)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var repositoryResult = _repository.Event.ReadEvent(id);
                return Ok(_mapper.Map<EventDTO>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }
        
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        /// "name": "string",
        /// "description": "string",
        /// "startDate": "2021-12-04T03:20:02.773Z",
        /// "endDate": "2021-12-04T03:20:02.773Z",
        /// "locationid": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        /// "branchid": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        /// "weatherForecast": "chuva",
        /// "isCovered": false
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult> Post(EventDTO model)
        {
            try
            {
                var eEvent = _mapper.Map<Event>(model);
                var repositoryResult = _repository.Event.CreateEvent(eEvent);
                return repositoryResult != null
                    ? Ok(_mapper.Map<EventDTO>(repositoryResult))
                    : StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] EventDTO model)
        {
            try
            {
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Event's id {id} doesn't match");
                    return BadRequest("Object's Ids doesn't match");
                }

                var eEvent = _mapper.Map<Event>(model);
                var repositoryResult = _repository.Event.UpdateEvent(eEvent);
                if (repositoryResult != null) return Ok(_mapper.Map<EventDTO>(repositoryResult));
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Event hasn't been updated.");
                return StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var repositoryResult = _repository.Event.DeleteEvent(id);
                if (repositoryResult)
                    return Ok(true);
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Event hasn't been removed");
                return StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}