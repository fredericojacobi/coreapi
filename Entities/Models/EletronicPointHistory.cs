using System;
using Generic.Models;

namespace Entities.Models
{
    public class EletronicPointHistory : ObjectBase
    {
        public Guid UserId { get; set; }

        public Guid LocationId { get; set; }
        
        public Location Location { get; set; }
        
        public User User { get; set; }
    }
}