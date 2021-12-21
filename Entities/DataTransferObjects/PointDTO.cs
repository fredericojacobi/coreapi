using System;
using Entities.Models;
using Generic.Models;

namespace Entities.DataTransferObjects
{
    public class PointDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public Guid BranchId { get; set; }
        
        public BranchDTO Branch { get; set; }
    }
}