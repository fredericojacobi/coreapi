using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _service;
        
        public TestController(ILogger<TestController> logger, IRepositoryWrapper repository, IMapper mapper, IServiceWrapper service)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("service")]
        public async Task<ActionResult> GetService()
        {
            try
            {
                var result = _service.Test.GetAll();
                return Ok("Service result: \n" + result);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetService)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetService)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpGet("company/{id}")]
        public async Task<ActionResult> GetCompany(Guid id)
        {
            try
            {
                var companyResult = _repository.Company.ReadCompany(id);
                return Ok(companyResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetCompany)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetCompany)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpGet("company")]
        public async Task<ActionResult> GetAllCompanies()
        {
            try
            {
                var listCompanies = _repository.Company.ReadAllCompanies();
                return Ok(listCompanies);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllCompanies)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetAllCompanies)} : {e.Message}\n{e.InnerException}");
            }
        }

        [HttpPost("company")]
        public async Task<ActionResult> PostCompany(Company model)
        {
            try
            {
                var companyResult = _repository.Company.CreateCompany(model);
                return Ok(companyResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostCompany)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostCompany)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpGet("branch")]
        public async Task<ActionResult> GetAllBranches()
        {
            try
            {
                var listBranches = _repository.Branch.ReadAllBranches();
                return Ok(listBranches);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllBranches)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetAllBranches)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpPost("branch")]
        public async Task<ActionResult> PostBranch(Branch model)
        {
            try
            {
                var branchResult = _repository.Branch.CreateBranch(model);
                return Ok(branchResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostCompany)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostBranch)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpGet("location")]
        public async Task<ActionResult> GetAllLocations()
        {
            try
            {
                var listLocations = _repository.Location.ReadAllLocations();
                return Ok(listLocations);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllLocations)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetAllLocations)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpPost("location")]
        public async Task<ActionResult> PostLocation(Location model)
        {
            try
            {
                var locationResult = _repository.Location.CreateLocation(model);
                return Ok(locationResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostLocation)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostLocation)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        
    }
}