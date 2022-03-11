using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Generic.Models;

namespace Entities.Models
{
    public class Reminder : ObjectBase
    {
        public Guid UserId { get; set; }
        
        public Guid LocationId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool isComplete { get; set; }

        public User User { get; set; }
        
        public Location Location { get; set; }
    }
}