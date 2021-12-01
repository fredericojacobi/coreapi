using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        public Guid BranchId { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
        
        public Branch Branch { get; set; }
        
        public ICollection<EletronicPointHistory> EletronicPointHistories { get; set; }
        
        public ICollection<Reminder> Reminders { get; set; }
        
        public ICollection<EventUser> EventUsers { get; set; }
    }
}