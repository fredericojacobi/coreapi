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

public class UserService : IUserService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;
    public UserService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReturnRequest<UserDTO>> GetAllAsync()
    {
        try
        {
            var repositoryTask = await _repository.User.ReadAllUsersAsync();
            var mapperResult = _mapper.Map<IEnumerable<UserDTO>>(repositoryTask);
            return new ReturnRequest<UserDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<UserDTO>> GetAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<UserDTO>();

        try
        {
            var repositoryTask = await _repository.User.ReadUserAsync(id);
            var mapperResult = _mapper.Map<UserDTO>(repositoryTask);
            return new ReturnRequest<UserDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<UserDTO>> PostAsync(UserDTO model)
    {
        if (model is null)
            return new ReturnRequest<UserDTO>();
        try
        {
            var user = _mapper.Map<User>(model);
            var repositoryTask = await _repository.User.CreateUserAsync(user, user.Password);
            var mapperResult = _mapper.Map<UserDTO>(repositoryTask);
            return new ReturnRequest<UserDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<UserDTO>> PutAsync(Guid id, UserDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<UserDTO>();

        try
        {
            var user = _mapper.Map<User>(model);
            var repositoryTask = await _repository.User.UpdateUserAsync(user);
            var mapperResult = _mapper.Map<UserDTO>(repositoryTask);
            return new ReturnRequest<UserDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<UserDTO>> DeleteAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<UserDTO>();

        try
        {
            var repositoryTask = await _repository.User.DeleteUserAsync(id);
            return new ReturnRequest<UserDTO>(repositoryTask, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }
}