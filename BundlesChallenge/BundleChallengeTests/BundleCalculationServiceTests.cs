using BundlesChallenge.Core.Entities;
using BundlesChallenge.UseCases;

namespace ApplicationTests.BundleCalculation
{
    public class BundleCalculationServiceTests
    {
        [Fact]
        public void CalculateMaxBundles_Should_Return_Correct_Result()
        {
            // Arrange
            Part seat = new Part { Name = "Seat", Stock = 50 };
            Part pedal = new Part { Name = "Pedal", Stock = 60 };
            Part wheelFrame = new Part { Name = "Wheel Frame", Stock = 60 };
            Part tube = new Part { Name = "Tube", Stock = 35 };

            Bundle wheel = new Bundle
            {
                Name = "Wheel",
                Parts = { { wheelFrame, 1 }, { tube, 1 } }
            };

            Bundle bike = new Bundle
            {
                Name = "Bike",
                Parts = { { seat, 1 }, { pedal, 2 }, { wheel, 2 } }
            };

            Dictionary<IInventoryItem, int> inventory = new Dictionary<IInventoryItem, int>
            {
                { seat, 50 },
                { pedal, 60 },
                { wheelFrame, 60 },
                { tube, 35 }
            };

            InventoryService inventoryService = new InventoryService();

            // Act
            int maxFinishedBikes = inventoryService.CalculateMaxBundles(bike, new Dictionary<IInventoryItem, int>(inventory));

            // Assert
            Assert.Equal(17, maxFinishedBikes); 
        }

        [Fact]
        public void UpdateInventory_Should_Update_Inventory_Correctly()
        {
            // Arrange
            Part seat = new Part { Name = "Seat", Stock = 50 };
            Part pedal = new Part { Name = "Pedal", Stock = 60 };
            Part wheelFrame = new Part { Name = "Wheel Frame", Stock = 60 };
            Part tube = new Part { Name = "Tube", Stock = 35 };

            Bundle wheel = new Bundle
            {
                Name = "Wheel",
                Parts = { { wheelFrame, 1 }, { tube, 1 } }
            };

            Bundle bike = new Bundle
            {
                Name = "Bike",
                Parts = { { seat, 1 }, { pedal, 2 }, { wheel, 2 } }
            };

            Dictionary<IInventoryItem, int> inventory = new Dictionary<IInventoryItem, int>
            {
                { seat, 50 },
                { pedal, 60 },
                { wheelFrame, 60 },
                { tube, 35 }
            };

            InventoryService inventoryService = new InventoryService();

            // Act
            inventoryService.UpdateInventory(bike, inventory, 17);

            // Assert
            Assert.Equal(33, inventory[seat]);      
            Assert.Equal(26, inventory[pedal]);    
            Assert.Equal(26, inventory[wheelFrame]);
            Assert.Equal(1, inventory[tube]);  
        }
    }

}