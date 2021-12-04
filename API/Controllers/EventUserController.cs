using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventUserController : ControllerBase
    {
        private readonly ILogger<EventUserController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public EventUserController(ILogger<EventUserController> logger, IRepositoryWrapper repository, IMapper mapper)
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
                var repositoryResult = _repository.EventUser.ReadAllEventUsers();
                return Ok(_mapper.Map<List<EventUserDTO>>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllByUserId)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var repositoryResult = _repository.EventUser.ReadEventUser(id);
                return Ok(_mapper.Map<EventUserDTO>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllByUserId)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError());
            }
        }

        //TODO: criar metodo proprio para retornar byUserId
        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetAllByUserId(Guid id)
        {
            try
            {
                var repositoryResult = _repository.EventUser.ReadByCondition(x => x.UserId.Equals(id)).ToList();
                return Ok(_mapper.Map<List<EventUserDTO>>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllByUserId)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError());
            }
        }

        //TODO: criar metodo proprio para retornar byEventId
        [HttpGet("event/{id}")]
        public async Task<ActionResult> GetAllByEventId(Guid id)
        {
            try
            {
                var repositoryResult = _repository.EventUser.ReadByCondition(x => x.EventId.Equals(id)).ToList();
                return Ok(_mapper.Map<List<EventUserDTO>>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllByEventId)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError());
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(EventUserDTO model)
        {
            try
            {
                var eventUser = _mapper.Map<EventUser>(model);
                var repositoryResult = _repository.EventUser.CreateEventUser(eventUser);
                return repositoryResult != null
                    ? Ok(_mapper.Map<EventUserDTO>(repositoryResult))
                    : StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] EventUserDTO model)
        {
            try
            {
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : EventUser's id {id} doesn't match");
                    return BadRequest("Object's Ids doesn't match");
                }

                var eventUser = _mapper.Map<EventUser>(model);
                var repositoryResult = _repository.EventUser.UpdateEventUser(eventUser);
                if (repositoryResult != null) return Ok(_mapper.Map<EventUserDTO>(repositoryResult));
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : EventUser hasn't been updated.");
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
                var repositoryResult = _repository.EventUser.DeleteEventUser(id);
                if (repositoryResult)
                    return Ok();
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : EventUser hasn't been removed");
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