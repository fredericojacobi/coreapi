using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _context;
        
        public TestController(ILogger<TestController> logger, IRepositoryWrapper repository, IMapper mapper, IServiceWrapper service, AppDbContext context)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _service = service;
            _context = context;
        }
        
        [HttpGet("test/test")]
        public async Task<ActionResult> GetTest()
        {
            try
            {
                return Ok(new
                {
                    // Class = _context.TestClasses.ToList(),
                    // Student = _context.TestStudents.Include(x => x.TestRelations).ThenInclude(x => x.TestClass).ToList(),
                    // Data = _context.Companies.Include(x => x.Branches).ToList(),
                    // Users = _context.Users.Include(x => x.Branch).ToList(),
                    Event = _context.Events.Include(x => x.Location).ToList(),
                    // Relation = _context.TestRelations.Include(x => x.TestClass).ToList(),
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostStudent)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostStudent)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpGet("service")]
        public async Task<ActionResult> GetService()
        {
            try
            {
                var result = _service.Test.GetAllAsync();
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
                var companyResult = _repository.Company.ReadCompanyAsync(id);
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
                var listCompanies = _repository.Company.ReadAllCompaniesAsync();
                return Ok(listCompanies);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllCompanies)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetAllCompanies)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpGet("branch")]
        public async Task<ActionResult> GetAllBranches()
        {
            try
            {
                var listBranches = "_repository.Branch.ReadAllBranches();";
                return Ok(listBranches);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllBranches)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetAllBranches)} : {e.Message}\n{e.InnerException}");
            }
        }

        [HttpGet("location")]
        public async Task<ActionResult> GetAllLocations()
        {
            try
            {
                var listLocations = _repository.Location.ReadAllLocationsAsync();
                return Ok(listLocations);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllLocations)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetAllLocations)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        
        [HttpGet("checkData")]
        public async Task<ActionResult> GetData()
        {
            try
            {
                return Ok(new
                {
                    Branches = _context.Branches.ToList().Count,
                    Companies = _context.Companies.ToList().Count,
                    EletronicPointHistories = _context.EletronicPointHistories.ToList().Count,
                    Events = _context.Events.ToList().Count,
                    Locations = _context.Locations.ToList().Count,
                    Points = _context.Points.ToList().Count,
                    Reminders = _context.Reminders.ToList().Count,
                    Users = _context.Users.ToList().Count,
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllLocations)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(GetAllLocations)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpPost("test/class")]
        public async Task<ActionResult> PostClass([FromBody] TestClass testClass)
        {
            try
            {
                await _context.TestClasses.AddAsync(testClass);
                await _context.SaveChangesAsync();
                await _context.Entry(testClass).ReloadAsync();
                return Ok(testClass);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostClass)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostClass)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpPost("test/relation")]
        public async Task<ActionResult> PostRelation([FromBody] TestRelation testRelation)
        {
            try
            {
                await _context.TestRelations.AddAsync(testRelation);
                await _context.SaveChangesAsync();
                await _context.Entry(testRelation).ReloadAsync();
                return Ok(testRelation);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostRelation)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostRelation)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpPost("test/student")]
        public async Task<ActionResult> PostStudent([FromBody] TestStudent testStudent)
        {
            try
            {
                await _context.TestStudents.AddAsync(testStudent);
                await _context.SaveChangesAsync();
                await _context.Entry(testStudent).ReloadAsync();
                return Ok(testStudent);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostStudent)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostStudent)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpPost("company")]
        public async Task<ActionResult> PostCompany(Company model)
        {
            try
            {
                var companyResult = _repository.Company.CreateCompanyAsync(model);
                return Ok(companyResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostCompany)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostCompany)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpPost("branch")]
        public async Task<ActionResult> PostBranch(Branch model)
        {
            try
            {
                var branchResult = "_repository.Branch.CreateBranch(model)";
                return Ok(branchResult);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostCompany)} : {e.Message}");
                return StatusCode(500, $"Internal server error.\n{DateTime.Now} - {nameof(PostBranch)} : {e.Message}\n{e.InnerException}");
            }
        }
        
        [HttpPost("location")]
        public async Task<ActionResult> PostLocation(Location model)
        {
            try
            {
                var locationResult = _repository.Location.CreateLocationAsync(model);
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