using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
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
                var usersResult = _repository.User.ReadAllUsers();
                return Ok(usersResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllUsers)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetAllUsers)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(Guid id)
        {
            try
            {
                var usersResult = _repository.User.ReadUser(id);
                return Ok(usersResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetUser)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetUser)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        
        [HttpPost]
        public async Task<ActionResult> PostUser(User model)
        {
            try
            {
                // var eletronicPointHistory = _mapper.Map<EletronicPointHistory>(model);
                // var repositoryResult = _repository.EletronicPointHistory.CreateHistory(eletronicPointHistory);
                // if(repositoryResult != null) return Ok(_mapper.Map<EletronicPointHistoryDTO>(repositoryResult));
                
                // await _userManager.CreateAsync(model, "frederico");
                var userResult = _repository.User.CreateUser(model, model.Password).Result;
                
                // var userId = await _userManager.GetUserIdAsync(model);
                return Ok(userResult);
                // _logger.LogError($"{DateTime.Now} - {nameof(Post)} : Reminder hasn't been created");
                // return StatusCode(500, ResponseErrorMessage.InternalServerError());
                // return StatusCode(500, "Internal server error");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostUser)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostUser)} : {e.Message}\n{e.InnerException}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User model)
        {
            try
            {
                var userResult = _repository.User.UpdateUser(model).Result;
                return Ok(userResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(UpdateUser)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(UpdateUser)} : {e.Message}\n{e.InnerException}");
            }
        }

        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAllUsers()
        {
            try
            {
                var usersResult = _repository.User.ReadAllUsers();
                bool ok = false;
                foreach (var user in usersResult)
                {
                    ok = _repository.User.DeleteUser(user);
                }
                return Ok(ok);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(DeleteAllUsers)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(DeleteAllUsers)} : {e.Message}\n{e.InnerException}");
            }
        }
    }
}