using System;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;
using Services.Contracts;

namespace Services.Models
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

        public ReturnRequest<EletronicPointHistoryDTO> GetAll()
        {
            try
            {
                var repositoryResult = _repository.EletronicPointHistory.ReadAllHistories();
                var mapperResult = _mapper.Map<List<EletronicPointHistoryDTO>>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<EletronicPointHistoryDTO> Get(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return new ReturnRequest<EletronicPointHistoryDTO>();

            try
            {
                var repositoryResult = _repository.EletronicPointHistory.ReadHistory(id);
                var mapperResult = _mapper.Map<EletronicPointHistoryDTO>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<EletronicPointHistoryDTO> GetDailyUserPointHistory(Guid userId)
        {
            if (userId.Equals(Guid.Empty))
                return new ReturnRequest<EletronicPointHistoryDTO>();

            try
            {
                var repositoryResult = _repository.EletronicPointHistory.ReadHistoryByUserId(userId);
                var mapperResult = _mapper.Map<List<EletronicPointHistoryDTO>>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<EletronicPointHistoryDTO> Post(EletronicPointHistoryDTO model)
        {
            if (model is null)
                return new ReturnRequest<EletronicPointHistoryDTO>();
            
            try
            {
                var history = _mapper.Map<EletronicPointHistory>(model);
                var repositoryResult = _repository.EletronicPointHistory.CreateHistory(history);
                var mapperResult = _mapper.Map<EletronicPointHistoryDTO>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<EletronicPointHistoryDTO> Put(Guid id, EletronicPointHistoryDTO model)
        {
            if (model is null || id.Equals(Guid.Empty) || !id.Equals(model.Id))
                return new ReturnRequest<EletronicPointHistoryDTO>();

            try
            {
                var history = _mapper.Map<EletronicPointHistory>(model);
                var repositoryResult = _repository.EletronicPointHistory.UpdateHistory(history);
                var mapperResult = _mapper.Map<EletronicPointHistoryDTO>(repositoryResult);
                return new ReturnRequest<EletronicPointHistoryDTO>(mapperResult);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public ReturnRequest<EletronicPointHistoryDTO> Delete(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return new ReturnRequest<EletronicPointHistoryDTO>();

            try
            {
                var repositoryResult = _repository.EletronicPointHistory.DeleteHistory(id);
                return new ReturnRequest<EletronicPointHistoryDTO>(repositoryResult);
            }
            catch (Exception e)
            {
                return new ReturnRequest<EletronicPointHistoryDTO>(HttpStatusCode.InternalServerError);
            }
        }
    }
}