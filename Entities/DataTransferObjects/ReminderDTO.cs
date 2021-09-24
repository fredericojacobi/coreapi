using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class ReminderDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isComplete { get; set; }
        public UserDTO User { get; set; }
    }
}