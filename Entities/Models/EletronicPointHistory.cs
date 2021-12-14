using System;
using Generic.Models;

namespace Entities.Models
{
    public class EletronicPointHistory : ObjectBase
    {
        public Guid? UserId { get; set; }

        public Guid? PointId { get; set; }
        
        public Point Point { get; set; }
        
        public User User { get; set; }
    }
}