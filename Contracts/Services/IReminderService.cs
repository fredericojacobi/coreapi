using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface IReminderService
{
    Task<ReturnRequest<ReminderDTO>> GetAllAsync();

    Task<ReturnRequest<ReminderDTO>> GetAsync(Guid id);

    Task<ReturnRequest<ReminderDTO>> PostAsync(ReminderDTO point);

    Task<ReturnRequest<ReminderDTO>> PutAsync(Guid id, ReminderDTO point);

    Task<ReturnRequest<ReminderDTO>> DeleteAsync(Guid id);
}