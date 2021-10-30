using System.Collections.Generic;
using ValidateId.Domain.DTOs.Basket;
using ValidateId.Domain.Entities;

namespace ValidateId.Bussines.Interfaces.Basket
{
    public interface IBasket
    {
        /// <summary>Method that gets all the shopping baskets existing in the current in memmory data base.</summary>
        /// <param name="shoppingBasket">The shopping basket to be added for a given user.</param>
        /// <returns>The user shopping basket that has been added.</returns>
        AdduserBasketResponse AddShoppingBasketToUser(AddUserBasketRequest shoppingBasket);

        /// <summary>Method that gets all the shopping baskets existing in the current inMemmory data base.</summary>
        /// <returns>The list of all shopping baskets/products.</returns>
        List<ShoppingBasket> GetAllShoppingBaskets();

    }
}
