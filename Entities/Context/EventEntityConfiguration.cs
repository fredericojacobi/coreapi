using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property<Guid>("Id").ValueGeneratedOnAdd();
            builder.Property<Guid>("BranchId").IsRequired();
            builder.Property<Guid>("LocationId").IsRequired();
            builder.Property<string>("Name").IsRequired();
            builder.Property<string>("Description");
            builder.Property<DateTime>("StartDate").IsRequired();
            builder.Property<DateTime>("EndDate").IsRequired();
            builder.Property<bool>("isCovered");
            builder.Property<DateTime>("CreatedAt")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("ModifiedAt")
                .ValueGeneratedOnUpdate();
            builder.HasOne(x => x.Branch).WithMany(x => x.Events).HasForeignKey(x => x.BranchId);
            builder.HasOne(x => x.Location).WithMany(x => x.Events).HasForeignKey(x => x.LocationId);
            builder.HasMany(x => x.EventUsers).WithOne(x => x.Event).HasForeignKey(x => x.EventId);
        }
    }
}