using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Bussines.Services.Basket;
using ValidateId.Domain.DTOs.Basket;
using ValidateId.Domain.Entities;
using ValidateId.Infrastructure.Data.Repositories;
using ValidateId.Infrastructure.Interfaces;
using ValidateIdAPI.Controllers;

namespace ValidateId.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        #region Class Variables

        // The user shopping basket
        private ShoppingBasket _shoppingBasket;

        // The controller
        private ShoppingCartController _controller;

        // The data base context (infrastructure)
        private IRepository _context;

        // The service
        private IBasketService _basketService;

        // Total cost for testing basket
        private const double _totalProductCost = 45.00;

        #endregion

        #region Class Start and tear down

        [SetUp]
        public void SetUp()
        {
            _shoppingBasket = new ShoppingBasket(353);
            _shoppingBasket.Products = new List<Product>() { new Product(2, "TheHobbit"), new Product(5, "BreakingBad") };

            var options = new DbContextOptionsBuilder<InMemmoryRepository>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            _context = new InMemmoryRepository(options);
            _basketService = new BasketService(_context);

            var logger = Mock.Of<ILogger<ShoppingCartController>>();
            _controller = new ShoppingCartController(logger, _basketService);

        }

        [TearDown]
        public void TearDown()
        {
            _shoppingBasket = null;
            _context = null;
        }

        #endregion

        #region Class tests

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to add a new item to a user basket repository from the entrypoint/controller.")]
        public void AddShoppingBasket_ToUser_Test()
        {
            // Arrange
            var addBasketRequest = new AddUserBasketRequest()
            {
                CreationDate = _shoppingBasket.CreationDate,
                User = _shoppingBasket.User,
                Units = _shoppingBasket.Products
            };


            // Act
            var result = _controller.AddItem(addBasketRequest);

            // Assert
            var basket = _context.GetShoppingBaskets()[0];
            Assert.NotNull(result);
            Assert.AreEqual(_context.GetShoppingBaskets().Count, 1);
            Assert.AreEqual(basket.User.Id, _shoppingBasket.User.Id);
            Assert.AreEqual(basket.Products, _shoppingBasket.Products);
            Assert.AreEqual(basket.Total, _totalProductCost);
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to get all products.")]
        public void GetProducts_Test()
        {
            var addBasketRequest_1 = new AddUserBasketRequest()
            {
                CreationDate = _shoppingBasket.CreationDate,
                User = _shoppingBasket.User,
                Units = _shoppingBasket.Products
            };
            var addBasketRequest_2 = new AddUserBasketRequest()
            {
                CreationDate = _shoppingBasket.CreationDate,
                User = _shoppingBasket.User,
                Units = _shoppingBasket.Products
            };

            // Act
            _shoppingBasket.User.Id = 456;
            _controller.AddItem(addBasketRequest_1);
            _shoppingBasket.User.Id = 986;
            _controller.AddItem(addBasketRequest_2);

            // Arrange
            var response = _controller.Get();

            // Assert
            Assert.NotNull(response);
        }


        #endregion

    }
}
