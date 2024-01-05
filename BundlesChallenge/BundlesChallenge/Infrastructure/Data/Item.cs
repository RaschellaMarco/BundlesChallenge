using BundlesChallenge.Core.Entities;

namespace BundlesChallenge.Infrastructure.Data
{
    public class Item : IInventoryItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        // Navigation property for BundleItems
        public ICollection<BundleItem> BundleItems { get; set; }
    }
}

