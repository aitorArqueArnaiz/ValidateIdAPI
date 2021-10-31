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

        public GetAllProductsResponse GetAllShoppingBaskets()
        {
            var response = new GetAllProductsResponse();
            response.Poducts = _basketRepository.GetShoppingBaskets();
            return response;
        }

        #endregion

        #region Helper methods

        /// <summary>Method that converts an AddUserBasketRequest into ShoppingBasket.</summary>
        /// <param name="shoppingBasketRequest">The shopping basket request data to be added for a given user.</param>
        /// <returns>The shopping basket.</returns>
        private ShoppingBasket ConvertAdduserRequestToShoppingCart(AddUserBasketRequest shoppingBasketRequest)
        {
            var primaryKey = new Random();
            ShoppingBasket shoppingBasket = new ShoppingBasket(shoppingBasketRequest.User.Id);

            User user = new User
            {
                Id = shoppingBasketRequest.User.Id
            };
            shoppingBasket.Id = primaryKey.Next();
            shoppingBasket.Products = shoppingBasketRequest.Units;
            shoppingBasket.CreationDate = shoppingBasketRequest.CreationDate;

            return shoppingBasket;
        }

        /// <summary>Method that calculates thw total product cost of the basket.</summary>
        /// <param name="units">The list of products.</param>
        /// <returns>The total cost of the basket.</returns>
        private double CalculateTotalProductCost(List<Product> units)
        {
            double totalCost = 0;

            foreach(var product in units)
            {
                var price = (int)Enum.Parse(typeof(ProductPrice), Enum.GetName(product.Name));
                totalCost += product.Quantity * price;
            }
            return totalCost;
        }

        #endregion
    }
}
