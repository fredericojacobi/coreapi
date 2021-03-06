using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

public class LocationService : ILocationService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public LocationService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReturnRequest<LocationDTO>> GetAllAsync()
    {
        try
        {
            var repositoryResult = await _repository.Location.ReadAllLocationsAsync();
            var mapperResult = _mapper.Map<IEnumerable<LocationDTO>>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<LocationDTO>> GetAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<LocationDTO>();

        try
        {
            var repositoryResult = await _repository.Location.ReadLocationAsync(id);
            var mapperResult = _mapper.Map<LocationDTO>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<LocationDTO>> PostAsync(LocationDTO model)
    {
        if (model is null)
            return new ReturnRequest<LocationDTO>();

        try
        {
            var location = _mapper.Map<Location>(model);
            var repositoryResult = await _repository.Location.CreateLocationAsync(location);
            var mapperResult = _mapper.Map<LocationDTO>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<LocationDTO>> PostMultipleAsync(IEnumerable<LocationDTO> locations)
    {
        if (!locations.Any())
            return new ReturnRequest<LocationDTO>();

        try
        {
            var locationsMapperResult = _mapper.Map<IEnumerable<Location>>(locations);
            var repositoryResult = await _repository.Location.CreateMultipleLocationsAsync(locationsMapperResult);
            var mapperResult = _mapper.Map<IEnumerable<LocationDTO>>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<LocationDTO>> PutAsync(Guid id, LocationDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<LocationDTO>();

        try
        {
            var location = _mapper.Map<Location>(model);
            var repositoryResult = await _repository.Location.UpdateLocationAsync(location);
            var mapperResult = _mapper.Map<LocationDTO>(repositoryResult);
            return new ReturnRequest<LocationDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<LocationDTO>> DeleteAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<LocationDTO>();

        try
        {
            var repositoryResult = await _repository.Location.DeleteLocationAsync(id);
            return new ReturnRequest<LocationDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<LocationDTO>> DeleteAllAsync(int quantity)
    {
        try
        {
            var repositoryResult = await _repository.Location.DeleteMultipleLocationAsync(quantity);
            return new ReturnRequest<LocationDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<LocationDTO>(HttpStatusCode.InternalServerError);
        }
    }
}