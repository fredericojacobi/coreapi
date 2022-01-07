using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Generic.Models;

namespace Contracts.Services;

public interface IUserService
{
    ReturnRequest<UserDTO> GetAll();

    ReturnRequest<UserDTO> Get(Guid id);

    ReturnRequest<UserDTO> Post(UserDTO userDTO);

    ReturnRequest<UserDTO> Put(Guid id, UserDTO userDTO);

    ReturnRequest<UserDTO> Delete(Guid id);
    
}