using System;
using Entities.Models;
using Generic.Models;

namespace Entities.DataTransferObjects
{
    public class ReminderDTO
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public Guid LocationId { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public bool isComplete { get; set; }

        public UserDTO User { get; set; }
        
        public LocationDTO Location { get; set; }
        
    }
}