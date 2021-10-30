using System;
using System.Collections.Generic;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Domain.Entities;
using ValidateId.Infrastructure.Data.Repositories;
using ValidateId.Infrastructure.Interfaces;

namespace ValidateId.Bussines.Services.Basket
{
    public class BasketService : IBasket
    {

        #region Class variables

            private readonly IInMemmoryRepository _basketRepository;

        #endregion

        #region Class constructor

        public BasketService(IInMemmoryRepository repository) : base()
        {
            _basketRepository = (repository ?? throw new ArgumentNullException(nameof(repository)));
        }

        #endregion

        #region Class methods

        public ShoppingBasket AddShoppingBasketToUser(ShoppingBasket shoppingBasket)
        {
            return null;
        }

        public List<ShoppingBasket> GetAllShoppingBaskets()
        {
            return null;
        }

        #endregion
    }
}
