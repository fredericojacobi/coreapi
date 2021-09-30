using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    [Table("Reminder")]
    public class Reminder
    {
        [Key] [Column("ReminderId")] public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(60, ErrorMessage = "The title can't be longer than 60 characters")]
        [MinLength(5, ErrorMessage = "The title must be at least 5 characters or higher")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "IsComplete is required")]
        public bool isComplete { get; set; }

        [Required(ErrorMessage = "User is required")]
        [ForeignKey(nameof(IdentityUser))]
        public IdentityUser User { get; set; }
    }
}