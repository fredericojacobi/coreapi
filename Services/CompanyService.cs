using System;
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

        public ReturnRequest<CompanyDTO> GetAll()
        {
            try
            {
                var repositoryResult = _repository.Company.ReadAllCompanies();
                var mapperResult = _mapper.Map<IEnumerable<CompanyDTO>>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Get);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<CompanyDTO> Get(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var repositoryResult = _repository.Company.ReadCompany(id);
                var mapperResult = _mapper.Map<CompanyDTO>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Get);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<CompanyDTO> Post(CompanyDTO model)
        {
            if (model is null)
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var company = _mapper.Map<Company>(model);
                var repositoryResult = _repository.Company.CreateCompany(company);
                var mapperResult = _mapper.Map<CompanyDTO>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Post);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<IEnumerable<CompanyDTO>> PostRandomCompanies(int quantity)
        {
            if (quantity < 1)
                return new ReturnRequest<IEnumerable<CompanyDTO>>();

            try
            {
                var repositoryResult = _repository.Company.CreateRandomCompanies(quantity);
                var mapperResult = _mapper.Map<IEnumerable<CompanyDTO>>(repositoryResult);
                return new ReturnRequest<IEnumerable<CompanyDTO>>(mapperResult, HttpMethod.Post);
            }
            catch (Exception e)
            {
                return new ReturnRequest<IEnumerable<CompanyDTO>>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<CompanyDTO> Put(Guid id, CompanyDTO model)
        {
            if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var company = _mapper.Map<Company>(model);
                var repositoryResult = _repository.Company.UpdateCompany(company);
                var mapperResult = _mapper.Map<CompanyDTO>(repositoryResult);
                return new ReturnRequest<CompanyDTO>(mapperResult, HttpMethod.Put);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<CompanyDTO> Delete(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return new ReturnRequest<CompanyDTO>();

            try
            {
                var repositoryResult = _repository.Company.DeleteCompany(id);
                return new ReturnRequest<CompanyDTO>(repositoryResult, HttpMethod.Delete);
            }
            catch (Exception e)
            {
                return new ReturnRequest<CompanyDTO>(HttpStatusCode.InternalServerError);
            }
        }
    }
}