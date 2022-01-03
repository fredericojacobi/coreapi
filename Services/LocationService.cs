using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Services;

public class LocationService : ILocationService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public LocationService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReturnRequest<LocationDTO> GetAll()
    {
        try
        {
            var repositoryResult = _repository.Location.ReadAllLocations();
            var mapperResult = _mapper.Map<IEnumerable<LocationDTO>>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<LocationDTO> Get(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<LocationDTO>();

        try
        {
            var repositoryResult = _repository.Location.ReadLocation(id);
            var mapperResult = _mapper.Map<LocationDTO>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<LocationDTO> Post(LocationDTO model)
    {
        if (model is null)
            return new ReturnRequest<LocationDTO>();

        try
        {
            var location = _mapper.Map<Location>(model);
            var repositoryResult = _repository.Location.CreateLocation(location);
            var mapperResult = _mapper.Map<LocationDTO>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<LocationDTO> PostMultiple(IEnumerable<LocationDTO> locations)
    {
        if (!locations.Any())
            return new ReturnRequest<LocationDTO>();

        try
        {
            var locationsMapperResult = _mapper.Map<IEnumerable<Location>>(locations);
            var repositoryResult = _repository.Location.CreateMultiplesLocations(locationsMapperResult);
            var mapperResult = _mapper.Map<IEnumerable<LocationDTO>>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<LocationDTO> Put(Guid id, LocationDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<LocationDTO>();

        try
        {
            var location = _mapper.Map<Location>(model);
            var repositoryResult = _repository.Location.UpdateLocation(location);
            var mapperResult = _mapper.Map<LocationDTO>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<LocationDTO> Delete(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<LocationDTO>();

        try
        {
            var repositoryResult = _repository.Location.DeleteLocation(id);
            return new ReturnRequest<LocationDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<LocationDTO> DeleteAll()
    {
        try
        {
            var repositoryResult = _repository.Location.DeleteMultiplesLocation();
            return new ReturnRequest<LocationDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }
}