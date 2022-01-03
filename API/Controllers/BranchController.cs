using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Contracts.Repositories;
using Contracts.Services;
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
        private readonly IServiceWrapper _service;

        public BranchController(ILogger<BranchController> logger, IServiceWrapper service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() => _service.Branch.GetAll().ObjectResult;

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) => _service.Branch.Get(id).ObjectResult;

        [HttpGet("company/{id}")]
        public async Task<ActionResult> GetByCompanyId(Guid id) => _service.Branch.GetByCompanyId(id).ObjectResult;

        [HttpPost]
        public async Task<ActionResult> Post(BranchDTO model) => _service.Branch.Post(model).ObjectResult;

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] BranchDTO model) =>
            _service.Branch.Put(id, model).ObjectResult;

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) => _service.Branch.Delete(id).ObjectResult;
        
        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAll() => StatusCode((int) HttpStatusCode.ServiceUnavailable, "Under maintenance.");
    }
}