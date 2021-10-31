using System;
using System.Collections.Generic;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Domain.DTOs.Basket;
using ValidateId.Domain.Entities;
using ValidateId.Infrastructure.Interfaces;

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
            var primaryKey = new Random();

            Domain.Entities.Basket basket = new Domain.Entities.Basket();
            User user = new User();

            // Convert AddUserBasketRequest into Shopping basket
            user.Id = shoppingBasketRequest.User.Id;
            user.Name = shoppingBasketRequest.User.Name;
            basket.Id = primaryKey.Next();
            basket.Total = shoppingBasketRequest.Total;
            basket.Units = shoppingBasketRequest.Units;
            basket.CreationDate = shoppingBasketRequest.CreationDate;
            var shoppingBasket = new ShoppingBasket(user, basket);

            response.response = _basketRepository.AddShoppingBasket(shoppingBasket);
            response.message = $"Basket succesfully added for user {shoppingBasketRequest.User.Id}";

            return response;

        }

        public List<ShoppingBasket> GetAllShoppingBaskets()
        {
            return null;
        }

        #endregion
    }
}
