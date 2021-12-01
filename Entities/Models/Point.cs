using System;
using Generic.Models;

namespace Entities.Models
{
    public class Point : ObjectBase
    {
        public Guid BranchId { get; set; }
        
        public Branch Branch { get; set; }
    }
}