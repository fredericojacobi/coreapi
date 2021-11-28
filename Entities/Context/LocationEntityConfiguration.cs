using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class LocationEntityConfiguration  : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property<Guid>("Id")
                .ValueGeneratedOnAdd();
            builder.Property<Guid>("EletronicPointHistoryId").IsRequired();
            builder.Property<int>("CityCode").IsRequired();
            builder.Property<string>("City").IsRequired();
            builder.Property<string>("State").IsRequired();
            builder.Property<string>("Country").IsRequired();
            builder.Property<string>("Latitude").IsRequired();
            builder.Property<string>("Longitude").IsRequired();
            builder.HasMany(x => x.EletronicPointHistories)
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId);
        }
    }
}