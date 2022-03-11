using System;
using System.Collections.Generic;
using Generic.Models;

namespace Entities.Models
{
    public class Event : ObjectBase
    {
        public Guid BranchId { get; set; }
        
        public Guid LocationId { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public Location Location { get; set; }
        
        public string WeatherForecast { get; set; }
        
        public Branch Branch { get; set; }
        
        public bool isCovered { get; set; }
        
        public ICollection<EventUser> EventUsers { get; set; }
    }
}