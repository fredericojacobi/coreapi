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
        public async Task<ActionResult> GetAll()
        {
            var returnRequest = await _service.Company.GetAllAsync();
            return returnRequest.ObjectResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            var returnRequest = await _service.Company.GetAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompanyDTO model)
        {
            var returnRequest = await _service.Company.PostAsync(model);
            return returnRequest.ObjectResult;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] CompanyDTO model)
        {
            var returnRequest = await _service.Company.PutAsync(id, model);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var returnRequest = await _service.Company.DeleteAsync(id);
            return returnRequest.ObjectResult;
        }

        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAll() => throw new NotImplementedException();

        [HttpPost("random/{quantity}")]
        public async Task<ActionResult> CreateRandomCompany([FromRoute] int quantity)
        {
            var returnRequest = await _service.Company.PostRandomCompaniesAsync(quantity);
            return returnRequest.ObjectResult;
        }
    }
}