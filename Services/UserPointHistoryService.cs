using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Services
{
    public class UserPointHistoryService : IUserPointHistoryService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UserPointHistoryService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReturnRequest<EletronicPointHistoryDTO>> GetAllAsync()
        {
            try
            {
                var repositoryResult = await _repository.EletronicPointHistory.ReadAllHistoriesAsync();
                var mapperResult = _mapper.Map<IEnumerable<EletronicPointHistoryDTO>>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult, HttpMethod.Get);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<EletronicPointHistoryDTO>> GetAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return new ReturnRequest<EletronicPointHistoryDTO>();

            try
            {
                var repositoryResult = await _repository.EletronicPointHistory.ReadHistoryAsync(id);
                if (repositoryResult is null)
                    return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.NotFound);
                    
                var mapperResult = _mapper.Map<EletronicPointHistoryDTO>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult, HttpMethod.Get);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<EletronicPointHistoryDTO>> GetDailyUserPointHistoryAsync(Guid userId, DateTime day)
        {
            if (userId.Equals(Guid.Empty))
                return new ReturnRequest<EletronicPointHistoryDTO>();

            try
            {
                var repositoryResult = await _repository.EletronicPointHistory.ReadHistoryByUserIdAsync(userId);
                var dailyUserPointHistory = repositoryResult.Where(x => x.CreatedAt.ToString("d").Equals(day.ToString("d")));
                var mapperResult = _mapper.Map<IEnumerable<EletronicPointHistoryDTO>>(dailyUserPointHistory);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult, HttpMethod.Get);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<EletronicPointHistoryDTO>> PostAsync(EletronicPointHistoryDTO model)
        {
            if (model is null)
                return new ReturnRequest<EletronicPointHistoryDTO>();
            
            try
            {
                var history = _mapper.Map<EletronicPointHistory>(model);
                var repositoryResult = await _repository.EletronicPointHistory.CreateHistoryAsync(history);
                var mapperResult = _mapper.Map<EletronicPointHistoryDTO>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult, HttpMethod.Post);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<EletronicPointHistoryDTO>> PutAsync(Guid id, EletronicPointHistoryDTO model)
        {
            if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
                return new ReturnRequest<EletronicPointHistoryDTO>();

            try
            {
                var history = _mapper.Map<EletronicPointHistory>(model);
                var repositoryResult = await _repository.EletronicPointHistory.UpdateHistoryAsync(history);
                var mapperResult = _mapper.Map<EletronicPointHistoryDTO>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult, HttpMethod.Put);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ReturnRequest<EletronicPointHistoryDTO>> DeleteAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return new ReturnRequest<EletronicPointHistoryDTO>();

            try
            {
                var repositoryResult = await _repository.EletronicPointHistory.DeleteHistoryAsync(id);
                return new ReturnRequest<EletronicPointHistoryDTO>(repositoryResult, HttpMethod.Delete);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }
    }
}