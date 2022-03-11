using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Generic.Models;

namespace Entities.Models
{
    public class Company : ObjectBase
    {
        public string Name { get; set; }
        
        public ICollection<Branch> Branches { get; set; }
    }
}