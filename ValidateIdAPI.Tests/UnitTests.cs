using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Bussines.Services.Basket;
using ValidateId.Domain.DTOs.Basket;
using ValidateId.Domain.Entities;
using ValidateId.Infrastructure.Data.Repositories;
using ValidateId.Infrastructure.Interfaces;
using static ValidateId.Domain.Shared.Enums;

namespace ValidateId.Tests
{
    [TestFixture]
    public class UnitTests
    {
        #region Class Variables

        // The user shopping basket
        private ShoppingBasket _shoppingBasket;

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
            _shoppingBasket = new ShoppingBasket(new User(), new Basket());
            _shoppingBasket.Basket.Units = new Dictionary<int, string>() { { 2, "TheHobbit" }, { 5, "BreakingBad" } };

            _shoppingBasket.User.Id = 353;
            _shoppingBasket.User.Name = "User test";

            var options = new DbContextOptionsBuilder<InMemmoryRepository>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
  
            _context = new InMemmoryRepository(options);
            _basketService = new BasketService(_context);

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
        [Description("Test intended to add a new item to a user basket repository.")]
        public void AddShoppingBasket_ToUser_Test()
        {
            // Arrange
            var addBasketRequest = new AddUserBasketRequest()
            {
                CreationDate = _shoppingBasket.Basket.CreationDate,
                User = _shoppingBasket.User,
                Units = _shoppingBasket.Basket.Units
            };


            // Act
            AdduserBasketResponse result = _basketService.AddShoppingBasketToUser(addBasketRequest);

            // Assert
            var basket = _context.GetShoppingBaskets()[0];
            Assert.NotNull(result);
            Assert.True(result.response);
            Assert.AreEqual(_context.GetShoppingBaskets().Count, 1);
            Assert.AreEqual(basket.User.Id, _shoppingBasket.User.Id);
            Assert.AreEqual(basket.User.Name, _shoppingBasket.User.Name);
            Assert.AreEqual(basket.Basket.Units, _shoppingBasket.Basket.Units);
            Assert.AreEqual(basket.Total, _totalProductCost);
        }

        #endregion
    }
}
