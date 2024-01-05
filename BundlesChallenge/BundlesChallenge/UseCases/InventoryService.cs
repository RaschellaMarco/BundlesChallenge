using BundlesChallenge.Core.Entities;

namespace BundlesChallenge.UseCases
{
    public class InventoryService : IInventoryService
    {
        public int CalculateMaxBundles(Bundle bundle, Dictionary<IInventoryItem, int> inventory)
        {
            int maxBundles = int.MaxValue;

            foreach (var kvp in bundle.Parts)
            {
                IInventoryItem item = kvp.Key;
                int requiredQuantity = kvp.Value;

                if (item is Bundle nestedBundle)
                {
                    int possibleNestedBundles = CalculateMaxBundles(nestedBundle, inventory);
                    maxBundles = Math.Min(maxBundles, possibleNestedBundles / requiredQuantity);
                }
                else if (inventory.TryGetValue(item, out int availableQuantity))
                {
                    int possibleBundles = availableQuantity / requiredQuantity;
                    maxBundles = Math.Min(maxBundles, possibleBundles);
                }
                else
                {
                    return 0; 
                }
            }

            return maxBundles;
        }

        public void UpdateInventory(Bundle bundle, Dictionary<IInventoryItem, int> inventory, int quantity)
        {
            foreach (var kvp in bundle.Parts)
            {
                IInventoryItem item = kvp.Key;
                int requiredQuantity = kvp.Value;

                if (item is Bundle nestedBundle)
                {
                    UpdateInventory(nestedBundle, inventory, quantity * requiredQuantity);
                }
                else if (inventory.TryGetValue(item, out int availableQuantity))
                {
                    if (quantity * requiredQuantity <= availableQuantity)
                    {
                        inventory[item] -= quantity * requiredQuantity;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    inventory[item] = 0;
                }
            }
        }
    }
}

