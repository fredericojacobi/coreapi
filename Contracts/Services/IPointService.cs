using System;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using Entities.Models;
using Generic.Models;

namespace Contracts.Services;

public interface IPointService
{
    ReturnRequest<PointDTO> GetAll();

    ReturnRequest<PointDTO> Get(Guid id);

    ReturnRequest<PointDTO> Post(PointDTO point);

    ReturnRequest<PointDTO> Put(Guid id, PointDTO point);

    ReturnRequest<PointDTO> Delete(Guid id);
    
}