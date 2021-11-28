using System;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReminderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EletronicPointHistoryEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Reminder> Reminders { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<EletronicPointHistory> EletronicPointHistories { get; set; }
    }
}