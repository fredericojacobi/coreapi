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

public class BranchService : IBranchService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public BranchService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReturnRequest<BranchDTO> GetAll()
    {
        try
        {
            var repositoryResult = _repository.Branch.ReadAllBranches();
            var mapperResult = _mapper.Map<IEnumerable<BranchDTO>>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<BranchDTO> Get(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<BranchDTO>();

        try
        {
            var repositoryResult = _repository.Branch.ReadBranch(id);
            var mapperResult = _mapper.Map<BranchDTO>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<BranchDTO> GetByCompanyId(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<BranchDTO>();

        try
        {
            var repositoryResult = _repository.Branch.ReadBranchByCompanyId(id);
            var mapperResult = _mapper.Map<BranchDTO>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<BranchDTO> Post(BranchDTO model)
    {
        if (model is null)
            return new ReturnRequest<BranchDTO>();

        try
        {
            var branch = _mapper.Map<Branch>(model);
            var repositoryResult = _repository.Branch.CreateBranch(branch);
            var mapperResult = _mapper.Map<BranchDTO>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<BranchDTO> Put(Guid id, BranchDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<BranchDTO>();

        try
        {
            var branch = _mapper.Map<Branch>(model);
            var repositoryResult = _repository.Branch.UpdateBranch(branch);
            var mapperResult = _mapper.Map<BranchDTO>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public ReturnRequest<BranchDTO> Delete(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<BranchDTO>();

        try
        {
            var repositoryResult = _repository.Branch.DeleteBranch(id);
            return new ReturnRequest<BranchDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }
}