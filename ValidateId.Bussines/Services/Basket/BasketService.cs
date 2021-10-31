using System;
using System.Collections.Generic;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Domain.DTOs.Basket;
using ValidateId.Domain.Entities;
using ValidateId.Infrastructure.Interfaces;
using static ValidateId.Domain.Shared.Enums;

namespace ValidateId.Bussines.Services.Basket
{
    public class BasketService : IBasketService
    {

        #region Class variables

            private readonly IRepository _basketRepository;

        #endregion

        #region Class constructor

        public BasketService(IRepository repository) : base()
        {
            _basketRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #endregion

        #region Class methods

        public AdduserBasketResponse AddShoppingBasketToUser(AddUserBasketRequest shoppingBasketRequest)
        {
            var response = new AdduserBasketResponse();

            // Convert AddUserBasketRequest into Shopping basket
            ShoppingBasket shoppingBasket = ConvertAdduserRequestToShoppingCart(shoppingBasketRequest);

            // Calculate the total cost from the product list
            double totalProductCost = CalculateTotalProductCost(shoppingBasketRequest.Units);

            response.response = _basketRepository.AddShoppingBasket(shoppingBasket, totalProductCost);
            response.message = $"Basket succesfully added for user {shoppingBasketRequest.User.Id}";

            return response;

        }

        public List<ShoppingBasket> GetAllShoppingBaskets()
        {
            return null;
        }

        #endregion

        #region Helper methods

        /// <summary>Method that converts an AddUserBasketRequest into ShoppingBasket.</summary>
        /// <param name="shoppingBasketRequest">The shopping basket request data to be added for a given user.</param>
        /// <returns>The shopping basket.</returns>
        private ShoppingBasket ConvertAdduserRequestToShoppingCart(AddUserBasketRequest shoppingBasketRequest)
        {
            var primaryKey = new Random();
            Domain.Entities.Basket basket = new Domain.Entities.Basket();

            User user = new User
            {
                Id = shoppingBasketRequest.User.Id,
                Name = shoppingBasketRequest.User.Name
            };
            basket.Id = primaryKey.Next();
            basket.Units = shoppingBasketRequest.Units;
            basket.CreationDate = shoppingBasketRequest.CreationDate;

            return new ShoppingBasket(user, basket);
        }

        /// <summary>Method that calculates thw total product cost of the basket.</summary>
        /// <param name="units">The list of products.</param>
        /// <returns>The total cost of the basket.</returns>
        private double CalculateTotalProductCost(Dictionary<int, string> units)
        {
            double totalCost = 0;

            foreach(var product in units)
            {
                var price = (int)Enum.Parse(typeof(ProductPrice), product.Value);
                totalCost += product.Key * price;
            }
            return totalCost;
        }

        #endregion
    }
}
