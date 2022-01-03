using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Contracts.Repositories;
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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var repositoryResult = _repository.User.ReadAllUsers();
                return Ok(_mapper.Map<IEnumerable<UserDTO>>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllUsers)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(Guid id)
        {
            try
            {
                var repositoryResult = _repository.User.ReadUser(id);
                return Ok(_mapper.Map<UserDTO>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetUser)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }


        [HttpPost]
        public async Task<ActionResult> PostUser(UserDTO model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                var repositoryResult = _repository.User.CreateUser(user, user.Password).Result;
                if (!repositoryResult.Succeeded) return StatusCode(500, "Internal server error.");
                var userResult = await _repository.User.ReadUserByUserName(model.UserName);
                return Ok(_mapper.Map<UserDTO>(userResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostUser)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserDTO model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                var repositoryResult = _repository.User.UpdateUser(user).Result;
                if (!repositoryResult.Succeeded) return StatusCode(500, "Internal server error.");
                var userResult = await _repository.User.ReadUserByUserName(model.UserName);
                return Ok(_mapper.Map<UserDTO>(userResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(UpdateUser)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            try
            {
                return Ok(_repository.User.DeleteUser(id));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(DeleteUser)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }

        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAllUsers()
        {
            try
            {
                var usersResult = _repository.User.ReadAllUsers();
                var ok = false;
                foreach (var user in usersResult)
                {
                    ok = _repository.User.DeleteUser(user);
                }

                return Ok(ok);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(DeleteAllUsers)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }
    }
}