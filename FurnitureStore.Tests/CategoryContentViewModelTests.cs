using FurnitureStore.Models;
using FurnitureStore.Services.Cart;
using FurnitureStore.Services.FurnitureItems;
using FurnitureStore.Services.Navigation;
using FurnitureStore.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStore.Tests
{
    [TestClass]
    public class CategoryContentViewModelTests
    {
        [TestMethod]
        public void Items_AreNotNullAfterConstruct()
        {
            var furnitureItemsServiceMock = new Mock<IFurnitureItemsService>();
            var navigationServiceMock = new Mock<INavigationService>();
            var cartServiceMock = new Mock<ICartService>();

            var viewModel = new CategoryContentViewModel
            (
                furnitureItemsServiceMock.Object,
                navigationServiceMock.Object,
                cartServiceMock.Object
            );

            Assert.IsNotNull(viewModel.Items);
        }

        [TestMethod]
        public void Items_AreNotNullAfterInitialize()
        {
            var furnitures = new List<FurnitureItem>
                {
                    new FurnitureItem(),
                    new FurnitureItem(),
                };

            var furnitureItemsServiceMock = new Mock<IFurnitureItemsService>();
            furnitureItemsServiceMock.Setup(m => m.GetFurnitureItems(It.IsAny<FurnitureCategory>()))
                .Returns(Task.FromResult<IEnumerable<FurnitureItem>>(furnitures));

            var navigationServiceMock = new Mock<INavigationService>();
            var cartServiceMock = new Mock<ICartService>();

            var viewModel = new CategoryContentViewModel
            (
                furnitureItemsServiceMock.Object,
                navigationServiceMock.Object,
                cartServiceMock.Object
            );

            viewModel.Initialize(It.IsAny<FurnitureCategory>()).Wait();

            Assert.IsNotNull(viewModel.Items);
            Assert.IsTrue(furnitures.Count() == viewModel.Items.Count());
        }

        [TestMethod]
        public void BuyItemCommand_IsNotNull()
        {
            var furnitureItemsServiceMock = new Mock<IFurnitureItemsService>();
            var navigationServiceMock = new Mock<INavigationService>();
            var cartServiceMock = new Mock<ICartService>();

            var viewModel = new CategoryContentViewModel
            (
                furnitureItemsServiceMock.Object,
                navigationServiceMock.Object,
                cartServiceMock.Object
            );

            Assert.IsNotNull(viewModel.BuyItemCommand);
        }

        [TestMethod]
        public void BuyItemCommand_AddsItemToShoppingCart()
        {
            var furnitureItemsService = new Mock<IFurnitureItemsService>().Object;
            var navigationService = new Mock<INavigationService>().Object;
            ICartService cartService = new CartService();

            var viewModel = new CategoryContentViewModel
            (
                furnitureItemsService,
                navigationService,
                cartService
            );

            Assert.IsNotNull(viewModel.BuyItemCommand);

            viewModel.SelectedItem = new FurnitureItem
            {
                Category = FurnitureCategory.Bathroom,
                Description = "Test furniture description",
                Id = 1,
                ImageUrl = string.Empty,
                Name = "Test furniture name",
                Price = 99.00m
            };

            viewModel.BuyItemCommand.Execute(null);

            // assert
            Assert.IsTrue(cartService.GetCartItems().Any());
        }
    }
}
