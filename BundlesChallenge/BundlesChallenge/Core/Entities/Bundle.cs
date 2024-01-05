namespace BundlesChallenge.Core.Entities
{
    public class Bundle : IInventoryItem
    {
        public string Name { get; set; }
        public Dictionary<IInventoryItem, int> Parts { get; set; } = new Dictionary<IInventoryItem, int>();
        public int Stock { get; set; }

        public int CalculateMaxBundles(Dictionary<IInventoryItem, int> inventory)
        {
            int maxBundles = int.MaxValue;

            foreach (var kvp in Parts)
            {
                IInventoryItem item = kvp.Key;
                int requiredQuantity = kvp.Value;

                if (item is Bundle nestedBundle)
                {
                    int possibleNestedBundles = nestedBundle.CalculateMaxBundles(inventory);
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

        public void UpdateInventory(Dictionary<IInventoryItem, int> inventory, int quantity)
        {
            foreach (var kvp in Parts)
            {
                IInventoryItem item = kvp.Key;
                int requiredQuantity = kvp.Value;

                if (item is Bundle nestedBundle)
                {
                    nestedBundle.UpdateInventory(inventory, quantity * requiredQuantity);
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

