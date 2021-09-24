using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}