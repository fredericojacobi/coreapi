using System;
using Generic.Models;

namespace Entities.Models
{
    public class EventUser : ObjectBase
    {
        public Guid UserId { get; set; }
        
        public Guid EventId { get; set; }
        
        public User User { get; set; }
        
        public Event Event { get; set; }
    }
}