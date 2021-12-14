using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class EletronicPointHistoryEntityConfiguration : IEntityTypeConfiguration<EletronicPointHistory>
    {
        public void Configure(EntityTypeBuilder<EletronicPointHistory> builder)
        {
            builder.Property<Guid>("Id").ValueGeneratedOnAdd();
            builder.Property<Guid?>("UserId");
            builder.Property<Guid?>("PointId");
            builder.Property<DateTime>("CreatedAt")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("ModifiedAt")
                .ValueGeneratedOnUpdate();
            builder.HasOne(x => x.User)
                .WithMany(x => x.EletronicPointHistories)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Point)
                .WithMany(x => x.EletronicPointHistories)
                .HasForeignKey(x => x.PointId);
        }
    }
}