﻿using Microsoft.EntityFrameworkCore;
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
            _shoppingBasket = new ShoppingBasket(353);
            _shoppingBasket.Products = new List<Product>() { new Product(2, "TheHobbit"), new Product(5, "BreakingBad") };

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
                CreationDate = _shoppingBasket.CreationDate,
                User = _shoppingBasket.User,
                Units = _shoppingBasket.Products
            };


            // Act
            AdduserBasketResponse result = _basketService.AddShoppingBasketToUser(addBasketRequest);

            // Assert
            var basket = _context.GetShoppingBaskets()[0];
            Assert.NotNull(result);
            Assert.True(result.response);
            Assert.AreEqual(_context.GetShoppingBaskets().Count, 1);
            Assert.AreEqual(basket.User.Id, _shoppingBasket.User.Id);
            Assert.AreEqual(basket.Products, _shoppingBasket.Products);
            Assert.AreEqual(basket.Total, _totalProductCost);
        }

        [Test]
        [Author("Aitor Arqué Arnaiz")]
        [Description("Test intended to get all products from repository.")]
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
            AdduserBasketResponse result_1 = _basketService.AddShoppingBasketToUser(addBasketRequest_1);
            _shoppingBasket.User.Id = 986;
            AdduserBasketResponse result_2 = _basketService.AddShoppingBasketToUser(addBasketRequest_2);

            // Arrange
            GetAllProductsResponse response = _basketService.GetAllShoppingBaskets();

            // Assert
            Assert.NotNull(response);
            Assert.AreEqual(response.Poducts.Count, 2);
            Assert.AreEqual(response.Poducts[0].User.Id, 456);
            Assert.AreEqual(response.Poducts[0].Products, _shoppingBasket.Products);
            Assert.AreEqual(response.Poducts[0].Total, _totalProductCost);
            Assert.AreEqual(response.Poducts[1].User.Id, 986);
            Assert.AreEqual(response.Poducts[1].Products, _shoppingBasket.Products);
            Assert.AreEqual(response.Poducts[1].Total, _totalProductCost);
        }


        #endregion

        }
}
