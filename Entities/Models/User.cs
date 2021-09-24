using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
namespace Entities.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public long Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username is required")]
        // [MaxLength(30, ErrorMessage = "The username can't be longer than 30 characters")]
        [MinLength(6, ErrorMessage = "The username must be at least 6 characters or higher")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        // [MaxLength(12, ErrorMessage = "The password can't be longer than 12 characters")]
        [MinLength(6, ErrorMessage = "The password must be 6 characters or higher")]
        public string Password { get; set; }
        [AllowNull]
        public string Role { get; set; }

        public ICollection<Reminder> Reminders { get; set; }
    }
}