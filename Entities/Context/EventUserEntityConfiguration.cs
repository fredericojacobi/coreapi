using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class EventUserEntityConfiguration : IEntityTypeConfiguration<EventUser>
    {
        public void Configure(EntityTypeBuilder<EventUser> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property<Guid>("EventId");
            builder.Property<Guid>("UserId");
            builder.Property<DateTime>("CreatedAt")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("ModifiedAt")
                .ValueGeneratedOnUpdate();
            builder.HasOne(x => x.Event)
                .WithMany(x => x.EventUsers)
                .HasForeignKey(x => x.EventId);
            builder.HasOne(x => x.User)
                .WithMany(x => x.EventUsers)
                .HasForeignKey(x => x.UserId);
        }
    }
}