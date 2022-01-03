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

public class EventService : IEventService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public EventService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReturnRequest<EventDTO> GetAll()
    {
        try
        {
            var repositoryResult = _repository.Event.ReadAllEvents();
            var mapperResult = _mapper.Map<IEnumerable<EventDTO>>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<EventDTO> Get(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<EventDTO>();

        try
        {
            var repositoryResult = _repository.Event.ReadEvent(id);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<EventDTO> Post(EventDTO model)
    {
        if (model is null)
            return new ReturnRequest<EventDTO>();

        try
        {
            var eEvent = _mapper.Map<Event>(model); 
            var repositoryResult = _repository.Event.CreateEvent(eEvent);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<EventDTO> Put(Guid id, EventDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<EventDTO>();

        try
        {
            var eEvent = _mapper.Map<Event>(model); 
            var repositoryResult = _repository.Event.UpdateEvent(eEvent);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<EventDTO> Delete(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<EventDTO>();

        try
        {
            var repositoryResult = _repository.Event.DeleteEvent(id);
            return new ReturnRequest<EventDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }
}