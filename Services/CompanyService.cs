using System;
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

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReturnRequest<CompanyDTO>> GetAllAsync()
        {
            try
            {
                var repositoryResult = await _repository.Company.ReadAllCompaniesAsync();
                var mapperResult = _mapper.Map<IEnumerable<CompanyDTO>>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Get);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<CompanyDTO>> GetAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var repositoryResult = await _repository.Company.ReadCompanyAsync(id);
                var mapperResult = _mapper.Map<CompanyDTO>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Get);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<CompanyDTO>> PostAsync(CompanyDTO model)
        {
            if (model is null)
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var company = _mapper.Map<Company>(model);
                var repositoryResult = await _repository.Company.CreateCompanyAsync(company);
                var mapperResult = _mapper.Map<CompanyDTO>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Post);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<CompanyDTO>> PostRandomCompaniesAsync(int quantity)
        {
            if (quantity < 1)
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var repositoryResult = await _repository.Company.CreateRandomCompaniesAsync(quantity);
                var mapperResult = _mapper.Map<IEnumerable<CompanyDTO>>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Post);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<CompanyDTO>> PutAsync(Guid id, CompanyDTO model)
        {
            if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var company = _mapper.Map<Company>(model);
                var repositoryResult = await _repository.Company.UpdateCompanyAsync(company);
                var mapperResult = _mapper.Map<CompanyDTO>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Put);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<CompanyDTO>> DeleteAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var repositoryResult = await _repository.Company.DeleteCompanyAsync(id);
                return new ReturnRequest<CompanyDTO>(repositoryResult, HttpMethod.Delete);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }
    }
}