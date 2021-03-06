using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class BranchDTO
    {
        public Guid Id { get; set; }
        
        public Guid CompanyId { get; set; }
        
        public Guid LocationId { get; set; }
        
        public string Name { get; set; }
        
        public string Cnpj { get; set; }
        
        public CompanyDTO Company { get; set; }
        
        public LocationDTO Location { get; set; }
        
        public ICollection<PointDTO> Points { get; set; }

    }
}