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

public class UserService : IUserService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;
    public UserService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReturnRequest<UserDTO> GetAll()
    {
        try
        {
            var repositoryTask = _repository.User.ReadAllUsers();
            var mapperResult = _mapper.Map<IEnumerable<UserDTO>>(repositoryTask.Result);
            return new ReturnRequest<UserDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<UserDTO> Get(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<UserDTO>();

        try
        {
            var repositoryTask = _repository.User.ReadUser(id);
            var mapperResult = _mapper.Map<UserDTO>(repositoryTask.Result);
            return new ReturnRequest<UserDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<UserDTO> Post(UserDTO model)
    {
        if (model is null)
            return new ReturnRequest<UserDTO>();
        try
        {
            var user = _mapper.Map<User>(model);
            var repositoryTask = _repository.User.CreateUser(user, user.Password);
            var mapperResult = _mapper.Map<UserDTO>(repositoryTask.Result);
            return new ReturnRequest<UserDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<UserDTO> Put(Guid id, UserDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<UserDTO>();

        try
        {
            var user = _mapper.Map<User>(model);
            var repositoryTask = _repository.User.UpdateUser(user);
            var mapperResult = _mapper.Map<UserDTO>(repositoryTask.Result);
            return new ReturnRequest<UserDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<UserDTO> Delete(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<UserDTO>();

        try
        {
            var repositoryTask = _repository.User.DeleteUser(id);
            return new ReturnRequest<UserDTO>(repositoryTask.Result, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<UserDTO>(HttpStatusCode.InternalServerError);
        }
    }
}