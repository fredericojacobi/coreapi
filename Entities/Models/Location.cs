using System.Collections.Generic;
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
        
        public ICollection<EletronicPointHistory> EletronicPointHistories { get; set; }
        
        public ICollection<Reminder> Reminders { get; set; }
    }
}