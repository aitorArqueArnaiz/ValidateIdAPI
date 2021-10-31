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

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to get all products from repository.")]
        public void GetProducts_Test()
        {
            var addBasketRequest_1 = new AddUserBasketRequest()
            {
                CreationDate = _shoppingBasket.Basket.CreationDate,
                User = _shoppingBasket.User,
                Units = _shoppingBasket.Basket.Units
            };
            var addBasketRequest_2 = new AddUserBasketRequest()
            {
                CreationDate = _shoppingBasket.Basket.CreationDate,
                User = _shoppingBasket.User,
                Units = _shoppingBasket.Basket.Units
            };

            // Act
            _shoppingBasket.User.Id = 456;
            AdduserBasketResponse result_1 = _basketService.AddShoppingBasketToUser(addBasketRequest_1);
            _shoppingBasket.User.Id = 986;
            AdduserBasketResponse result_2 = _basketService.AddShoppingBasketToUser(addBasketRequest_2);

            // Arrange
            GetAllProductsResponse response = _basketService.GetAllShoppingBaskets();

            // Assert
            Assert.NotNull(response);
            Assert.AreEqual(response.Poducts.Count, 2);
            Assert.AreEqual(response.Poducts[0].User.Id, 456);
            Assert.AreEqual(response.Poducts[0].User.Name, _shoppingBasket.User.Name);
            Assert.AreEqual(response.Poducts[0].Basket.Units, _shoppingBasket.Basket.Units);
            Assert.AreEqual(response.Poducts[0].Total, _totalProductCost);
            Assert.AreEqual(response.Poducts[1].User.Id, 986);
            Assert.AreEqual(response.Poducts[1].User.Name, _shoppingBasket.User.Name);
            Assert.AreEqual(response.Poducts[1].Basket.Units, _shoppingBasket.Basket.Units);
            Assert.AreEqual(response.Poducts[1].Total, _totalProductCost);
        }


        #endregion

        }
}
