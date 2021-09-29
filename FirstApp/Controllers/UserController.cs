using System;
using System.Collections;
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
    public class UserController : ControllerBase
    {
        private ILogger<ReminderController> _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public UserController(ILogger<ReminderController> logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Reminder
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var user = _repository.User.GetAllUsers();
                return Ok(_mapper.Map<IEnumerable<UserDTO>>(user));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllUsers)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);
                if (user != null) return Ok(_mapper.Map<UserDTO>(user));
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : User with id {id} hasn't been found in db");
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("username")]
        public async Task<ActionResult> Get([FromBody] UserDTO model)
        {
            try
            {
                var user = _repository.User.GetUserByUsername(model.Username);
                if (user != null) return Ok(_mapper.Map<UserDTO>(user));
                _logger.LogError(
                    $"{DateTime.Now} - {nameof(Get)} : User with username {model.Username} hasn't been found in db");
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReminderDTO>> Put([FromRoute] long id, [FromBody] UserDTO model)
        {
            try
            {
                // if (model == null)
                // {
                //     _logger.LogError($"{DateTime.Now} - {nameof(Put)} : User's model is null");
                //     return BadRequest("Object cannot be null");
                // }

                // if (!ModelState.IsValid)
                // {
                //     _logger.LogError($"{DateTime.Now} - {nameof(Put)} :  Invalid User's object sent from client");
                //     return BadRequest("Invalid model object");
                // }

                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : User's id {id} doesn't match");
                    return BadRequest("Object's Ids doesn't match");
                }

                var user = _mapper.Map<User>(model);
                var modified = _repository.User.Update(user);
                if (modified) return NoContent();
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : User hasn't been updated");
                return StatusCode(500, "Internal server error");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id, [FromBody] UserDTO model)
        {
            try
            {
                // if (model == null)
                // {
                //     _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : User's model is null");
                //     return BadRequest("Object cannot be null");
                // }
                //
                // if (!ModelState.IsValid)
                // {
                //     _logger.LogError($"{DateTime.Now} - {nameof(Delete)} :  Invalid User's object sent from client");
                //     return BadRequest("Invalid model object");
                // }

                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : User's id {id} doesn't match");
                    return BadRequest("Object's Ids doesn't match");
                }

                var user = _mapper.Map<User>(model);
                var removed = _repository.User.Delete(user);
                if (removed)
                    return Ok();
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : User hasn't been removed");
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