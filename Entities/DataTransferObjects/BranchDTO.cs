using System;

namespace Entities.DataTransferObjects
{
    public class BranchDTO
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Cnpj { get; set; }
        
        public CompanyDTO Company { get; set; }
        
        public LocationDTO Location { get; set; }

    }
}