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

public class ReminderService : IReminderService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public ReminderService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReturnRequest<ReminderDTO>> GetAllAsync()
    {
        try
        {
            var repositoryResult = await _repository.Reminder.ReadAllRemindersAsync();
            var mapperResult = _mapper.Map<IEnumerable<ReminderDTO>>(repositoryResult);
            return new ReturnRequest<ReminderDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<ReminderDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<ReminderDTO>> GetAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<ReminderDTO>();

        try
        {
            var repositoryResult = await _repository.Reminder.ReadReminderAsync(id);
            var mapperResult = _mapper.Map<ReminderDTO>(repositoryResult);
            return new ReturnRequest<ReminderDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<ReminderDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<ReminderDTO>> PostAsync(ReminderDTO model)
    {
        if (model is null)
            return new ReturnRequest<ReminderDTO>();

        try
        {
            var reminder = _mapper.Map<Reminder>(model);
            var repositoryResult = await _repository.Reminder.CreateReminderAsync(reminder);
            var mapperResult = _mapper.Map<ReminderDTO>(repositoryResult);
            return new ReturnRequest<ReminderDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<ReminderDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<ReminderDTO>> PutAsync(Guid id, ReminderDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<ReminderDTO>();

        try
        {
            var reminder = _mapper.Map<Reminder>(model);
            var repositoryResult = await _repository.Reminder.UpdateReminderAsync(reminder);
            var mapperResult = _mapper.Map<ReminderDTO>(repositoryResult);
            return new ReturnRequest<ReminderDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<ReminderDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<ReminderDTO>> DeleteAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<ReminderDTO>();

        try
        {
            var repositoryResult = await _repository.Reminder.DeleteReminderAsync(id);
            return new ReturnRequest<ReminderDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<ReminderDTO>(HttpStatusCode.InternalServerError);
        }    }
}