using System;
namespace BundlesChallenge.Core.Entities
{
    public interface IInventoryItem
    {
        string Name { get; set; }
        int Stock { get; set; }
    }
}

