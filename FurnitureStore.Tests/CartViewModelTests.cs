using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FurnitureStore.Models;
using FurnitureStore.Services.Cart;
using FurnitureStore.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FurnitureStore.Tests
{
    [TestClass]
    public class CartViewModelTests
    {
        [TestMethod]
        public void ClearShoppingCart_IsNotNull()
        {
            var cartService = Mock.Of<ICartService>();
            var viewModel = new CartViewModel(cartService);

            Assert.IsNotNull(viewModel.ClearShoppingCartCommand);
        }

        [TestMethod]
        public void CheckoutShoppingCart_IsNotNull()
        {
            var cartService = Mock.Of<ICartService>();
            var viewModel = new CartViewModel(cartService);

            Assert.IsNotNull(viewModel.CheckoutShoppingCartCommand);
        }

        [TestMethod]
        public void CartItems_AreNotNull()
        {
            var cartService = Mock.Of<ICartService>();
            var viewModel = new CartViewModel(cartService);

            Assert.IsNotNull(viewModel.CartItems);
        }

        [TestMethod]
        public void CartItems_ContainsElements()
        {
            var cartServiceMock = new Mock<ICartService>();
            cartServiceMock.Setup(m => m.GetCartItems()).Returns((new List<CartItem>
            {
                new CartItem { Count = 1, Item = new FurnitureItem() },
                new CartItem { Count = 3, Item = new FurnitureItem() },
            }).AsReadOnly());

            var viewModel = new CartViewModel(cartServiceMock.Object);
            viewModel.InitializeAsync();

            Assert.IsNotNull(viewModel.CartItems);
            Assert.IsTrue(viewModel.CartItems.Any());
        }
    }
}
