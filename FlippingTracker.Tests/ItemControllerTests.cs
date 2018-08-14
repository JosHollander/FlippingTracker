using System.Collections.Generic;
using System.Linq;
using FlippingTracker.Controllers;
using FlippingTracker.Models;
using FlippingTracker.Models.ViewModels;
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
                new Item {id = 1, name = "P1"},
                new Item {id = 2, name = "P2"},
                new Item {id = 3, name = "P3"},
                new Item {id = 4, name = "P4"},
                new Item {id = 5, name = "P5"}
            }).AsQueryable<Item>());

            ItemController controller = new ItemController(mock.Object);
            controller.PageSize = 3;

            // Act
            ItemsListViewModel result = controller.List(2).ViewData.Model as ItemsListViewModel;

            // Assert
            Item[] itemArray = result.Items.ToArray();
            Assert.True(itemArray.Length == 2);
            Assert.Equal("P4", itemArray[0].name);
            Assert.Equal("P5", itemArray[1].name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.Items).Returns((new Item[]
            {
                new Item {id = 1, name = "P1"},
                new Item {id = 2, name = "P2"},
                new Item {id = 3, name = "P3"},
                new Item {id = 4, name = "P4"},
                new Item {id = 5, name = "P5"},
            }).AsQueryable<Item>());

            ItemController controller = new ItemController(mock.Object) { PageSize = 3};
            
            // Act
            ItemsListViewModel result = new ItemsListViewModel();

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);

        }
    }
}
