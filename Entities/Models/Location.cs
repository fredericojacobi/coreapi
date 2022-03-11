using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Generic.Models;

namespace Entities.Models
{
    public class Location : ObjectBase
    {
        public int CityCode { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Country { get; set; }
        
        public string Latitude { get; set; }
        
        public string Longitude { get; set; }
        
        public ICollection<Branch> Branches { get; set; }
        
        public ICollection<Reminder> Reminders { get; set; }
        
        public ICollection<Event> Events { get; set; }
    }
}