using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class ReminderEntityConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.Property<Guid>("Id")
                .ValueGeneratedOnAdd();
            builder.Property<Guid>("UserId");
            builder.Property<Guid>("LocationId");
            builder.Property<string>("Title").IsRequired();
            builder.Property<string>("Description").IsRequired();
            builder.Property<bool>("isComplete").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Reminders).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Location).WithMany(x => x.Reminders).HasForeignKey(x => x.LocationId);
        }
    }
}