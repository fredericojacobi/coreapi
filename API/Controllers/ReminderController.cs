using System;
using System.Collections.Generic;
using System.Data.Common;
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
    public class ReminderController : ControllerBase
    {
        private readonly ILogger<ReminderController> _logger;
        private readonly IServiceWrapper _service;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ReminderController(ILogger<ReminderController> logger, IRepositoryWrapper repository, IServiceWrapper service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Reminder
        [HttpGet]
        public async Task<ActionResult> GetAllReminders()
        {
            try
            {
                var returnRequest = await _repository.Reminder.ReadAllAsync();
                return Ok(returnRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllReminders)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Reminder/5œ
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var reminder = _repository.Reminder.ReadReminderAsync(id);
                if (reminder != null) return Ok(_mapper.Map<ReminderDTO>(reminder));
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : Reminder with id {id} hasn't been found in db");
                return NotFound();
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Reminder
        [HttpPost]
        public async Task<ActionResult> Post(ReminderDTO model)
        {
            try
            {
                var reminder = _mapper.Map<Reminder>(model);
                var repositoryResult = _repository.Reminder.CreateReminderAsync(reminder);
                if(repositoryResult != null) return Ok(_mapper.Map<ReminderDTO>(repositoryResult));
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : Reminder hasn't been created");
                return StatusCode(500, "Internal server error");
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Reminder/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] ReminderDTO model)
        {
            try
            {
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Reminder's id {id} doesn't match");
                    return BadRequest("Object's Ids doesn't match");
                }
                var reminder = _mapper.Map<Reminder>(model);
                var repositoryResult = _repository.Reminder.UpdateReminderAsync(reminder);
                if (repositoryResult != null) return Ok(_mapper.Map<ReminderDTO>(repositoryResult));
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Reminder hasn't been updated.");
                return Ok(ResponseErrorMessage.InternalServerError("Internal server error. Reminder hasn't been updated."));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Reminder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)

        {
            try
            {
                var removed = await _repository.Reminder.DeleteReminderAsync(id);
                if (removed)
                    return Ok(true);
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Reminder hasn't been removed");
                return StatusCode(500, "Internal server error. Reminder hasn't been removed.");
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : {e.Message}");
                return StatusCode(500, "Internal server error. Reminder hasn't been removed.");
            }
        }
    }
}