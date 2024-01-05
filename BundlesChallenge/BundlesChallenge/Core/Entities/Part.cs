using System;
namespace BundlesChallenge.Core.Entities
{
    public class Part : IInventoryItem
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }
}

