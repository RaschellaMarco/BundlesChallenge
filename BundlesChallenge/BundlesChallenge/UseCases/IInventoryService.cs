using BundlesChallenge.Core.Entities;

namespace BundlesChallenge.UseCases
{
    public interface IInventoryService
    {
        int CalculateMaxBundles(Bundle bundle, Dictionary<IInventoryItem, int> inventory);
        void UpdateInventory(Bundle bundle, Dictionary<IInventoryItem, int> inventory, int quantity);
    }
}

