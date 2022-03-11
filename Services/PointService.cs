using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Services;

public class PointService : IPointService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public PointService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReturnRequest<PointDTO>> GetAllAsync()
    {
        try
        {
            var repositoryTask = await _repository.Point.ReadAllPointsAsync();
            var mapperResult = _mapper.Map<IEnumerable<PointDTO>>(repositoryTask);
            return new ReturnRequest<PointDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<PointDTO>> GetAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<PointDTO>();

        try
        {
            var repositoryTask = await _repository.Point.ReadPointAsync(id);
            var mapperResult = _mapper.Map<PointDTO>(repositoryTask);
            return new ReturnRequest<PointDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<PointDTO>> PostAsync(PointDTO model)
    {
        if (model is null)
            return new ReturnRequest<PointDTO>();

        try
        {
            var point = _mapper.Map<Point>(model);
            var repositoryTask = await _repository.Point.CreatePointAsync(point);
            var mapperResult = _mapper.Map<PointDTO>(repositoryTask);
            return new ReturnRequest<PointDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<PointDTO>> PutAsync(Guid id, PointDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<PointDTO>();

        try
        {
            var point = _mapper.Map<Point>(model);
            var repositoryTask = await _repository.Point.UpdatePointAsync(point);
            var mapperResult = _mapper.Map<PointDTO>(repositoryTask);
            return new ReturnRequest<PointDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<PointDTO>> DeleteAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<PointDTO>();

        try
        {
            var repositoryTask = await _repository.Point.DeletePointAsync(id);
            return new ReturnRequest<PointDTO>(repositoryTask, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }
}