using System;
using System.ComponentModel.DataAnnotations;
using Generic.Models;

namespace Entities.Models
{
    public class Reminder : ObjectBase
    {
        public Guid UserId { get; set; }
        
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(60, ErrorMessage = "The title can't be longer than 60 characters")]
        [MinLength(5, ErrorMessage = "The title must be at least 5 characters or higher")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "IsComplete is required")]
        public bool isComplete { get; set; }

        // [Required(ErrorMessage = "User is required")]
        public User User { get; set; }
        
        public Location Location { get; set; }
    }
}