using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class PointEntityConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property<Guid?>("BranchId");
            builder.Property<string>("Name").IsRequired();
            builder.Property<DateTime>("CreatedAt")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("ModifiedAt")
                .ValueGeneratedOnUpdate();
            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Points)
                .HasForeignKey(x => x.BranchId);
        }
    }
}