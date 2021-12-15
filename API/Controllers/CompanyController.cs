using System;
using System.Collections.Generic;
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
    public class CompanyController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger<CompanyController> _logger;
        private readonly IMapper _mapper;

        public CompanyController(IRepositoryWrapper repository, ILogger<CompanyController> logger, IMapper mapper)
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
                var repositoryResult = _repository.Company.ReadAllCompanies();
                return Ok(_mapper.Map<List<CompanyDTO>>(repositoryResult));
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
                var repositoryResult = _repository.Company.ReadCompany(id);
                return Ok(_mapper.Map<CompanyDTO>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(CompanyDTO model)
        {
            try
            {
                var company = _mapper.Map<Company>(model);
                var repositoryResult = _repository.Company.CreateCompany(company);
                return repositoryResult != null
                    ? Ok(_mapper.Map<CompanyDTO>(repositoryResult))
                    : StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] CompanyDTO model)
        {
            try
            {
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Company's id {id} doesn't match.");
                    return BadRequest("Object's Ids doesn't match.");
                }

                var company = _mapper.Map<Company>(model);
                var repositoryResult = _repository.Company.UpdateCompany(company);
                if (repositoryResult != null) return Ok(_mapper.Map<CompanyDTO>(repositoryResult));
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Company hasn't been updated.");
                return StatusCode(500, "Internal server error.");
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
                var repositoryResult = _repository.Company.DeleteCompany(id);
                if (repositoryResult)
                    return Ok(true);
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Company hasn't been deleted.");
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
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAll)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
        
        [HttpPost("random")]
        public async Task<ActionResult> CreateRandomCompany() => Ok(new Company {Name = Generic.Functions.Random.Name(15)});
        
    }
}