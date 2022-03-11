using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Generic.Models;

namespace Entities.Models
{
    public class Point : ObjectBase
    {       
        public Guid BranchId { get; set; }

        public string Name { get; set; }
        
        public Branch Branch { get; set; }

        public ICollection<EletronicPointHistory> EletronicPointHistories { get; set; }
    }
}