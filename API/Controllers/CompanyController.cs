using System;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(IServiceWrapper service, ILogger<CompanyController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() => _service.Company.GetAll().ObjectResult;

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] Guid id) => _service.Company.Get(id).ObjectResult;

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompanyDTO model) => _service.Company.Post(model).ObjectResult;

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] CompanyDTO model) =>
            _service.Company.Put(id, model).ObjectResult;

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id) => _service.Company.Delete(id).ObjectResult;

        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAll() => throw new NotImplementedException();

        [HttpPost("random/{quantity}")]
        public async Task<ActionResult> CreateRandomCompany([FromRoute] int quantity) =>
            _service.Company.PostRandomCompanies(quantity).ObjectResult;
    }
}