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
    // private readonly ILogger<PointController> _logger;
    public PointController(IServiceWrapper service)//, ILogger<PointController> logger
    {
        _service = service;
        // _logger = logger;
     //_logger.LogWarning($"{DateTime.Now.ToString("T")}: [{nameof(PointDTO)}] - {nameof(Post)} status {_service.Point.Post(model).ObjectResult.StatusCode}");   
    }

    [HttpGet]
    public ActionResult GetAll() => _service.Point.GetAll().ObjectResult;

    [HttpGet("{id}")]
    public ActionResult Get([FromRoute] Guid id) => _service.Point.Get(id).ObjectResult;

    [HttpPost]
    public ActionResult Post([FromBody] PointDTO model) => _service.Point.Post(model).ObjectResult;

    [HttpPut("{id}")]
    public ActionResult Put([FromRoute] Guid id, [FromBody] PointDTO model) => _service.Point.Put(id, model).ObjectResult;

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] Guid id) => _service.Point.Delete(id).ObjectResult;

}