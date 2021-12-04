using System;
using Entities.Models;
using Generic.Models;

namespace Entities.DataTransferObjects
{
    public class LocationDTO
    {
        public Guid Id { get; set; }
        
        public int CityCode { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Country { get; set; }
        
        public string Latitude { get; set; }
        
        public string Longitude { get; set; }
    }
}