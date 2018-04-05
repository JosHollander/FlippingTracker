using System.Collections.Generic;
using System.Linq;
using FlippingTracker.Controllers;
using FlippingTracker.Models;
using Moq;
using Xunit;

namespace FlippingTracker.Tests
{
    public class ItemControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns((new Item[]
            {
                new Item {ItemID = 1, Name = "P1"},
                new Item {ItemID = 2, Name = "P2"},
                new Item {ItemID = 3, Name = "P3"},
                new Item {ItemID = 4, Name = "P4"},
                new Item {ItemID = 5, Name = "P5"}
            }).AsQueryable<Item>());

            ItemController controller = new ItemController(mock.Object);
            controller.PageSize = 3;

            // Act
            IEnumerable<Item> result = controller.List(2).ViewData.Model as IEnumerable<Item>;

            // Assert
            Item[] itemArray = result.ToArray();
            Assert.True(itemArray.Length == 2);
            Assert.Equal("P4", itemArray[0].Name);
            Assert.Equal("P5", itemArray[1].Name);
        }
    }
}
