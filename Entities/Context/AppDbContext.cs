using System;
using Entities.Models;
using Generic.Models;
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
            modelBuilder.ApplyConfiguration(new BranchEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EletronicPointHistoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EventUserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PointEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReminderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Branch> Branches { get; set; }
        
        public DbSet<Company> Companies { get; set; }
        
        public DbSet<EletronicPointHistory> EletronicPointHistories { get; set; }
        
        public DbSet<Event> Events { get; set; }
        
        public DbSet<Location> Locations { get; set; }
        
        public DbSet<Point> Points { get; set; }
        
        public DbSet<Reminder> Reminders { get; set; }
    }
}