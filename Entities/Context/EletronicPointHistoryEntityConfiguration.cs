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
            builder.Property<Guid>("Id")
                .ValueGeneratedOnAdd();
            builder.Property<Guid>("UserId").IsRequired();
            builder.Property<Guid>("LocationId").IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.EletronicPointHistories)
                .HasForeignKey(x => x.UserId);
        }
    }
}