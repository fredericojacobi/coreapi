using System.Collections.Generic;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public IEnumerable<Reminder> Reminders { get; set; }
    }
}