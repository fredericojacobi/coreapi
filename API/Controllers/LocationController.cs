using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public LocationController(ILogger<LocationController> logger, IRepositoryWrapper repository, IMapper mapper)
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
                var repositoryResult = _repository.Location.ReadAllLocations();
                return Ok(_mapper.Map<List<LocationDTO>>(repositoryResult));
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
                var repositoryResult = _repository.Location.ReadLocation(id);
                return Ok(_mapper.Map<LocationDTO>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Get)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(List<IBGE> model)
        {
            try
            {
                
                // JObject.Parse();
                return Ok();
                /*var location = _mapper.Map<Location>(model);
                var repositoryResult = _repository.Location.CreateLocation(location);
                return repositoryResult != null
                    ? Ok(_mapper.Map<LocationDTO>(repositoryResult))
                    : StatusCode(500, "Internal server error.");*/
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
        //yyyy-MM-dd hh:mm:ss.mmmmmmm
        [RequestSizeLimit(9000000000000000000)]
        [HttpPost("multiple")]
        public async Task<ActionResult> Post(List<Location> models)
        {
            try
            {
                var locations = _mapper.Map<List<Location>>(models);
                var repositoryResult = _repository.Location.CreateMultiplesLocations(locations);
                return repositoryResult
                    ? Ok(true)
                    : StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(Post)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] LocationDTO model)
        {
            try
            {
                if (id != model.Id)
                {
                    _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Location's id {id} doesn't match.");
                    return BadRequest("Object's Ids doesn't match.");
                }

                var location = _mapper.Map<Location>(model);
                var repositoryResult = _repository.Location.UpdateLocation(location);
                if (repositoryResult != null) return Ok(_mapper.Map<LocationDTO>(repositoryResult));
                _logger.LogError($"{DateTime.Now} - {nameof(Put)} : Location hasn't been updated.");
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
                var repositoryResult = _repository.Location.DeleteLocation(id);
                if (repositoryResult)
                    return Ok(true);
                _logger.LogError($"{DateTime.Now} - {nameof(Delete)} : Location hasn't been deleted.");
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
                var locations = _repository.Location.ReadAllLocations();
                foreach (var location in locations)
                {
                    _repository.Location.DeleteLocation(location);
                }
                return StatusCode((int) HttpStatusCode.ServiceUnavailable, "gol maintenance.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAll)} : {e.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }

    public class IBGE
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public MicroRegiao MicroRRegiao { get; set; }
    }

    public class MicroRegiao
    {
        public MesoRegiao MesoRRegiao{ get; set; }
    }

    public class MesoRegiao
    {
        public UF UF{ get; set; }
    }

    public class UF
    {
        public string Sigla { get; set; }
    }
}