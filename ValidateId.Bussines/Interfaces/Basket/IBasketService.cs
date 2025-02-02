﻿using ValidateId.Domain.DTOs.Basket;

namespace ValidateId.Bussines.Interfaces.Basket
{
    public interface IBasketService
    {
        /// <summary>Method that gets all the shopping baskets existing in the current in memmory data base.</summary>
        /// <param name="shoppingBasket">The shopping basket to be added for a given user.</param>
        /// <returns>The user shopping basket that has been added.</returns>
        AdduserBasketResponse AddShoppingBasketToUser(AddUserBasketRequest shoppingBasket);

        /// <summary>Method that gets all the shopping baskets existing in the current inMemmory data base.</summary>
        /// <returns>The list of all shopping baskets/products.</returns>
        GetAllProductsResponse GetAllShoppingBaskets();

        /// <summary>Method that calculates the product cost.</summary>
        /// <param name="productName">The product name.</param>
        /// <param name="quantity">The product quantity/units.</param>
        /// <returns>The cost of the product.</returns>
        double CalculateProductCost(string productName, int quantity);

    }
}
