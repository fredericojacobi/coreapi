using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private ILogger<ReminderController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ReminderController(ILogger<ReminderController> logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Reminder
        [HttpGet]
        public async Task<ActionResult> GetAllReminders()
        {
            try
            {
                var reminders = _repository.Reminder.GetAllReminders();
                return Ok(_mapper.Map<IEnumerable<ReminderDTO>>(reminders));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllReminders)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Reminder/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var reminder = _repository.Reminder.GetReminderById(id);
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
        
        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetByUserId(long id)
        {
            try
            {
                var reminder = _repository.Reminder.GetReminderByUserId(id);
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

        // PUT: api/Reminder/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ReminderDTO>> Put([FromRoute] long id, [FromBody] ReminderDTO model)
        {
            try
            {
                
                // TODO: quando model esta nulo ele nao entra no metodo, entao nao verifica
                // if (model == null)
                // {
                //     _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Reminder's model is null");
                //     return BadRequest("Object cannot be null");
                // }
                
                // TODO: nao verifica model valido
                // if (!ModelState.IsValid)
                // {
                //     _logger.LogError($"{DateTime.Now} - {nameof(Put)} :  Invalid Reminder's object sent from client");
                //     return BadRequest("Invalid model object");
                // }
                
                // validacao id != OK
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Reminder's id {id} doesn't match");
                    return BadRequest("Object's Ids doesn't match");
                }

                var reminder = _mapper.Map<Reminder>(model);
                var modified = _repository.Reminder.Update(reminder);
                if (modified)
                    return NoContent();
                
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Reminder hasn't been updated");
                return StatusCode(500, "Internal server error");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Reminder
        [HttpPost]
        public async Task<ActionResult<dynamic>> Post(ReminderDTO model)
        {
            try
            {
                if (model == null)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Post)} : Reminder's model is null");
                    return BadRequest("Object cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Post)} :  Invalid Reminder's object sent from client");
                    return BadRequest("Invalid model object");
                }
                var reminder = _mapper.Map<Reminder>(model);
                var repositoryResult = _repository.Reminder.Create(reminder);
                if(repositoryResult != null) return CreatedAtAction(nameof(Get), new { id = repositoryResult.Id }, repositoryResult);
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : Reminder hasn't been created");
                return StatusCode(500, "Internal server error");
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Reminder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id, [FromBody] ReminderDTO model)
        {
            try
            {
                if (model == null)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Reminder's model is null");
                    return BadRequest("Object cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Delete)} :  Invalid Reminder's object sent from client");
                    return BadRequest("Invalid model object");
                }
                
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Reminder's id {id} doesn't match");
                    return BadRequest("Object's Ids doesn't match");
                }

                var reminder = _mapper.Map<Reminder>(model);
                var removed = _repository.Reminder.Delete(reminder);
                if (removed)
                    return Ok();
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Reminder hasn't been removed");
                return StatusCode(500, "Internal server error");
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}