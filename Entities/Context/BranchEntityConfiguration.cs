using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Context
{
    public class BranchEntityConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property<Guid>("Id").ValueGeneratedOnAdd();
            builder.Property<Guid?>("CompanyId");
            builder.Property<Guid?>("LocationId");
            builder.Property<string>("Name").IsRequired();
            builder.Property<string>("Cnpj").IsRequired();
            builder.Property<DateTime>("CreatedAt")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("ModifiedAt")
                .ValueGeneratedOnUpdate();
            builder.HasOne(x => x.Company)
                .WithMany(x => x.Branches)
                .HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.Location)
                .WithMany(x => x.Branches)
                .HasForeignKey(x => x.LocationId);
            builder.HasMany(x => x.Users)
                .WithOne(x => x.Branch)
                .HasForeignKey(x => x.BranchId);
        }
    }
}