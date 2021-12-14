using System;
using Entities.Models;
using Generic.Models;

namespace Entities.DataTransferObjects
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public LocationDTO Location { get; set; }
        
    }
}