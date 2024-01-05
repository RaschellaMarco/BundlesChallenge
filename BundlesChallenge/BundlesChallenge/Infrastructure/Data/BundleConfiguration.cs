using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BundlesChallenge.Infrastructure.Data
{
    public class BundleConfiguration : IEntityTypeConfiguration<BundleEntity>
    {
        public void Configure(EntityTypeBuilder<BundleEntity> builder)
        {
            builder.HasKey(b => b.BundleEntityId);
            builder.HasMany(b => b.BundleItems)
                   .WithOne(bi => bi.Bundle)
                   .HasForeignKey(bi => bi.BundleId);
        }
    }
}

