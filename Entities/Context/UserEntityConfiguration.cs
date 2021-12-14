using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property<Guid>("Id").ValueGeneratedOnAdd();
            builder.Property<Guid?>("BranchId");
            builder.Property<DateTime>("CreatedAt")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("ModifiedAt")
                .ValueGeneratedOnUpdate();
            builder.HasMany(x => x.EletronicPointHistories).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Reminders).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.EventUsers).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}