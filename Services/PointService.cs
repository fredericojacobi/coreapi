using System;
using System.Collections.Generic;
using System.Net;
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

    public ReturnRequest<PointDTO> GetAll()
    {
        try
        {
            var repositoryTask = _repository.Point.ReadAllPoints();
            var mapperResult = _mapper.Map<IEnumerable<PointDTO>>(repositoryTask.Result);
            return new ReturnRequest<PointDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<PointDTO> Get(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<PointDTO>();

        try
        {
            var repositoryTask = _repository.Point.ReadPoint(id);
            var mapperResult = _mapper.Map<PointDTO>(repositoryTask.Result);
            return new ReturnRequest<PointDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<PointDTO> Post(PointDTO model)
    {
        if (model is null)
            return new ReturnRequest<PointDTO>();

        try
        {
            var point = _mapper.Map<Point>(model);
            var repositoryTask = _repository.Point.CreatePoint(point);
            var mapperResult = _mapper.Map<PointDTO>(repositoryTask.Result);
            return new ReturnRequest<PointDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<PointDTO> Put(Guid id, PointDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<PointDTO>();

        try
        {
            var point = _mapper.Map<Point>(model);
            var repositoryTask = _repository.Point.UpdatePoint(point);
            var mapperResult = _mapper.Map<PointDTO>(repositoryTask.Result);
            return new ReturnRequest<PointDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<PointDTO> Delete(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<PointDTO>();

        try
        {
            var repositoryTask = _repository.Point.DeletePoint(id);
            return new ReturnRequest<PointDTO>(repositoryTask.Result, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<PointDTO>(HttpStatusCode.InternalServerError);
        }
    }
}