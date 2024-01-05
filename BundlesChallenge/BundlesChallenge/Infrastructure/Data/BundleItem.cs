using System;
namespace BundlesChallenge.Infrastructure.Data
{
    public class BundleItem
    {
        public int BundleItemId { get; set; }
        public int BundleId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public BundleEntity Bundle { get; set; }
        public Item Item { get; set; }
    }
}

