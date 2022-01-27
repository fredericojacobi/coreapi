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
        public async Task<ActionResult> GetAllAsync()
        {
            var returnRequest = await _service.Branch.GetAllAsync();
            return returnRequest.ObjectResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync([FromRoute] Guid id)
        {
            var returnRequest = await _service.Branch.GetAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpGet("company/{id}")]
        public async Task<ActionResult> GetByCompanyIdAsync([FromRoute] Guid id)
        {
            var returnRequest = await _service.Branch.GetByCompanyIdAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] BranchDTO model)
        {
            var returnRequest = await _service.Branch.PostAsync(model);
            return returnRequest.ObjectResult;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] BranchDTO model)
        {
            var returnRequest = await _service.Branch.PutAsync(id, model);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var returnRequest = await _service.Branch.DeleteAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("all")]
        public ActionResult DeleteAllAsync() => throw new NotImplementedException();
    }
}