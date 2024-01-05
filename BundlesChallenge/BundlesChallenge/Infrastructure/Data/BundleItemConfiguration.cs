using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BundlesChallenge.Infrastructure.Data
{
    public class BundleItemConfiguration : IEntityTypeConfiguration<BundleItem>
    {
        public void Configure(EntityTypeBuilder<BundleItem> builder)
        {
            builder.HasKey(bi => bi.BundleItemId);
            builder.HasOne(bi => bi.Bundle)
                   .WithMany(b => b.BundleItems)
                   .HasForeignKey(bi => bi.BundleId);
            builder.HasOne(bi => bi.Item)
                   .WithMany(i => i.BundleItems)
                   .HasForeignKey(bi => bi.ItemId);
        }
    }
}

