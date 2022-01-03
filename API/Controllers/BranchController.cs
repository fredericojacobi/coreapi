using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Contracts.Repositories;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public BranchController(ILogger<BranchController> logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var repositoryResult = _repository.Branch.ReadAllBranches();
                return Ok(_mapper.Map<IEnumerable<BranchDTO>>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAll)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var repositoryResult = _repository.Branch.ReadBranch(id);
                return Ok(_mapper.Map<BranchDTO>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("company/{id}")]
        public async Task<ActionResult> GetByCompanyId(Guid id)
        {
            try
            {
                var repositoryResult = _repository.Branch.ReadBranchByCompanyId(id);
                return Ok(_mapper.Map<IEnumerable<BranchDTO>>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(BranchDTO model)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Invalid body.");
            try
            {
                var branch = _mapper.Map<Branch>(model);
                var repositoryResult = _repository.Branch.CreateBranch(branch);
                return repositoryResult != null
                    ? Ok(_mapper.Map<BranchDTO>(repositoryResult))
                    : StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] BranchDTO model)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Invalid body.");
            try
            {
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Branch's id {id} doesn't match.");
                    return BadRequest("Object's Ids doesn't match.");
                }

                var branch = _mapper.Map<Branch>(model); 
                var repositoryResult = _repository.Branch.UpdateBranch(branch);
                return repositoryResult != null 
                    ? Ok(_mapper.Map<BranchDTO>(repositoryResult))
                    : StatusCode(500, "Internal server error.");
                // _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Branch hasn't been updated.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var repositoryResult = _repository.Branch.DeleteBranch(id);
                if (repositoryResult)
                    return Ok(true);
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Branch hasn't been deleted.");
                return StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAll()
        {
            try
            {
                return StatusCode((int) HttpStatusCode.ServiceUnavailable, "Under maintenance.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAll)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}