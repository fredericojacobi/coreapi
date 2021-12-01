using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property<Guid>("Id").ValueGeneratedOnAdd();
            builder.Property<int>("CityCode").IsRequired();
            builder.Property<string>("City").IsRequired();
            builder.Property<string>("State").IsRequired();
            builder.Property<string>("Country").IsRequired();
            builder.Property<string>("Latitude").IsRequired();
            builder.Property<string>("Longitude").IsRequired();
            builder.Property<DateTime>("CreatedAt")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("ModifiedAt")
                .ValueGeneratedOnUpdate();
            builder.HasMany(x => x.EletronicPointHistories)
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId);
            builder.HasMany(x => x.Reminders)
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId);
            builder.HasMany(x => x.Events)
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId);
        }
    }
}