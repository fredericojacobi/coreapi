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

        public EletronicPointHistoryController(ILogger<EletronicPointHistoryController> logger,
            IRepositoryWrapper repository, IMapper mapper)
        {
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

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var repositoryResult = _repository.EletronicPointHistory.ReadHistory(id);
                if (repositoryResult != null) return Ok(_mapper.Map<EletronicPointHistoryDTO>(repositoryResult));
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : EletronicPointHistory with id {id} hasn't been found in db.");
                return NotFound();
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(EletronicPointHistoryDTO model)
        {
            try
            {
                var history = _mapper.Map<EletronicPointHistory>(model);
                var repositoryResult = _repository.EletronicPointHistory.CreateHistory(history);
                return repositoryResult != null
                    ? Ok(_mapper.Map<EletronicPointHistoryDTO>(repositoryResult))
                    : StatusCode(500, "Internal server error.");
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] EletronicPointHistoryDTO model)
        {
            try
            {
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : EletronicPointHistory's id {id} doesn't match");
                    return BadRequest("Object's Ids doesn't match");
                }
                var history = _mapper.Map<EletronicPointHistory>(model);
                var repositoryResult = _repository.EletronicPointHistory.UpdateHistory(history);
                if(repositoryResult != null) return Ok(_mapper.Map<EletronicPointHistoryDTO>(repositoryResult));
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : EletronicPointHistory hasn't been created");
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
                var repositoryResult = _repository.EletronicPointHistory.DeleteHistory(id); 
                if (repositoryResult)
                    return Ok();
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : EletronicPointHistory hasn't been removed");
                return StatusCode(500, "Internal server error.");
            }
            catch (DbException e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}