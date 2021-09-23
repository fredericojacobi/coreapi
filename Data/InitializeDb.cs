using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

namespace Data
{
    public static class InitializeDb
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
            if (context.Reminders.Any())
            {
                Log.Information("Table [Reminders] is already populated");
            }
            else
            {
                var reminders = new List<Reminder>
                {
                    new()
                    {
                        Title = "Reminder 1",
                        Description = "Reminder1's description",
                        isComplete = false
                    },
                    new()
                    {
                        Title = "Reminder 2",
                        Description = "Reminder2's description",
                        isComplete = false
                    }
                };
                context.Reminders.AddRange(reminders);
                context.SaveChanges();
                Log.Information("Table [Reminders] populated");
            }
        }
    }
}