using System;
using Entities.Models;
using Generic.Models;

namespace Entities.DataTransferObjects
{
    public class PointDTO
    {
        public Guid Id { get; set; }
        
        public BranchDTO Branch { get; set; }
    }
}