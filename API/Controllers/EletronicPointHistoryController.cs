using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EletronicPointHistoryController : ControllerBase
    {
        private readonly ILogger<EletronicPointHistoryController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public EletronicPointHistoryController(ILogger<EletronicPointHistoryController> logger, IRepositoryWrapper repository, IMapper mapper, UserManager<User> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHistories()
        {
            try
            {
                var histories = _repository.EletronicPointHistory.ReadAllHistories();
                return Ok(_mapper.Map<List<EletronicPointHistoryDTO>>(histories));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllHistories)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError());
            }
        }
        //
        // [HttpGet("{id}")]
        // public async Task<ActionResult> Get(Guid id)
        // {
        //     try
        //     {
        //         var reminder = _repository.Reminder.ReadReminder(id);
        //         if (reminder != null) return Ok(_mapper.Map<ReminderDTO>(reminder));
        //         _logger.LogError($"{DateTime.Now} - {nameof(Get)} : Reminder with id {id} hasn't been found in db");
        //         return NotFound();
        //     }
        //     catch (DbException e)
        //     {
        //         _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
        //         return StatusCode(500, "Internal server error");
        //     }
        // }
        //
        // [HttpGet("user/{id}")]
        // public async Task<ActionResult> GetByUserId(Guid id)
        // {
        //     try
        //     {
        //         return StatusCode(503, "Under maintenance.");
        //         /*
        //         var reminder = _repository.Reminder.ReadRemindersByUserId(id);
        //         if (reminder != null) return Ok(_mapper.Map<List<ReminderDTO>>(reminder));
        //         _logger.LogError($"{DateTime.Now} - {nameof(Get)} : Reminder with id {id} hasn't been found in db");
        //         return NotFound();
        //         */
        //     }
        //     catch (DbException e)
        //     {
        //         _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
        //         return StatusCode(500, "Internal server error");
        //     }
        // }
        //
        // [HttpPut("{id}")]
        // public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] ReminderDTO model)
        // {
        //     try
        //     {
        //         if (id != model.Id)
        //         {
        //             _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Reminder's id {id} doesn't match");
        //             return BadRequest("Object's Ids doesn't match");
        //         }
        //         var reminder = _mapper.Map<Reminder>(model);
        //         var repositoryResult = _repository.Reminder.Update(reminder);
        //         if(repositoryResult != null) return Ok(_mapper.Map<ReminderDTO>(repositoryResult));
        //         _logger.LogError($"{DateTime.Now} - {nameof(Post)} : Reminder hasn't been created");
        //         return StatusCode(500, "Internal server error");
        //     }
        //     catch (Exception e)
        //     {
        //         _logger.LogError($"{DateTime.Now} - {nameof(Put)} : {e.Message}");
        //         return StatusCode(500, "Internal server error");
        //     }
        // }
        //
        
        [HttpPost]
        public async Task<ActionResult> Post(EletronicPointHistoryDTO model)
        {
            try
            {
                // var eletronicPointHistory = _mapper.Map<EletronicPointHistory>(model);
                // var repositoryResult = _repository.EletronicPointHistory.CreateHistory(eletronicPointHistory);
                // if(repositoryResult != null) return Ok(_mapper.Map<EletronicPointHistoryDTO>(repositoryResult));
                // var user = new User
                // {
                    // UserName = "fredvj",
                    // Email = "fredvjacobi@gmail.com",
                    // EmailConfirmed = true,
                    // PhoneNumber = "997522673",
                    // CreatedAt = DateTime.Now
                // };
                // await _userManager.CreateAsync(user, "frederico");
                // var userId = await _userManager.GetUserIdAsync(user);
                // return Ok(userId);
                // _logger.LogError($"{DateTime.Now} - {nameof(Post)} : Reminder hasn't been created");
                return StatusCode(500, ResponseErrorMessage.InternalServerError());
                return StatusCode(500, "Internal server error");
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        // [HttpDelete("{id}")]
        // public async Task<ActionResult> Delete([FromRoute] Guid id, [FromBody] ReminderDTO model)
        // {
        //     try
        //     {
        //         if (id != model.Id)
        //         {
        //             _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Reminder's id {id} doesn't match");
        //             return BadRequest("Object's Ids doesn't match");
        //         }
        //         var reminder = _mapper.Map<Reminder>(model);
        //         var removed = _repository.Reminder.Delete(reminder);
        //         if (removed)
        //             return Ok();
        //         _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Reminder hasn't been removed");
        //         return StatusCode(500, "Internal server error");
        //     }
        //     catch (DbException e)
        //     {
        //         _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : {e.Message}");
        //         return StatusCode(500, "Internal server error");
        //     }
        // }
    }
}