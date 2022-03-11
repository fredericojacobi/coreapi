using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface IUserService
{
    Task<ReturnRequest<UserDTO>> GetAllAsync();

    Task<ReturnRequest<UserDTO>> GetAsync(Guid id);

    Task<ReturnRequest<UserDTO>> PostAsync(UserDTO userDTO);

    Task<ReturnRequest<UserDTO>> PutAsync(Guid id, UserDTO userDTO);

    Task<ReturnRequest<UserDTO>> DeleteAsync(Guid id);
    
}