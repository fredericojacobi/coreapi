using System;
using System.Collections.Generic;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface IEventService
{
    ReturnRequest<EventDTO> GetAll();

    ReturnRequest<EventDTO> Get(Guid id);

    ReturnRequest<EventDTO> Post(EventDTO eventDTO);

    ReturnRequest<EventDTO> Put(Guid id, EventDTO eventDTO);

    ReturnRequest<EventDTO> Delete(Guid id);
    
}