using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class ReminderDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isComplete { get; set; }
        public long UserID { get; set; }
    }
}