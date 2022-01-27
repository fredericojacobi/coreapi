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

public class BranchService : IBranchService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public BranchService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReturnRequest<BranchDTO>> GetAllAsync()
    {
        try
        {
            var repositoryResult = await _repository.Branch.ReadAllBranchesAsync();
            var mapperResult = _mapper.Map<IEnumerable<BranchDTO>>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<BranchDTO>> GetAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<BranchDTO>();

        try
        {
            var repositoryResult = await _repository.Branch.ReadBranchAsync(id);
            var mapperResult = _mapper.Map<BranchDTO>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<BranchDTO>> GetByCompanyIdAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<BranchDTO>();

        try
        {
            var repositoryResult = await _repository.Branch.ReadBranchByCompanyIdAsync(id);
            var mapperResult = _mapper.Map<BranchDTO>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Get);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<BranchDTO>> PostAsync(BranchDTO model)
    {
        if (model is null)
            return new ReturnRequest<BranchDTO>();

        try
        {
            var branch = _mapper.Map<Branch>(model);
            var repositoryResult = await _repository.Branch.CreateBranchAsync(branch);
            var mapperResult = _mapper.Map<BranchDTO>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Post);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<BranchDTO>> PutAsync(Guid id, BranchDTO model)
    {
        if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
            return new ReturnRequest<BranchDTO>();

        try
        {
            var branch = _mapper.Map<Branch>(model);
            var repositoryResult = await _repository.Branch.UpdateBranchAsync(branch);
            var mapperResult = _mapper.Map<BranchDTO>(repositoryResult);
            return new ReturnRequest<BranchDTO>(mapperResult, HttpMethod.Put);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ReturnRequest<BranchDTO>> DeleteAsync(Guid id)
    {
        if (id.Equals(Guid.Empty))
            return new ReturnRequest<BranchDTO>();

        try
        {
            var repositoryResult = await _repository.Branch.DeleteBranchAsync(id);
            return new ReturnRequest<BranchDTO>(repositoryResult, HttpMethod.Delete);
        }
        catch (Exception e)
        {
            return new ReturnRequest<BranchDTO>(HttpStatusCode.InternalServerError);
        }
    }
}