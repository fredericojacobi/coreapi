using System;
using System.Collections.Generic;
using Generic.Models;

namespace Entities.Models
{
    public class Branch : ObjectBase
    {
        public Guid? CompanyId { get; set; }
        
        public Guid? LocationId { get; set; }

        public string Name { get; set; }
        
        public string Cnpj { get; set; }
        
        public Company Company { get; set; }
        
        public Location Location { get; set; }
        
        public ICollection<Event> Events { get; set; }
        
        public ICollection<Point> Points { get; set; }
        
        public ICollection<User> Users { get; set; }
    }
}