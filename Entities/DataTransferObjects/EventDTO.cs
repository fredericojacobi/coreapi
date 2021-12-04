using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public LocationDTO Location { get; set; }
        
        public BranchDTO Branch { get; set; }
        
        public string WeatherForecast { get; set; }
        
        public bool isCovered { get; set; }
    }
}