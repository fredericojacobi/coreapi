using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Contracts.Repositories;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly ILogger<PointController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public PointController(ILogger<PointController> logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPoints()
        {
            try
            {
                var repositoryResult = _repository.Point.ReadAllPoints();
                return Ok(_mapper.Map<IEnumerable<PointDTO>>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetAllPoints)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPoint(Guid id)
        {
            try
            {
                var repositoryResult = _repository.Point.ReadPoint(id);
                return Ok(_mapper.Map<PointDTO>(repositoryResult));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(GetPoint)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }


        [HttpPost]
        public async Task<ActionResult> PostPoint(PointDTO model)
        {
            try
            {
                var point = _mapper.Map<Point>(model);
                var repositoryResult = _repository.Point.CreatePoint(point);
                return repositoryResult != null
                        ? Ok(repositoryResult)
                        : StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(PostPoint)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePoint(PointDTO model)
        {
            try
            {
                var point = _mapper.Map<Point>(model);
                var repositoryResult = _repository.Point.UpdatePoint(point);
                return repositoryResult != null
                    ? Ok(_mapper.Map<PointDTO>(repositoryResult))
                    : StatusCode(500, "Internal server error.");
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(UpdatePoint)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePoint(Guid id)
        {
            try
            {
                return Ok(_repository.Point.DeletePoint(id));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(DeletePoint)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }

        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAllPoints()
        {
            try
            {
                var repositoryResult = _repository.Point.ReadAllPoints();
                var ok = false;
                foreach (var point in repositoryResult)
                {
                    ok = _repository.Point.DeletePoint(point);
                }

                return Ok(ok);
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now} - {nameof(DeleteAllPoints)} : {e.Message}");
                return StatusCode(500, ResponseErrorMessage.InternalServerError(e));
            }
        }
    }
}