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

            private readonly IInMemmoryRepository _basketRepository;

        #endregion

        #region Class constructor

        public BasketService(IInMemmoryRepository repository) : base()
        {
            _basketRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        #endregion

        #region Class methods

        public AdduserBasketResponse AddShoppingBasketToUser(AddUserBasketRequest shoppingBasketRequest)
        {
            return new AdduserBasketResponse();
        }

        public List<ShoppingBasket> GetAllShoppingBaskets()
        {
            return null;
        }

        #endregion
    }
}
