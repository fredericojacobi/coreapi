using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
        
        public ICollection<EletronicPointHistory> EletronicPointHistories { get; set; }
        
        public ICollection<Reminder> Reminders { get; set; }
    }
}