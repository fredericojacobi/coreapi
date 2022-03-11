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

public class EventService : IEventService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public EventService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReturnRequest<EventDTO>> GetAllAsync()
    {
        try
        {
            var repositoryResult = await _repository.Event.ReadAllEventsAsync();
            var mapperResult = _mapper.Map<IEnumerable<EventDTO>>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<EventDTO>> GetAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<EventDTO>();

        try
        {
            var repositoryResult = await _repository.Event.ReadEventAsync(id);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<EventDTO>> GetAllByUserIdAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<EventDTO>();

        try
        {
            var repositoryResult = await _repository.EventUser.ReadAllEventByUserIdAsync(id);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<EventDTO>> GetByEventIdAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<EventDTO>();

        try
        {
            var repositoryResult = await _repository.Event.ReadEventAsync(id);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<EventDTO>> PostAsync(EventDTO model)
    {
        if (model is null)
            return new ReturnRequest<EventDTO>();

        try
        {
            var eEvent = _mapper.Map<Event>(model); 
            var repositoryResult = await _repository.Event.CreateEventAsync(eEvent);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<EventUserDTO>> PostJoinUserAsync(EventUserDTO model)
    {
        if (model is null)
            return new ReturnRequest<EventUserDTO>();

        try
        {
            var eEvent = _mapper.Map<EventUser>(model);
            // eEvent.Event = null;
            // eEvent.User = null;
            var repositoryResult = await _repository.EventUser.CreateEventUserAsync(eEvent);
            var mapperResult = _mapper.Map<EventUserDTO>(repositoryResult);
            return new ReturnRequest<EventUserDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventUserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<EventDTO>> PutAsync(Guid id, EventDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<EventDTO>();

        try
        {
            var eEvent = _mapper.Map<Event>(model); 
            var repositoryResult = await _repository.Event.UpdateEventAsync(eEvent);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ReturnRequest<EventDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<EventDTO>> DeleteAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<EventDTO>();

        try
        {
            var repositoryResult = await _repository.Event.DeleteEventAsync(id);
            return new ReturnRequest<EventDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<EventDTO>(HttpStatusCode.InternalServerError);
        }
    }
}