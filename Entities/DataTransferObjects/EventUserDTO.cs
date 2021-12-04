using System;
using Entities.Models;
using Generic.Models;

namespace Entities.DataTransferObjects
{
    public class EventUserDTO
    {
        public Guid Id { get; set; }
        
        public UserDTO User { get; set; }
        
        public EventDTO Event { get; set; }
    }
}