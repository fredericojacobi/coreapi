using System;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PointController : ControllerBase
{
    private readonly IServiceWrapper _service;
    private readonly ILogger<PointController> _logger;
    public PointController(IServiceWrapper service, ILogger<PointController> logger)
    {
        _service = service;
        _logger = logger;
     //_logger.LogWarning($"{DateTime.Now.ToString("T")}: [{nameof(PointDTO)}] - {nameof(Post)} status {_service.Point.Post(model).ObjectResult.StatusCode}");   
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var returnRequest = await _service.Point.GetAllAsync();
        return returnRequest.ObjectResult;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var returnRequest = await _service.Point.GetAsync(id);
        return returnRequest.ObjectResult;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PointDTO model)
    {
        var returnRequest = await _service.Point.PostAsync(model);
        return returnRequest.ObjectResult;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] PointDTO model)
    {
        var returnRequest = await _service.Point.PutAsync(id, model);
        return returnRequest.ObjectResult;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        var returnRequest = await _service.Point.DeleteAsync(id);
        return returnRequest.ObjectResult;
    }
}