using System;

namespace Generic.Models
{
    public abstract class ObjectBase
    {
        public Guid Id { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}